
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asset.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        public Text bestScoreText;
        void Start()
        {
            int bestScore = PlayerPrefs.GetInt(GameManager.keyBestScore);
            bestScoreText.text = bestScore.ToString();
        }
    }
}

