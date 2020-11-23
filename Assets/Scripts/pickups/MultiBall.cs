using System.Linq;

namespace Asset.Scripts.PickUps
{
    public class MultiBall : AbstractPickUp
    {
        public override void ApplyEffect()
        {
            Ball ball = FindObjectOfType<Ball>();
            ball.Duplicate();
        }
    }
}
