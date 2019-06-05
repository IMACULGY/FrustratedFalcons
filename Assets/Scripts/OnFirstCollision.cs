using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFirstCollision : MonoBehaviour
{
    public GameObject particles;
    public bool hasCollided = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!hasCollided)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            hasCollided = true;
        }
    }
}
