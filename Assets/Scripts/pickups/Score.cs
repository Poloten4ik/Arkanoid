public class Score : PickUps
{
    public int points;
    public override void ApplyEffect()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.AddScore(points);
    }
}
