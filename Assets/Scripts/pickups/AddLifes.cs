public class AddLifes : PickUps
{
    public override void ApplyEffect()
    {
        GameManager.Instance.AddLife();  
    }
}
