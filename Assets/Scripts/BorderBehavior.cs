using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Destroy an object if it crosses the borders.
 */
public class BorderBehavior : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Launched")
        {
            //The camera will only be set back if it is not zoomed out
            GameObject[] camera = GameObject.FindGameObjectsWithTag("MainCamera");
            if (!camera[0].GetComponent<CameraZoom>().zoomed)
                camera[0].GetComponent<CameraZoom>().revertCamera();

            //Communicate with game over script as long as all birds have been fired and ready to despawn
            GameObject slingshot = GameObject.Find("slingshot");
            GameObject[] birds1 = GameObject.FindGameObjectsWithTag("Launched");
            GameObject[] birds2 = GameObject.FindGameObjectsWithTag("Unlaunched");
            if (slingshot.GetComponent<SpawnBehavior>().numBirds == 0 && birds1.Length + birds2.Length == 1)
                camera[0].GetComponent<WinLoseCondition>().numBirds = -1;
        }
        //Despawn the object (even if it is not a bird)
        Destroy(col.gameObject);
        
    }
}
