namespace Asset.Scripts.PickUps
{
 public class AddLifes : AbstractPickUp
    {
        public override void ApplyEffect()
        {
            GameManager.Instance.AddLife();
        }
    }
}
