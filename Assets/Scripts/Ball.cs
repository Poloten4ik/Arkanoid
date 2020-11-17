using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    public Collider2D colliderBall;
    public void Die()
    {
        GameManager.Instance.LoseLife();
        Destroy(gameObject);
    }
}
