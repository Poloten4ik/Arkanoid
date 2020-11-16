using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    public GameObject increasesScorePrefab;
    public GameObject decreasesScorePrefab;
    public GameObject multiBallPrefab;
    public GameObject scaleIncreases;
    public GameObject scaleDecreases;
    public GameObject ballScaleIncreases;
    public GameObject ballScaleDecreases;
    public GameObject restartBall;
    public GameObject addLife;
    public GameObject loseLife;
    public GameObject speedUp;

    [Range(0, 100)]
    public float PickUpChange;
    [Range(0,100)]
    public float BuffChance;
    [Range(0, 100)]
    public float Debuff;
}
