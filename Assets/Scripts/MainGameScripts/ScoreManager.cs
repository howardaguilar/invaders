using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI hiScore;
    public TextMeshProUGUI scoreAdvanceTable;

    private int scoreCount = 0;
    private int hiScoreCount = 0;

    // Update is called once per frame
    void Update()
    {
        // Update score and remove legend when player starts shooting
        if (scoreCount > hiScoreCount)
        {
            updateHiScore();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            updateScoreAdvanceTable();
        }
    }

    // Update score depending on which block was destroyed
    public void updateScore(string color)
    {
        if (color == "red")
        {
            scoreCount += 10;
        }
        else if (color == "green")
        {
            scoreCount += 20;
        }
        else if (color == "blue")
        {
            scoreCount += 30;
        }
        else if (color == "purple")
        {
            scoreCount += 60;
        }


        score.text = "SCORE\n  " + string.Format("{0:0000}", scoreCount);
    }
    // Update Hi Score
    public void updateHiScore()
    {
        hiScoreCount = scoreCount;
        hiScore.text = "HI-SCORE\n     " + string.Format("{0:0000}", hiScoreCount);
    }
    // Get rid of Legend text
    public void updateScoreAdvanceTable()
    {
        scoreAdvanceTable.text = "";
    }
}
