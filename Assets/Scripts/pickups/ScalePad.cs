using UnityEngine;

namespace Asset.Scripts.PickUps
{
    public class ScalePad : AbstractPickUp
    {
        public float x;

        public override void ApplyEffect()
        {
            Pad pad = FindObjectOfType<Pad>();
            pad.transform.localScale = new Vector2(x, pad.transform.localScale.y);
        }
    }

}
