using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultBandBehavior : MonoBehaviour
{
    public Transform leftband, rightband;

    void changeBand(Transform band, Transform bird, float offset)
    {
        Vector2 dir = band.position - bird.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        band.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        float dist = Vector3.Distance(bird.position, band.position);
        dist += bird.GetComponent<Collider2D>().bounds.extents.x;
        band.localScale = new Vector2(dist+offset, 1);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        changeBand(leftband, col.transform, 0.95f);
        changeBand(rightband, col.transform, 0.95f);
    }

    void OnTriggerExit2D(Collider2D col)
    { 
        leftband.localScale = new Vector2(0, 1);
        rightband.localScale = new Vector2(0, 1);
    }
}
