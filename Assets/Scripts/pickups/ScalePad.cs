using UnityEngine;

public class ScalePad : PickUps
{
    public float x;

    public override void ApplyEffect()
    {
        Pad pad = FindObjectOfType<Pad>();
        pad.transform.localScale = new Vector2(x,pad.transform.localScale.y);
    }
}
