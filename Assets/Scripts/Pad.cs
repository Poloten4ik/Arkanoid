using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pad : MonoBehaviour
{
    private Camera mainCamera;
    float yPosition;
    private float maxX = 7.2f;
    public bool autoplay;
    GameManager gameManager;
    Ball ball;
    private SpriteRenderer sr;

    private float Clamp ;


    void Start()
    {
        yPosition = this.transform.position.y;
        ball = FindObjectOfType<Ball>();
        gameManager = FindObjectOfType<GameManager>();
        sr = GetComponent<SpriteRenderer>();
        print(sr.size.x);
    }

    void Update()
    {
        PaddleMove();
    }

    public void PaddleMove()
    {
        Vector3 padNewposition;
        if (autoplay)
        {
            Vector3 ballPos = ball.transform.position;
            padNewposition = new Vector3(ballPos.x, yPosition, 0);
        }

        else if (gameManager.pauseActive || gameManager.gameOver)
        {
            return;
        }
        else
        {
            Vector3 mousePixelPosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPosition);
            padNewposition = new Vector3(mouseWorldPosition.x, yPosition, 0);

        }
        Clamp = 1 - transform.localScale.x + maxX;

        padNewposition.x = Mathf.Clamp(padNewposition.x,-Clamp, Clamp );
        transform.position = padNewposition;


        //float mousePositionPixels = Mathf.Clamp(Input.mousePosition.x, leftClamp, rightClamp);
        //float mousePositionX = mainCamera.ScreenToWorldPoint(new Vector3(mousePositionPixels, 0, 0)).x;
        //this.transform.position = new Vector3(mousePositionX, yPosition, 0);
    }
}
