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
    public int points;

    GameManager gameManager;
    Level levelManager;


    private void Start()
    {
        currentImage = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        levelManager = FindObjectOfType<Level>();

        levelManager.BlockCreated();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit--;
        if (hit == 0)
        {
            gameManager.AddScore(points);
            Destroy(gameObject);
            levelManager.BlockDestroyed();
        }
        else
        {
            currentImage.sprite = nextImage[hit - 1];
        }
    }

    private void Update()
    {
        
    }
}
