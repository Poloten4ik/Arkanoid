using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    bool isStarted;
    public Pad pad;
    float yPosition;
    public int lives;

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
        print(rb.velocity.magnitude);
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(0.3f);

        UpdateBall();
        isStarted = false;
        lives--;
    }

    private void StartBall()
    {
        float randomX = Random.Range(-5f, 5f);
        Vector2 direction = new Vector2(randomX, 1);
        Vector2 force = direction.normalized * speed;

        rb.AddForce(force);
        rb.velocity = force;
        isStarted = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, rb.velocity);
    }

    private void UpdateBall()
    {
        Vector3 padPosition = pad.transform.position;
        Vector3 ballNewPosition = new Vector3(padPosition.x, yPosition, 0);
        transform.position = ballNewPosition;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (lives > 1)
        {
            StartCoroutine(Restart());
        }
        else
        {
            SceneManager.LoadScene(0);
        }

    }
}
