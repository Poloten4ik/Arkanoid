using System.Linq;
using UnityEngine;

namespace Asset.Scripts.PickUps
{
    public class RestartBall : AbstractPickUp
    {
        public override void ApplyEffect()
        {
            Pad.Instance.ActivatedMagner();
           // Pad.Instance.magnetPower = 3;
        }
    }
}

