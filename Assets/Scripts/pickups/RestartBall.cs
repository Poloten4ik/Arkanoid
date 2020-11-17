using System.Linq;
using UnityEngine;

public class RestartBall : PickUps
{
    public override void ApplyEffect()
    {

        foreach (var ball in BallManager.Instance.Balls.ToList())
        {
            GameManager.Instance.isStarted = false;
            BallManager.Instance.initialBallRb.velocity = Vector2.zero;
        }
     
    }
}
