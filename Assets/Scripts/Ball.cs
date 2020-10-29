using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    bool isStarted;
    public Pad pad;

    private void Update()
    {
        if (isStarted)
        {

        }
        else
        {
            Vector3 padPosition = pad.transform.position;

            Vector3 ballNewPosition = new Vector3(padPosition.x, padPosition.y + 1, 0);
            transform.position = ballNewPosition;

            if (Input.GetMouseButtonDown(0))
            {
                StartBall();
            }
        }

    }

    private void StartBall()
    {
        Vector2 force = new Vector2(1, 1) * speed;
        rb.AddForce(force);
        isStarted = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
