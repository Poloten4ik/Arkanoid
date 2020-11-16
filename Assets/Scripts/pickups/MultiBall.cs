public class MultiBall : PickUps 
{
    public override void ApplyEffect()
    {
        Ball ball = FindObjectOfType<Ball>();

        for (int i = 0; i < 2; i++)
        {
            Instantiate(ball);
            //ball.isStarted = true;
            ball.StartBall();
        }
    }
}
