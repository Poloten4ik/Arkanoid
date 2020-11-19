using UnityEngine;

namespace Asset.Scripts
{
    public class Ball : MonoBehaviour
    {
        public float newSpeed;
        public void Die()
        {
            GameManager.Instance.LoseLife();
            Destroy(gameObject);
        }

        public void SpeedUp()
        {
            GetComponent<Rigidbody2D>().velocity *= newSpeed;
        }

        public void SpeedDown()
        {
            GetComponent<Rigidbody2D>().velocity /= newSpeed;
        }

        public void Restart()
        {
            GameManager.Instance.isStarted = false;
            BallManager.Instance.initialBallRb.velocity = Vector2.zero;
        }
    }
}

