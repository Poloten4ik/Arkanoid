using UnityEngine;
using System.Collections;
using Asset.Scripts.PickUps;

namespace Asset.Scripts
{

    public class LoseGame : MonoBehaviour
    {
        public float duration;
        public bool isShield;
        public ParticleSystem shieldActive;

        Ball ball;
        GameManager gameManager;
        private void Start()
        {

            gameManager = FindObjectOfType<GameManager>();
        }
        private void OnTriggerExit2D(Collider2D collision)
        {


            if (collision.tag == "Ball")
            {
                ball = FindObjectOfType<Ball>();
                gameManager.LoseLife();
                ball.Restart();

            }

        }
        public void StartShield()
        {
            if (!isShield)
            {
                gameObject.GetComponent<Collider2D>().isTrigger = false;
                StartCoroutine(StopShieldDuration(duration));
                shieldActive.gameObject.SetActive(true);
            }
        }

        private IEnumerator StopShieldDuration(float second)
        {

            yield return new WaitForSeconds(second);
            StopShield();

        }

        private void StopShield()
        {
            LoseGame lose = FindObjectOfType<LoseGame>();
            lose.gameObject.GetComponent<Collider2D>().isTrigger = true;
            shieldActive.gameObject.SetActive(false);
        }
    }
}

