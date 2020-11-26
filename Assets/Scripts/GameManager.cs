using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

namespace Asset.Scripts
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        private static GameManager _instance;

        public static GameManager Instance => _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }
        #endregion

        public int score;
        public int lives = 3;

        [HideInInspector]
        public bool pauseActive;
        public bool gameOver;

        public Text scoreText;
        public Text gameoverText;
        public Text winScreenText;

        public Image[] hearts;

        public GameObject pause;
        public GameObject gameover;
        public GameObject winScreen;

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

        public void LoseLife()
        {
            if (lives > 0)
            {
                lives--;
                HeartsUpdate();
            }

            {
                GameOver();
            }
        }

        public void AddLife()
        {
            if (lives < 3)
            {
                lives++;
                HeartsUpdate();
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
            HeartsUpdate();
            UnPause();
            gameover.SetActive(false);
            gameOver = false;
            Destroy(gameObject);
        }

        public void GameOver()
        {
            if (lives == 0)
            {
                gameover.SetActive(true);
                gameoverText.text = score.ToString();
                gameOver = true;
                Time.timeScale = 0;
            }
        }

        public void WinScreen()
        {
            winScreen.SetActive(true);
            winScreenText.text = score.ToString();
            pauseActive = true;
            Time.timeScale = 0;
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
}

