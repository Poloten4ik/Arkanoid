public class AddLifes : PickUps
{
    public override void ApplyEffect()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
     
        {
            if (gameManager.lives < 3)
            {
                gameManager.lives++;
                gameManager.HeartsUpdate();
            }
        }
    }
}
