using System.Linq;
using UnityEngine;

namespace Asset.Scripts.PickUps
{
    public class RestartBall : AbstractPickUp
    {
        public override void ApplyEffect()
        {
            Ball[] balls = FindObjectsOfType<Ball>();
            foreach (Ball ball in balls)
            {
                ball.ActivateMagnet();
            }
        }
    }
}

