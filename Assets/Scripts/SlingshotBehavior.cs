using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Moves the bird around the slingshot as the mouse is held
 * and launches it by applying force once it is released.
 */
public class SlingshotBehavior : MonoBehaviour
{
    Vector2 startPos;
    public float force = 1000;
    public float radius = 1.2f;
    AudioSource clip;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    void OnMouseUp()
    {
        //Add force to the bird to launch it.
        GetComponent<Rigidbody2D>().isKinematic = false;
        Vector2 dir = startPos - (Vector2)transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir * force);

        //Play audio when it is launched.
        GetComponent<AudioSource>().Play();

        //Destroy the script
        Destroy(this);

    }

    void OnMouseDrag()
    {
        //fetch the mouse position on the screen.
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       //if the mouse position exceeds the radius, default to the point within the radius closest to the mouse position.
        Vector2 dir = p - startPos;
        if (dir.sqrMagnitude > radius)
            dir = dir.normalized * radius;

        transform.position = startPos + dir;
    }

}
