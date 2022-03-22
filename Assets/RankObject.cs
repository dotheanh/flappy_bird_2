using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RankObject : MonoBehaviour
{
    public SpriteRenderer medal;
    public Text score;
    public Text time;
    public void SetData(HighScore highScoreData)
    {
        RankingManager.GetInstance.SetMedalByScore(highScoreData.score, ref medal);
        if (highScoreData.score > 0)
        {
            score.text = highScoreData.score.ToString();
            long timeStamp = long.Parse(highScoreData.timeStamp);
            DateTimeOffset timeOffset = DateTimeOffset.FromUnixTimeSeconds(timeStamp);
            time.text = timeOffset.ToString("dd/MM/yyyy");;
        }
        else
        {
            score.text = "";
            time.text = "";
        }
    }
}
