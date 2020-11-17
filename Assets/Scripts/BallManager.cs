using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    #region Singleton
    private static BallManager _instance;

    internal void SpawnBalls(object ball)
    {
        throw new NotImplementedException();
    }

    public static BallManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    [SerializeField]
    private Ball ballPrefab;

    public float speed;
    [HideInInspector]
    public Ball initialBall;
    [HideInInspector]
    public Rigidbody2D initialBallRb;
    public List<Ball> Balls { get; set; }

    private void Start()
    {
        InitBall();
    }

    private void Update()
    {
        if (!GameManager.Instance.isStarted)
        {
            Vector3 padPosition = Pad.Instance.gameObject.transform.position;
            Vector3 ballPosition = new Vector3(padPosition.x, padPosition.y + 0.5f, 0);
            initialBall.transform.position = ballPosition;

            if (Input.GetMouseButtonDown(0) && !GameManager.Instance.pauseActive)
            {
                initialBallRb.AddForce(new Vector2(0, speed));
                GameManager.Instance.isStarted = true;

            }
        }


    }

    public void SpawnBalls(Vector3 position, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Ball spawnedBall = Instantiate(ballPrefab, position, Quaternion.identity);
            Rigidbody2D spawnedBallRb = spawnedBall.GetComponent<Rigidbody2D>();
            spawnedBallRb.AddForce(new Vector2(0,speed));
            Balls.Add(spawnedBall);
        }
    }

    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(0.3f);

        foreach (var ball in Balls.ToList())
        {
            Destroy(ball.gameObject);
        }
        InitBall();
        GameManager.Instance.isStarted = false;
        gameObject.transform.localScale = new Vector2(1, 1);

    }

    public void InitBall()
    {
        Vector3 padPosition = Pad.Instance.gameObject.transform.position;
        Vector3 startPosition = new Vector3(padPosition.x, padPosition.y + 0.5f, 0);
        initialBall = Instantiate(ballPrefab, startPosition, Quaternion.identity);
        initialBallRb = initialBall.GetComponent<Rigidbody2D>();

        Balls = new List<Ball>
        {
            initialBall
        };
    }

   

}

