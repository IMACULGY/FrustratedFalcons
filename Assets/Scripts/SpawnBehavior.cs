using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Manages the spawning of new birds after
 * each turn and at the start of a level, as
 * well as other functions that result from a new
 * bird spawn.
 */
public class SpawnBehavior : MonoBehaviour
{
    public GameObject newBird;
    public bool hasBird = false;
    public int numBirds;

    void Start()
    {
        GameObject[] camera = GameObject.FindGameObjectsWithTag("MainCamera");
        numBirds = camera[0].GetComponent<WinLoseCondition>().numBirds;
    }

    void FixedUpdate()
    {
        if (numBirds > 0)
        {
            if (!hasBird && isStationary())
            {
                spawnBird();

                //update number of unused birds
                numBirds = numBirds - 1;
                GameObject[] camera = GameObject.FindGameObjectsWithTag("MainCamera");
                camera[0].GetComponent<WinLoseCondition>().setNumBirds(numBirds+1);
                GameObject.FindWithTag("LifeText").GetComponent<UpdateLifeText>().changeText(numBirds+1);
            }
        }
        else
        {

        }



    }

    void spawnBird()
    {
        //Create a new bird using the bird prefab.
        Instantiate(newBird, transform.position, Quaternion.identity);
        hasBird = true;
    }

    void OnTriggerExit2D(Collider2D co)
    {
        if (co.gameObject.tag == "Unlaunched")
        {
            //Update necessary values once the bird leaves the slingshot
            hasBird = false;
            co.gameObject.tag = "Launched";

            //Remove particles generated from the previous bird
            removeTrails();
            removeParticles();
        }
    }

    bool isStationary()
    {
        //The scene is stationary if none of the objects are moving at a significant speed
        Rigidbody2D[] bodies = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
        foreach (Rigidbody2D rb in bodies)
            if (rb.velocity.sqrMagnitude > 5)
                return false;
        return true;
    }

    void removeTrails()
    {
        //Find all trails (white smoke) and destroy them.
        GameObject[] trails = GameObject.FindGameObjectsWithTag("Trail");
        foreach(GameObject trail in trails)
        {
            Destroy(trail);
        }
    }

    void removeParticles()
    {
        //Find all particles (feathers) and destroy them.
        GameObject[] particles = GameObject.FindGameObjectsWithTag("Particle");
        foreach (GameObject p in particles)
        {
            Destroy(p);
        }
    }

    

}
