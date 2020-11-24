using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asset.Scripts.PickUps
{
    public class CollectablesManager : MonoBehaviour
    {
        public List<AbstractPickUp> AvailableBuffs;
        public List<AbstractPickUp> AvailableDeBuffs;

        [Range(0, 100)]
        public float BuffChance;
        [Range(0, 100)]
        public float DebuffChance;
    }
}