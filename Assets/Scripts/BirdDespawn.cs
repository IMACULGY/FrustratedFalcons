using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Despawn the bird if it is moving slow enough,
 * has been launched and has collided for the first time.
 */

public class BirdDespawn : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.tag == "Launched" || gameObject.GetComponent<OnFirstCollision>().hasCollided)
        {

            
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            if (rb.velocity.sqrMagnitude < 0.05) 
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

                //Despawn the bird
                Destroy(gameObject);
            }
        }
    }



}
