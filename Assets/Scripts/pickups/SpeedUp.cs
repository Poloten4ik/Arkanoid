using UnityEngine;

public class SpeedUp : PickUps
{
    public float newSpeed;
    public override void ApplyEffect()
    {
        Ball ball = FindObjectOfType<Ball>();
        Vector2 force = new Vector2(ball.transform.localPosition.x, ball.transform.localPosition.y);
        ball.rb.velocity = force * newSpeed; 
    }
}
