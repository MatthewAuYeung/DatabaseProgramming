﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    private SQLWebClient sqlWebClient = new SQLWebClient();
    int score = 0;
    static public int lastscore = 0;
    public TextMeshProUGUI CurrentScoreTextTMPro;
    public TextMeshProUGUI BestScoreTextTMPro;

    public GameObject GameOverPanel;
    public GameObject GameOverEffectPanel;

    public GameObject touchToMoveTextObj;

    public GameObject StartFadeInObj;

    static int PlayCount;

    void Awake()
    {
        Application.targetFrameRate = 60;


        Time.timeScale = 1.0f;


        BestScoreTextTMPro.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        StartCoroutine(FadeIn());
    }

    void Update()
    {
        if (touchToMoveTextObj.activeSelf == false) return;
        if (Input.GetMouseButton(0))
        {
            touchToMoveTextObj.SetActive(false);
        }
    }

    IEnumerator FadeIn()
    {
        StartFadeInObj.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartFadeInObj.SetActive(false);
        yield break;
    }




    public void addScore()
    {
        score++;
        CurrentScoreTextTMPro.text = score.ToString();

        lastscore = score;

        if (score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", score);
            BestScoreTextTMPro.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

        }
    }


    public void Gameover()
    {
        UploadMatch();
        StartCoroutine(GameoverCoroutine());
    }


    IEnumerator GameoverCoroutine()
    {
        GameOverEffectPanel.SetActive(true);
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(0.5f);
        GameOverPanel.SetActive(true);
        yield break;
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameLoader");
    }

    public void UploadMatch()
    {
        DateTime date = DateTime.Now;
        string date_of_match = date.ToString("yyyy-MM-dd");
        lastscore = score;
        MatchData newMatch = new MatchData();
        newMatch.InitializeMatch(GameLoader.playerID, lastscore, date_of_match);

        StartCoroutine(GameoverCoroutine());
        StartCoroutine(sqlWebClient.AddMatch(newMatch));
    }
}
