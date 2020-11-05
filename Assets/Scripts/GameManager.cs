using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    bool pauseActive;
    // Start is called before the first frame update

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
    }
    private void Start()
    {
        scoreText.text = "0";
        DontDestroyOnLoad(gameObject);
    }
    public void Addscore(int addscore)
    {
        score += addscore;
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
}
