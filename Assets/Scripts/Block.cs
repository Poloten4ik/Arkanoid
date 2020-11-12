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
    public int hit;
    public Sprite[] nextImage;
    private SpriteRenderer currentImage;
    public int points;
    GameManager gameManager;
    Level levelManager;
    public ParticleSystem DestroyEffect;
    public GameObject pickupPrefab;

    public Color color;


    private void Start()
    {
        currentImage = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        levelManager = FindObjectOfType<Level>();
        levelManager.BlockCreated();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit--;

        if (hit == 0)
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
        Destroy(gameObject);
        levelManager.BlockDestroyed();
        SpawnDectroeEffect();

        Instantiate(pickupPrefab,transform.position,Quaternion.identity);

    }
    private void SpawnDectroeEffect()
    {
        Vector3 blockPos = gameObject.transform.position;
        Vector3 spawnPosition = new Vector3(blockPos.x, blockPos.y, blockPos.z);
        GameObject effect = Instantiate(DestroyEffect.gameObject, spawnPosition, Quaternion.identity);

        MainModule mm = effect.GetComponent<ParticleSystem>().main;

        mm.startColor = color;
        Destroy(effect, DestroyEffect.main.startLifetime.constant);

    }
}
