using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    float yPosition;
    void Start()
    {
        yPosition = transform.position.y;
    }

    void Update()
    {
        Vector3 mousePixelPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPosition);


        Vector3 padNewposition = mouseWorldPosition;
        padNewposition.z = 0;
        padNewposition.y = yPosition;


        transform.position = padNewposition;
    }
}
