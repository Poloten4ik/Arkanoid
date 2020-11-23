﻿using Asset.Scripts.PickUps;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace Asset.Scripts
{
    public class Block : MonoBehaviour
    {
        public int hit = 1;
        public Sprite[] nextImage;
        private SpriteRenderer currentImage;
        public int points;
        GameManager gameManager;
        Level levelManager;
        Ball ball;
        public ParticleSystem destroyEffectPrefab;
        CollectablesManager collectablesManager;
        public Color color;

        public float explosionRadius;
        public bool explosion;

        private void Start()
        {
            currentImage = GetComponent<SpriteRenderer>();
            gameManager = FindObjectOfType<GameManager>();
            levelManager = FindObjectOfType<Level>();
            levelManager.BlockCreated();
            ball = FindObjectOfType<Ball>();
            collectablesManager = FindObjectOfType<CollectablesManager>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            hit--;
            if (hit <= 0 || ball.isElectricityBall)
            {
                DestroyBlock();
            }
            else
            {
                currentImage.sprite = nextImage[hit - 1];
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (ball.isElectricityBall)
            {
                DestroyBlock();
            }
        }

        public void DestroyBlock()
        {
            gameManager.AddScore(points);
            levelManager.BlockDestroyed();
            SpawnDectroeEffect();
            Change();
            Destroy(gameObject);

            if (explosion)
            {
                Explode();
            }
        }

        private void Change()
        {
            float buffSpawnChange = Random.Range(0, 100);
            float deBuffSpawnChange = Random.Range(0, 100f);


            if (buffSpawnChange < collectablesManager.BuffChance)
            {
                SpawnPickUps(true);
            }

            if (deBuffSpawnChange < collectablesManager.DebuffChance)
            {
                SpawnPickUps(false);
            }
        }

        private AbstractPickUp SpawnPickUps(bool isBuff)
        {
            List<AbstractPickUp> collection;
            if (isBuff)
            {
                collection = collectablesManager.AvailableBuffs;
            }
            else
            {
                collection = collectablesManager.AvailableDeBuffs;
            }
            int buffIndex = Random.Range(0, collection.Count);
            AbstractPickUp prefab = collection[buffIndex];
            AbstractPickUp newCollectable = Instantiate(prefab, this.transform.position, Quaternion.identity);
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

        private void Explode()
        {
            int layerMask = LayerMask.GetMask("Block");

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, layerMask);

            foreach (Collider2D collider in colliders)
            {
                Block block = collider.GetComponent<Block>();
                if (block == null)
                {
                    Destroy(collider.gameObject);
                }
                else
                {
                    block.DestroyBlock();
                }
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
}
