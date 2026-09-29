using System;
using TMPro;
using UnityEngine;

public class GameOverUIBehaviour : MonoBehaviour
{
    int score;
    int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public AudioSource gameoverSFX;
    void Awake()
    {
        score = PlayerPrefs.GetInt("Score");
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Start()
    {
        gameoverSFX.Play();
        DisplayScore();
    }

    void DisplayScore()
    {
        if (score > highScore)
        {
            scoreText.text = "Nouveau Meilleur Score : "+ score;
            highScoreText.text = "";
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();

        }
        else
        {
            scoreText.text = "Vous avez fait : "+ score;
            highScoreText.text = "Meilleur Score : "+ highScore;
        }
        

    }
}
