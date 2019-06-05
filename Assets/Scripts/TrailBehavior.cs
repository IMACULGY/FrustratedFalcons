using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailBehavior : MonoBehaviour
{
    public GameObject[] trails;
    public float interval = 0.15f;
    int i;

    void Start()
    {
        i = 0;
        InvokeRepeating("spawnTrail", interval, interval);
    }

    void spawnTrail()
    {
        if (GetComponent<Rigidbody2D>().velocity.sqrMagnitude > 25)
        {
            Instantiate(trails[i], transform.position, Quaternion.identity);
            i++;
            i %= trails.Length;
        }
    }
}
