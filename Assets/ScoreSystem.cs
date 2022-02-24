using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public float playerScore;
    public Text scoreText;
    public Text scoreGrade;

    public float maxLevelScore = 0;

    public void GainScore(float amount)
    {
        playerScore += amount;
    }

    public void LoseScore(float amount)
    {
        playerScore -= amount;
    }

    public void GradeScore()
    {
        // F.U.N - Grade scaling 

        // F stands for: failure
        // U stands for: unsatisfactory
        // N stands for: not good enough

        if ( (playerScore / maxLevelScore) > 0.8)
        {
            //text
        }
    }
}
