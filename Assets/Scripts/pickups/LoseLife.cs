namespace Asset.Scripts.PickUps
{
    public class LoseLife : AbstractPickUp
    {
        public override void ApplyEffect()
        {
            GameManager.Instance.LoseLife();
        }
    }
}
