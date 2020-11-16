using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public bool isStarted;
    float yPosition;
    public int health;
    Pad pad;
    GameManager gameManager;
    public bool speedUp;
    public bool speedDown;

    void Start()
    {
        yPosition = transform.position.y;
        pad = FindObjectOfType<Pad>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (isStarted)
        {

        }
        else if (gameManager.pauseActive != true)
        {
            UpdateBall();
            if (Input.GetMouseButtonDown(0))
            {
                StartBall();
            }
        }
    }

    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(0.3f);
        rb.velocity = Vector2.zero;
        isStarted = false;
    }

    public void StartBall()
    {
        float randomX = Random.Range(-1f, 1f);
        Vector2 direction = new Vector2(randomX, 1);
        Vector2 force = direction.normalized * speed;
        rb.velocity = force;
        isStarted = true;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, rb.velocity);
    }

    private void UpdateBall()
    {
        Vector3 padPosition = pad.transform.position;
        Vector3 ballNewPosition = new Vector3(padPosition.x, yPosition, 0);
        transform.position = ballNewPosition;
    }
}
