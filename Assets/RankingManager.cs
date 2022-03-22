using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Globalization;

public enum MedalLevel
{
    None,
    White,
    Silver,
    Gold,
    Super
}
public struct HighScore
{
    public int score;
    public string timeStamp;

    public HighScore(int _score, string _timeStamp)
    {
        this.score = _score;
        this.timeStamp = _timeStamp;
    }
}

public sealed class RankingManager : MonoBehaviour
{
    private static RankingManager instance = null;
    public static RankingManager GetInstance {  
        get {  
            // if (instance == null) {
            //     GameObject go = new GameObject();
            //     instance = go.AddComponent<RankingManager>();
            // }  
            return instance;  
        }  
    }  
    void Start() {   instance = this; }
    public const int HIGH_SCORE_LENGTH = 5;
    public Sprite medalWhite;
    public Sprite medalSilver;
    public Sprite medalGold;
    public Sprite medalSuper;


    public void UpdateScore(int score)
    {
        String timeStamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();

        IDictionary<int, HighScore> highScoresList = ReadHighScoresList();
        if (highScoresList.Count == 0)
        {
            highScoresList[1] = new HighScore(score,  timeStamp);
            
            WriteHighScoresList(highScoresList);
            return;
        }

        for (int rankIndex = 1; rankIndex <= highScoresList.Count; rankIndex++) {
            var highScore = highScoresList[rankIndex];
            if (score > highScore.score)    // can join highscore board
            {
                int index = Math.Min(HIGH_SCORE_LENGTH, highScoresList.Count + 1);
                for (; index > rankIndex; index--)
                {
                    highScoresList[index] = highScoresList[index - 1];
                }
                highScoresList[rankIndex] = new HighScore(score,  timeStamp);

                WriteHighScoresList(highScoresList);
                return;//
            }
        }

        if (highScoresList.Count < HIGH_SCORE_LENGTH)
        {
            highScoresList[highScoresList.Count + 1] = new HighScore(score,  timeStamp);
        }

        WriteHighScoresList(highScoresList);
    }

    
    public IDictionary<int, HighScore> ReadHighScoresList()
    {
        IDictionary<int, HighScore> highScoresList = new Dictionary<int, HighScore>();

        if (PlayerPrefs.HasKey("HighScoresList"))
        {
            string strHighScoresList = PlayerPrefs.GetString("HighScoresList");
            string[] strHighScores = strHighScoresList.Split(',');
            int rankIndex = 1;
            foreach (var strHighScore in strHighScores)
            {
                string[] strScore = strHighScore.Split('-');
                highScoresList[rankIndex] = new HighScore(Int32.Parse(strScore[0]),  strScore[1]);
                rankIndex++;
            }
        }

        return highScoresList;
    }
    public void WriteHighScoresList(IDictionary<int, HighScore> highScoresList)
    {
        string strHighScoresList = "";

        for (int rankIndex = 1; rankIndex <= highScoresList.Count; rankIndex++) {
            var highScore = highScoresList[rankIndex];
            strHighScoresList += (highScore.score.ToString() + "-" + highScore.timeStamp + ",");
        }

        if (highScoresList.Count > 0) {
            strHighScoresList = strHighScoresList.Remove(strHighScoresList.Length - 1, 1);  // remove last ","
        }

        PlayerPrefs.SetString("HighScoresList", strHighScoresList);
    }

    public void SetMedalLevel(MedalLevel medalLevel, ref SpriteRenderer medal)
    {
        medal.enabled = true;
        switch(medalLevel) 
        {
        case MedalLevel.None:
            medal.enabled = false;
            break;
        case MedalLevel.White:
            medal.sprite = medalWhite; 
            break;
        case MedalLevel.Silver:
            medal.sprite = medalSilver; 
            break;
        case MedalLevel.Gold:
            medal.sprite = medalGold; 
            break;
        case MedalLevel.Super:
            medal.sprite = medalSuper; 
            break;
        default:
            medal.enabled = false;
            break;
        }
    }

    public void SetMedalByScore(int score, ref SpriteRenderer medal)
    {
        if (score >= 200) SetMedalLevel(MedalLevel.Super, ref medal);
        else if (score >= 100) SetMedalLevel(MedalLevel.Gold, ref medal);
        else if (score >= 50) SetMedalLevel(MedalLevel.Silver, ref medal);
        else if (score >= 10) SetMedalLevel(MedalLevel.White, ref medal);
        else SetMedalLevel(MedalLevel.None, ref medal);
    }
}
