using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiGameOver : MonoBehaviour
{
    public ScoreCounter gameScoreCounter;
    public ScoreCounter highScoreCounter;
    public SpriteRenderer tagNewBest;
    public SpriteRenderer medalHighscore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int gameScore, int highscore)
    {
        RankingManager.GetInstance.UpdateScore(gameScore);
        gameScoreCounter.SetScore(gameScore);
        highScoreCounter.SetScore(highscore);

        bool isNewHighscore = (gameScore == highscore);

        tagNewBest.enabled = isNewHighscore;

        RankingManager.GetInstance.SetMedalByScore(gameScore, ref medalHighscore);
    }

    public void ShowGUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void HideGUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
