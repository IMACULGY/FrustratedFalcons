using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Manages the trail of white smoke
 * that follows the bird as it launches.
 */
public class TrailBehavior : MonoBehaviour
{
    public GameObject[] trails;
    public float interval = 0.15f;
    int i;

    void Start()
    {
        //repeatedly spawn the trail.
        i = 0;
        InvokeRepeating("spawnTrail", interval, interval);
    }

    void spawnTrail()
    {
        //cycle through the three types of trails in order using an array
        if (GetComponent<Rigidbody2D>().velocity.sqrMagnitude > 25)
        {
            Instantiate(trails[i], transform.position, Quaternion.identity);
            i++;
            i %= trails.Length;
        }
    }
}
