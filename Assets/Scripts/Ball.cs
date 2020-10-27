using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        print("qwe");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("trigger");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print("trigger exit");
    }
}
