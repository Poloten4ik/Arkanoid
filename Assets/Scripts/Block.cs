using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public int hit;
    public Sprite[] nextImage;
    private SpriteRenderer currentImage;
    public int score;
    private int scorePannel = 0;

    private void Start()
    {
        currentImage = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit--;
        if (hit == 0)
        {
            Destroy(gameObject);
            scorePannel += 10;         
        }
        else
        {
            currentImage.sprite = nextImage[hit - 1];
        }
        NextLevel();
    }

    private void NextLevel()
    {
        var blocks = FindObjectsOfType<Block>();
        if (blocks.Length <= 1)
        {
            SceneManager.LoadScene(1);
        }
    }
}
