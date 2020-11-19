using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Asset.Scripts
{
    public class Pad : MonoBehaviour
    {
        private Camera mainCamera;
        float yPosition;
        private float maxX = 7.2f;
        public bool autoplay;
        GameManager gameManager;
        Ball ball;
        private SpriteRenderer sr;
        private float Clamp;
        public bool magnetEffect;
        public int magnerPower;

        #region Singleton

        private static Pad _instance;

        public static Pad Instance => _instance;

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

        void Start()
        {
            yPosition = this.transform.position.y;
            ball = FindObjectOfType<Ball>();
            gameManager = FindObjectOfType<GameManager>();
            sr = GetComponent<SpriteRenderer>();
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
                Vector3 ballPos = BallManager.Instance.initialBall.transform.position;
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

            padNewposition.x = Mathf.Clamp(padNewposition.x, -Clamp, Clamp);
            transform.position = padNewposition;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ball") && magnetEffect == true)
            {
                GameManager.Instance.isStarted = false;
                magnerPower--;
                if (magnerPower <= 0)
                {
                    magnetEffect = false;
                }
            }
        }
    }


}
