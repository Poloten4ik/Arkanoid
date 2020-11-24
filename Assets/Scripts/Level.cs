﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asset.Scripts
{
    public class Level : MonoBehaviour
    {
        Ball ball;
        public int blockscount;
        public int Hp;
        public Scene[] scenes;

        private void Start()
        {
            ball = FindObjectOfType<Ball>();
        }
        public void BlockCreated()
        {
            blockscount++;
        }
        public void BlockDestroyed()
        {
            blockscount--;

            if (blockscount <= 0)
            {
                int index = SceneManager.GetActiveScene().buildIndex;
                if (index < 5)
                {
                    SceneManager.LoadScene(index + 1);
                }
                else
                {
                    GameManager gameManager = FindObjectOfType<GameManager>();
                    gameManager.WinScreen();
                }
            }
        }

        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}

