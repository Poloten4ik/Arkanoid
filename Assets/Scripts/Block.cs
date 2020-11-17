using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class Block : MonoBehaviour
{
    public int hit = 1;
    public Sprite[] nextImage;
    private SpriteRenderer currentImage;
    public int points;
    GameManager gameManager;
    Level levelManager;
    public ParticleSystem destroyEffectPrefab;
    CollectablesManager collectablesManager;
    public Color color;


    private void Start()
    {
        currentImage = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        levelManager = FindObjectOfType<Level>();
        levelManager.BlockCreated();

        collectablesManager = FindObjectOfType<CollectablesManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit--;

        if (hit <= 0)
        {
            DestroyBlock();
        }
        else
        {
            currentImage.sprite = nextImage[hit - 1];
        }
    }



    private void DestroyBlock()
    {
        gameManager.AddScore(points);
        levelManager.BlockDestroyed();
        SpawnDectroeEffect();
        Change();
        Destroy(gameObject);
    }

    private void Change()
    {
        float buffSpawnChange = UnityEngine.Random.Range(0, 100);
        float deBuffSpawnChange = UnityEngine.Random.Range(0, 100f);
        bool alreadySpawned = false;


        if (buffSpawnChange <= collectablesManager.BuffChance)
        {
            alreadySpawned = true;
            PickUps newBuff = SpawnPickUps(true);
        }

        if (deBuffSpawnChange <= collectablesManager.DebuffChance && !alreadySpawned)
        {
            PickUps newDebuff = SpawnPickUps(false);
        }
    }

    private PickUps SpawnPickUps(bool isBuff)
    {
        List<PickUps> collection;
        if (isBuff)
        {
            collection = collectablesManager.AvailableBuffs;
        }
        else
        {
            collection = collectablesManager.AvailableDeBuffs;
        }
        int buffIndex = UnityEngine.Random.Range(0, collection.Count);
        PickUps prefab = collection[buffIndex];
        PickUps newCollectable = Instantiate(prefab, this.transform.position, Quaternion.identity);
        return newCollectable;
    }
    private void SpawnDectroeEffect()
    {
        Vector3 blockPos = gameObject.transform.position;
        Vector3 spawnPosition = new Vector3(blockPos.x, blockPos.y, blockPos.z + 0.1f);
        GameObject effect = Instantiate(destroyEffectPrefab.gameObject, spawnPosition, Quaternion.identity);

        MainModule mm = effect.GetComponent<ParticleSystem>().main;
        mm.startColor = color;

        Destroy(effect, destroyEffectPrefab.main.startLifetime.constant);
    }
}
