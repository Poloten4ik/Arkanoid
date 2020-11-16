public class RestartBall : PickUps
{
    public override void ApplyEffect()
    {
        Ball ball = FindObjectOfType<Ball>();
        ball.isStarted = false;
    }
}
