using UnityEngine;

namespace Asset.Scripts.PickUps
{
    public class ElectricityBall : AbstractPickUp
    {
        public override void ApplyEffect()
        {
            Ball[] balls = FindObjectsOfType<Ball>();
            foreach (Ball ball in balls)
            {
                ball.StartElectricityBall();
            }

            Block[] blocks = FindObjectsOfType<Block>();
            foreach(Block block in blocks)
            {
                block.gameObject.GetComponent<Collider2D>().isTrigger = true;
            }    
        }
    }
}
