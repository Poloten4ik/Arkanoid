using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    bool isStarted;
    public Pad pad;
    float yPosition;

    void Start()
    {
        yPosition = transform.position.y;
    }

    private void Update()
    {
        if (isStarted)
        {

        }
        else
        {
            UpdateBall();
            if (Input.GetMouseButtonDown(0))
            {
                StartBall();
            }
        }
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(0.3f);

        UpdateBall();
        isStarted = false;
        speed = default; 
    }

    private void StartBall()
    {

        Vector2 force = new Vector2(-1, -1) * speed;

        rb.AddForce(force);
        isStarted = true;
    }

    private void UpdateBall()
    {
        Vector3 padPosition = pad.transform.position;
        Vector3 ballNewPosition = new Vector3(padPosition.x, yPosition, 0);
        transform.position = ballNewPosition;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        StartCoroutine(Restart());
    }
}
