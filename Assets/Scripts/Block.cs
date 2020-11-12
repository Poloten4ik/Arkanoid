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
    private SpriteRenderer sr;

    public Sprite[] nextImage;
    private SpriteRenderer currentImage;
    public int points;
    GameManager gameManager;
    Level levelManager;
    public ParticleSystem DestroyEffect;

   
    private void Start()
    {
        this.sr = this.GetComponent<SpriteRenderer>();
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
                gameManager.AddScore(points);
                Destroy(gameObject);
                levelManager.BlockDestroyed();
            SpawnDectroeEffect();
            }
            else
            {
                currentImage.sprite = nextImage[hit - 1];
            }
    }

    private void SpawnDectroeEffect()
    {
        Vector3 blockPos = gameObject.transform.position;
        Vector3 spawnPosition = new Vector3(blockPos.x, blockPos.y, blockPos.z - 0.2f);
        GameObject effect = Instantiate(DestroyEffect.gameObject, spawnPosition, Quaternion.identity);

        MainModule mm = effect.GetComponent<ParticleSystem>().main;

        mm.startColor = this.sr.color;
        Destroy(effect, DestroyEffect.main.startLifetime.constant);

    }
}
