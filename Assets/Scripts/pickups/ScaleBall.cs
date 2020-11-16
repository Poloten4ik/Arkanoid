using UnityEngine;

public class ScaleBall : PickUps
{
    public float x;
    public float y;
    public override void ApplyEffect()
    {   
        Ball ball = FindObjectOfType<Ball>();
        ball.transform.localScale = new Vector2(x, y);
    }
}
