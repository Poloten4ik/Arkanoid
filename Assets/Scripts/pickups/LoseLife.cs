public class LoseLife : PickUps
{
    public override void ApplyEffect()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        {
            gameManager.lives--;
            gameManager.HeartsUpdate();

            if (gameManager.lives <= 0)
            {
                gameManager.GameOver();
            }

        }
    }
}