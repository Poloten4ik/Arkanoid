using UnityEngine;

public class SpeedUp : PickUps
{
    public float newSpeed;
    public override void ApplyEffect()
    {
        BallManager.Instance.initialBallRb.AddForce(new Vector2(0, newSpeed));
    }
}
