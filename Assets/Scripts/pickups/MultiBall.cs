using System.Linq;
public class MultiBall : PickUps
{
    public override void ApplyEffect()
    {
        foreach (Ball balls in BallManager.Instance.Balls.ToList())
        {
            BallManager.Instance.SpawnBalls(balls.gameObject.transform.position, 2);
        }   
    }
}