public class LoseLife : PickUps
{
    public override void ApplyEffect()
    {
        GameManager.Instance.LifeLose();
    }
}