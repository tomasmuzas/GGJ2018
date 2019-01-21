﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public static int score = 0;
    public static int highscore = 0;
    public int slavCountCurrent = 0;
    public static int slavCountRemaining = 0;
    public int slavCountNeeded = 15;

    public Image progressBar;
    public int timeRemaining = 20;
    public GameObject GameOver;
    public GameObject GameWinCanvas;
    public Text scoreText;
    public Text hiText;


    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        GameOver = GameObject.Find("GameOver");
        GameOver.gameObject.SetActive(false);
        GameWinCanvas = GameObject.Find("GameWin");
        GameWinCanvas.gameObject.SetActive(false);

        scoreText = GameObject.Find("CurrentScore").GetComponent<Text>();
        scoreText.text = 0.ToString(); // TODO: Keep between levels
        hiText = GameObject.Find("HighScore").GetComponent<Text>();
        hiText.text = highscore.ToString();
    }

    public void AddScore(Praeivis praeivis)
    {
        score += praeivis.Points;
        scoreText.text = score.ToString();

        slavCountCurrent++;
        progressBar.fillAmount =  (float)slavCountCurrent / slavCountNeeded;

        if (slavCountCurrent >= slavCountNeeded)
        {
            GameWin();
        }
    }

    void Update()
    {
        var time = (int)Mathf.Floor(timeRemaining - Time.timeSinceLevelLoad);
        GameObject.Find("TimeLeft").GetComponent<Text>().text = String.Format("{0}:{1:00}", time / 60, time % 60);

        if (time <= 0)
        {
            GameLose();
        }
        if (Input.GetKeyDown("escape"))
        {
            PlayGames.AddScoreToLeaderBoard(GPGSIds.leaderboard_score, score);
            SceneManager.LoadScene(0);
            Time.timeScale = 1F;
        }
    }

    public void GiveTime(int count)
    {
        timeRemaining += count;
    }

    public void GameLose()
    {
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        PlayGames.AddScoreToLeaderBoard(GPGSIds.leaderboard_score, score);
        Time.timeScale = 0.0F;
        GameOver.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        GameOver.gameObject.SetActive(true);
        GetComponent<AudioSource>().Play();
    }

    public void GameWin()
    {
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        PlayGames.AddScoreToLeaderBoard(GPGSIds.leaderboard_score, score);
        Time.timeScale = 0.0F;
        GameWinCanvas.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        GameWinCanvas.gameObject.SetActive(true);
    }

	public void OpenLeaderBoard()
	{
		PlayGames.ShowLeaderboardUI();
	}
}
