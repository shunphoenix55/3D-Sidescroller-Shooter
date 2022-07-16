using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text winText;

    public int winScore;

    private int _score;
    public int score 
    {
        get
        {
            return _score;
        }

        set
        {
            if (value >= 0)
            {
                _score = value;
            }

            else
            {
                _score = 0;
            }
        }
    }

  
    public void UpdateScore()
    {
        scoreText.text = score.ToString();

        if (score >= winScore)
        {
            Win();
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    public void Win()
    {
        winText.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public static void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
