using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBehavior : MonoBehaviour
{
    public float forceNeeded = 1000;

    float collisionForce(Collision2D col)
    {
        float speed = col.relativeVelocity.sqrMagnitude;
        if (col.collider.GetComponent<Rigidbody2D>())
            return speed * col.collider.GetComponent<Rigidbody2D>().mass;
        return speed;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (collisionForce(coll) >= forceNeeded)
            Destroy(gameObject);
    }
}
