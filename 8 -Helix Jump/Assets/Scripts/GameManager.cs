using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public int bestScore;
    public int score;
    
    // currentLevel
    public int currentStage = 0;

    public static GameManager singleton;
    private void Awake()
    {
        Advertisement.Initialize("4302505");
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);
        bestScore = PlayerPrefs.GetInt("Highscore");
    }

    public void NextLevel()
    {
        currentStage++;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
        Debug.Log("Next Level Called");
    }
    public void RestartLevel()
    {
        Debug.Log("Show Ads");
        Advertisement.Show();
        

        // Show Ads
        singleton.score = 0;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
        // Reload stage
    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("Highscore", score);
        }
    }
}
