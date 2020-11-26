using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asset.Scripts
{
    public class Ball : MonoBehaviour
    {
        float yPosition;
        float xDelta;

        public float ballExplosionRadius;
        public float magnetDuration;
        public float speed;
        public float electricityBallDuratiom;


        public int countOfBall = 1;

        public bool isElectricityBall;
        public bool isStarted;
        public bool isMagnetActive;
        public bool isExplosion;

        public ParticleSystem electricityBall;
        public AudioClip electricityBallSound;

        Rigidbody2D rb;


        Pad pad;
        Block block;

        AudioSource audioSource;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();
        }

        public void ActivateMagnet()
        {
            isMagnetActive = true;
            MagnetEffect();
        }
        public void MagnetEffect()
        {
            pad.magnetActive.gameObject.SetActive(true);
            StartCoroutine(StopMagnetEffect(magnetDuration));
        }

        public IEnumerator StopMagnetEffect(float second)
        {

            yield return new WaitForSeconds(second);
            StopMagnet();
        }

        public void StopMagnet()
        {
            isMagnetActive = false;
            pad.magnetActive.gameObject.SetActive(false);
        }

        public void MultiplySpeed(float speedKoef)
        {
            speed *= speedKoef;
            rb.velocity = rb.velocity.normalized * speed;
        }

        void Start()
        {
            pad = FindObjectOfType<Pad>();
            block = FindObjectOfType<Block>();
            yPosition = transform.position.y;
            xDelta = transform.position.x - pad.transform.position.x;

            if (pad.autoplay)
            {
                StartBall();
            }
        }

        public void Duplicate()
        {
            Ball originalBall = this;
            Ball newBall = Instantiate(originalBall);
            newBall.speed = speed;
            newBall.StartBall();
        }

        private void Update()
        {
            if (isStarted)
            {
                //мяч запущен
                //ничего не делаем
            }
            else
            {
                //мяч ещё не запущен

                //двигаться вместе с платформой
                Vector3 padPosition = pad.transform.position; //позиция платформы

                Vector3 ballNewPosition = new Vector3(padPosition.x + xDelta, yPosition, 0); //новая позиция мяча
                transform.position = ballNewPosition;

                //проверить левую кнопку мыши
                if (Input.GetMouseButtonDown(0)) //левая клавиша мыши
                {
                    StartBall();
                }
            }
        }

        private void StartBall()
        {
            float randomX = Random.Range(-1, 1);
            Vector2 direction = new Vector2(randomX, 1);
            Vector2 force = direction.normalized * speed;
            rb.velocity = force;
            //rb.AddForce(force;
            isStarted = true;
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                Gizmos.DrawRay(transform.position, rb.velocity);
            }
        }

        public void StartElectricityBall()
        {
            if (!isElectricityBall)
            {
                audioSource.clip = electricityBallSound;
                isElectricityBall = true;
                electricityBall.gameObject.SetActive(true);
                StartCoroutine(StopElectricityBall(electricityBallDuratiom));
            }
        }

        private IEnumerator StopElectricityBall(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            StopElectricityBall();
        }

        private void StopElectricityBall()
        {
            if (isElectricityBall)
            {
                Ball[] balls = FindObjectsOfType<Ball>();
                foreach (Ball ball in balls)
                {
                    ball.isElectricityBall = false;
                    ball.electricityBall.gameObject.SetActive(false);
                    block.ElectricityBall(isElectricityBall);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            audioSource.Play();
            if (isMagnetActive && collision.gameObject.CompareTag("Pad"))
            {
                yPosition = transform.position.y;
                xDelta = transform.position.x - pad.transform.position.x;
                Restart();
            }
        }
        public void Restart()
        {
            isStarted = false;
            gameObject.transform.localScale = new Vector2(1, 1);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            //print("Collision exit");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //print("Trigger!");
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            //print("Trigger exit");
        }
    }
}
