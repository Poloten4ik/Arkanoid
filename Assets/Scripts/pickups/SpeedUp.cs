using System.Linq;

namespace Asset.Scripts.PickUps
{
    public class SpeedUp : AbstractPickUp
    {
        public float newSpeed;
        public override void ApplyEffect()
        {
            Ball[] balls = FindObjectsOfType<Ball>();
            foreach (Ball ball in balls)
            {
                ball.MultiplySpeed(newSpeed);
            }
        }
    }

}
