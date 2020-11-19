using System.Linq;
using UnityEngine;

namespace Asset.Scripts.PickUps
{
    public class RestartBall : AbstractPickUp
    {
        public override void ApplyEffect()
        {
            Pad.Instance.magnetEffect = true;
            Pad.Instance.magnerPower = 3;
        }
    }
}

