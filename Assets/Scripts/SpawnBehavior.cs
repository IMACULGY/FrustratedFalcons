using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Manages the spawning of new birds after
 * each turn and at the start of a level.
 */
public class SpawnBehavior : MonoBehaviour
{
    public GameObject newBird;
    bool hasBird = false;

    void FixedUpdate()
    {
        if (!hasBird && isStationary())
        {
            spawnBird();
        }
    }

    void spawnBird()
    {
        Instantiate(newBird, transform.position, Quaternion.identity);
        hasBird = true;
    }

    void OnTriggerExit2D(Collider2D co)
    {
        if (co.gameObject.tag == "Unlaunched")
        {
            //removeBirds();
            hasBird = false;
            co.gameObject.tag = "Launched";
            removeTrails();
            removeParticles();
        }
    }

    bool isStationary()
    {
        Rigidbody2D[] bodies = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
        foreach (Rigidbody2D rb in bodies)
            if (rb.velocity.sqrMagnitude > 5)
                return false;
        return true;
    }

    void removeTrails()
    {
        GameObject[] trails = GameObject.FindGameObjectsWithTag("Trail");
        foreach(GameObject trail in trails)
        {
            Destroy(trail);
        }
    }

    void removeParticles()
    {
        GameObject[] particles = GameObject.FindGameObjectsWithTag("Particle");
        foreach (GameObject p in particles)
        {
            Destroy(p);
        }
    }

    /*
    void removeBirds()
    {
        GameObject[] birds = GameObject.FindGameObjectsWithTag("Launched");
        foreach (GameObject b in birds)
        {
            Destroy(b);
        }
    }
    */
    

}
