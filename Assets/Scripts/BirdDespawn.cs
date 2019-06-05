using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDespawn : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.tag == "Launched")
        {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            if (rb.velocity.sqrMagnitude < 0.1)
                Destroy(gameObject);
        }
    }
}
