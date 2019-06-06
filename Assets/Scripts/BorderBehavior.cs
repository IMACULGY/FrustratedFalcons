using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBehavior : MonoBehaviour
{
    //If an object goes past the borders, destroy it
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Launched")
        {
            GameObject[] camera = GameObject.FindGameObjectsWithTag("MainCamera");
            camera[0].GetComponent<CameraZoom>().revertCamera();
        }
        Destroy(col.gameObject);
        
    }
}
