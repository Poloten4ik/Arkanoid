using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUps : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pad"))
        {
            ApplyEffect();
        }
        if (collision.tag == "Pad" || collision.tag == "LoseGame")
        {
            Destroy(gameObject);
        }
        
    }
    public abstract void ApplyEffect();
}
