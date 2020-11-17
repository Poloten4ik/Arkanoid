using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{

    public List<PickUps> AvailableBuffs;
    public List<PickUps> AvailableDeBuffs;

    [Range(0,100)]
    public float BuffChance;
    [Range(0, 100)]
    public float DebuffChance;

}
