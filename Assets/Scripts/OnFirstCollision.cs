using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFirstCollision : MonoBehaviour
{
    public GameObject particles;

    void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(this);
    }
}
