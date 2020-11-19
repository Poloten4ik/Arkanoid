using UnityEngine;

namespace Asset.Scripts
{
    public class LoseGame : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Ball")
            {
                Ball ball = collision.GetComponent<Ball>();
                BallManager.Instance.Balls.Remove(ball);
                ball.Die();
            }
        }
    }
}

