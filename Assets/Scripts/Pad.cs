using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    float yPosition;

    public float maxX;

    Ball ball;
    void Start()
    {
        yPosition = transform.position.y;
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        Vector3 mousePixelPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPosition);
        Vector3 padNewposition = mouseWorldPosition;

        padNewposition.z = 0;
        padNewposition.y = yPosition;

        padNewposition.x = Mathf.Clamp(padNewposition.x, -maxX, maxX);

     
        transform.position = padNewposition;
    }
}
