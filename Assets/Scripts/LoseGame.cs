using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    GameManager gameManager;
    Ball ball;
    PickupScore pickup;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ball = FindObjectOfType<Ball>();
        pickup = FindObjectOfType<PickupScore>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            gameManager.lives--;
            gameManager.HeartsUpdate();


            if (gameManager.lives > 0)
            {
                StartCoroutine(ball.Restart());
            }
            else
            {
                gameManager.GameOver();
            }
        }
      
        
    }
}
