using UnityEngine;

namespace Asset.Scripts.PickUps
{
    public abstract class AbstractPickUp : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Pad"))
            {
                ApplyEffect();
            }
            if (collision.gameObject.CompareTag("Pad") || collision.gameObject.CompareTag("LoseGame"))
            {
                Destroy(gameObject);
            }
        }
        public abstract void ApplyEffect();
    }
}

