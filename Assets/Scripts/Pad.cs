using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pad : MonoBehaviour
{
    float yPosition;
    public float maxX;
    public bool autoplay;
    GameManager gameManager;


    Ball ball;
    void Start()
    {
        yPosition = transform.position.y;
        ball = FindObjectOfType<Ball>();
        gameManager = FindObjectOfType<GameManager>();
  
    }

    void Update()
    {
        Game();
        
    }

    public void Game()
    {
        Vector3 padNewposition;
        if (autoplay)
        {
            Vector3 ballPos = ball.transform.position;
            padNewposition = new Vector3(ballPos.x, yPosition, 0);
        }

        else if (gameManager.pauseActive)
        {
            padNewposition.x = transform.position.x;
            padNewposition = new Vector3(padNewposition.x, yPosition, 0);
        }
        else 
        {
            Vector3 mousePixelPosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPosition);

            padNewposition = new Vector3(mouseWorldPosition.x, yPosition, 0);

        }
       
        padNewposition.x = Mathf.Clamp(padNewposition.x, -maxX, maxX);
        transform.position = padNewposition;
    }
  
}
