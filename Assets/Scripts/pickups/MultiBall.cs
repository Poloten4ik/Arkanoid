using System.Linq;

namespace Asset.Scripts.PickUps
{
    public class MultiBall : AbstractPickUp
    {
        Ball ball;
        public override void ApplyEffect()
        {
            Ball ball = FindObjectOfType<Ball>();

            ball.Duplicate();
            ball.countOfBall += 1;
            print(ball.countOfBall);
        }
    }
}
