using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    int score;
    static int bestScore = 0;
    bool IsNewHighScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        IsNewHighScore = false;
    }

    public void ChangeScore(int points)
    {
        score += points;

        if (score > bestScore)
        {
            bestScore = score;
            IsNewHighScore = true;
        }

        Text scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }
}
