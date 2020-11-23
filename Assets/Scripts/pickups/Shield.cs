namespace Asset.Scripts.PickUps
{
    public class Shield : AbstractPickUp
    {
        LoseGame loseGame;

        public override void ApplyEffect()
        {
            loseGame = FindObjectOfType<LoseGame>();
            loseGame.StartShield();
        }

    }
}
