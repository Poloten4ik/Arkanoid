using System.Linq;

namespace Asset.Scripts.PickUps
{
    public class MultiBall : AbstractPickUp
    {
        public override void ApplyEffect()
        {
            foreach (Ball balls in BallManager.Instance.Balls.ToList())
            {
                BallManager.Instance.SpawnBalls(balls.gameObject.transform.position, 2);
            }
        }
    }
}
