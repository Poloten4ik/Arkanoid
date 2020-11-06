﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public Text livesText;
    public int lives = 3;
    bool pauseActive;
    Ball ball;
    public Image[] hearts;

    private void Awake()
    {
        GameManager[] gameManagers = FindObjectsOfType<GameManager>();
        for (int i = 0; i < gameManagers.Length; i++)
        {
            if (gameManagers[i].gameObject != gameObject)
            {
                Destroy(gameObject);
                break;
            }
        }
        ball = FindObjectOfType<Ball>();  
     
    }
    private void Start()
    {
        scoreText.text = "0";
        DontDestroyOnLoad(gameObject);
    }


    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pauseActive)
            {
                Time.timeScale = 1f;
                pauseActive = false;
            }
            else
            {
                Time.timeScale = 0f;
                pauseActive = true;
            }

        }
    }

    public void HeartsUpdate()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}