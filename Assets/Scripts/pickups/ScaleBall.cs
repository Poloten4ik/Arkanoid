using UnityEngine;

namespace Asset.Scripts.PickUps
{
    public class ScaleBall : AbstractPickUp
    {
        public float x;
        public float y;
        public override void ApplyEffect()
        {
            for (int i = 0; i < BallManager.Instance.Balls.Count; i++)
            {
                BallManager.Instance.Balls[i].transform.localScale = new Vector2(x, y);
            }
        }
    }
}

