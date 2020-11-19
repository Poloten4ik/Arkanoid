using System.Linq;
namespace Asset.Scripts.PickUps
{
    public class SpeedDown : AbstractPickUp
    {
        public override void ApplyEffect()
        {
            for (int i = 0; i < BallManager.Instance.Balls.Count; i++)
            {
                BallManager.Instance.Balls[i].SpeedDown();
                print(BallManager.Instance.Balls.Count);
            }
        }
    }
}

