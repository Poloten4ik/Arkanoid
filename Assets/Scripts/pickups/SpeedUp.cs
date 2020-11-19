using System.Linq;

namespace Asset.Scripts.PickUps
{
    public class SpeedUp : AbstractPickUp
    {
        public override void ApplyEffect()
        {
            foreach (Ball ball in BallManager.Instance.Balls.ToList())
            {
                ball.SpeedUp();
            }
        }
    }

}
