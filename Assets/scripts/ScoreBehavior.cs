using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    int score;
    int bonus;
    static int bestScore = 0;
    bool IsNewHighScore;
    bool IsTimerRuning = false;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        bonus = 0;
        DisplayScore();
        IsNewHighScore = false;
    }

    private void Update()
    {
        if (IsTimerRuning)
        {
            timer += Time.deltaTime;
        }    
    }

    public void ChangeScore(int points)
    {
        if (points > 0)
        {
            if((timer < 3f) && (IsTimerRuning))
            {
                bonus += 5;
            }
            else
            {
                bonus = 0;
            }
            IsTimerRuning = true;
            timer = 0f;
        }
        else
        {
            bonus = 0;
        }
        score += points + bonus;

        if (score > bestScore)
        {
            bestScore = score;
            IsNewHighScore = true;
        }
        DisplayScore();
        
    }

    private void DisplayScore()
    {
        print("CurrentScoreIs " + score.ToString());
        Text scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }
}
