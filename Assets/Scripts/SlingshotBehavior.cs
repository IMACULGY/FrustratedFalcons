using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotBehavior : MonoBehaviour
{
    Vector2 startPos;
    public float force = 1000;
    public float radius = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    void OnMouseUp()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        Vector2 dir = startPos - (Vector2)transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir * force);
        Destroy(this);

    }

    void OnMouseDrag()
    {
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       
        Vector2 dir = p - startPos;
        if (dir.sqrMagnitude > radius)
            dir = dir.normalized * radius;

        transform.position = startPos + dir;
    }

}
