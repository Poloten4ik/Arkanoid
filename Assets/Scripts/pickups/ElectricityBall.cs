using UnityEngine;
using System;

namespace Asset.Scripts.PickUps
{
    public class ElectricityBall : AbstractPickUp
    {
        public override void ApplyEffect()
        {
            Ball[] balls = FindObjectsOfType<Ball>();
            Ball ballStatus = FindObjectOfType<Ball>();
            Block block = FindObjectOfType<Block>();

            foreach (Ball ball in balls)
            {
                ball.StartElectricityBall();
            }

            block.ElectricityBall(ballStatus.isElectricityBall);

        }
    }
}
