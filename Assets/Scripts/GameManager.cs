using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public Text livesText;
    public int lives = 3;
    public bool pauseActive;
    Ball ball;
    public Image[] hearts;
    public GameObject pause;
    public GameObject gameover;
    public Text gameoverText;

    public bool gameOver;

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
            Time.timeScale = 0f;
            pauseActive = true;
            pause.SetActive(true);
        }
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
        pauseActive = false;
        pause.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        lives = 3;
        HeartsUpdate();
        score = default;
        scoreText.text = "0";
        UnPause();
        gameover.SetActive(false);
        gameOver = false;
    }

    public void GameOver()
    {
        if (lives == 0)
        {
            gameover.SetActive(true);
            gameoverText.text = score.ToString();
            gameOver = true;
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
