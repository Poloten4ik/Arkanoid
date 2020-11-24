using UnityEngine;

namespace Asset.Scripts.PickUps
{
    public class ScaleBall : AbstractPickUp
    {
        public float x;
        public float y;
        public override void ApplyEffect()
        {
            Ball[] balls = FindObjectsOfType<Ball>();
            foreach (Ball ball in balls)
            {
                ball.transform.localScale = new Vector2(x, y);
            }
        }
    }
}

