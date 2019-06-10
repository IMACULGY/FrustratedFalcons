using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Control the rubber bands for the catapult/slingshot 
 */
public class CatapultBandBehavior : MonoBehaviour
{
    public Transform leftband, rightband;

    void changeBand(Transform band, Transform bird, float offset)
    {
        //Calculate new vector for the scale of the given rubber band
        Vector2 dir = band.position - bird.position;
        //Find the direction of the vector between the bird and rubber band pivot
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //adjust the rotation of the rubber band based on the angle
        band.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        float dist = Vector3.Distance(bird.position, band.position);
        dist += bird.GetComponent<Collider2D>().bounds.extents.x;
        band.localScale = new Vector2(dist+offset, 1);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //Update the rubber bands while the bird stays in range of the slingshot
        changeBand(leftband, col.transform, 0.95f);
        changeBand(rightband, col.transform, 0.95f);
    }

    void OnTriggerExit2D(Collider2D col)
    { 
        //Revert rubber band scales after the bird is released.
        leftband.localScale = new Vector2(0, 1);
        rightband.localScale = new Vector2(0, 1);
    }
}
