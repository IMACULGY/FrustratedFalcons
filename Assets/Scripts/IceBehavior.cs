using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Used for objects that will be destroyed when an object
 * exerts enough force on it (enemies and ice blocks)
 */
public class IceBehavior : MonoBehaviour
{
    public float forceNeeded = 1000;

    float collisionForce(Collision2D col)
    {
        //estimate the force using speed * mass
        float speed = col.relativeVelocity.sqrMagnitude;
        if (col.collider.GetComponent<Rigidbody2D>())
            return speed * col.collider.GetComponent<Rigidbody2D>().mass;
        return speed;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //destroy the object if a collision exerts enough force.
        if (collisionForce(coll) >= forceNeeded)
            Destroy(gameObject);
    }
}
