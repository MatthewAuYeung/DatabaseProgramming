using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public Text scoreText;
    private int score;

    public Text lastscoreText;
    private int lastscore;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        score = PlayerPrefs.GetInt("BestScore", 0);
        scoreText.text = score.ToString();

        lastscoreText.text = "Last Score: " + GameManager.lastscore.ToString();
    }
}
