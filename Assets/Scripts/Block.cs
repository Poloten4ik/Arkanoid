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
        if (blocks.Length - 1 <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void Update()
    {
        
    }
}
