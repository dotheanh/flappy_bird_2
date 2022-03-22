using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiRanking : MonoBehaviour
{
    public RankObject ranking1, ranking2, ranking3, ranking4, ranking5;
    public Dictionary<int, RankObject> rankingObjects = new Dictionary<int, RankObject>();

    void Start()
    {
        rankingObjects.Add(1, ranking1);
        rankingObjects.Add(2, ranking2);
        rankingObjects.Add(3, ranking3);
        rankingObjects.Add(4, ranking4);
        rankingObjects.Add(5, ranking5);
    }

    public void ShowRanking()
    {
        IDictionary<int, HighScore> highScoresList = RankingManager.GetInstance.ReadHighScoresList();
        int rankIndex = 1;
        int maxIndex = Mathf.Min(highScoresList.Count, RankingManager.HIGH_SCORE_LENGTH);
        for (; rankIndex <= maxIndex; rankIndex++) {
            var highScore = highScoresList[rankIndex];
            rankingObjects[rankIndex].SetData(highScore);
        }

        for (; rankIndex <= RankingManager.HIGH_SCORE_LENGTH; rankIndex++) {
            var highScore = new HighScore(-1,  "-1");
            rankingObjects[rankIndex].SetData(highScore);
        }
    }
}
