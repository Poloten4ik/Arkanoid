using UnityEngine;

public class ScaleBall : PickUps
{
    public float x;
    public float y;
    public override void ApplyEffect()
    {   
        Ball[] ball = FindObjectsOfType<Ball>();
        for( int i = 0; i < ball.Length; i++)
        {
            ball[i].transform.localScale = new Vector2(x, y);
        }
    }   
}
