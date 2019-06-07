using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    //public float size = 0.1f;
    //public float x = 0.1f;
    //public float y = 0.1f;
    //public float maxZoomY = 2.6f;

    public Vector3 origPos = new Vector3(1f, 0f, -10f);

    public void revertCamera()
    {
        Vector3 origPos = new Vector3(1f, 0f, -10f);
        float origSize = 5f;
        gameObject.transform.position = origPos;
        GetComponent<Camera>().orthographicSize = origSize;
    }

    public void zoomOut()
    {
        Vector3 zoomPos = new Vector3(8.9f, 4.37f, -10f);
        float zoomSize = 10.22104f;
        gameObject.transform.position = zoomPos;
        GetComponent<Camera>().orthographicSize = zoomSize;
    }

    void LateUpdate()
    {
        GameObject bird = GameObject.FindWithTag("Launched");

        if (bird != null && !bird.GetComponent<OnFirstCollision>().hasCollided)
        {
            Vector3 offset = bird.transform.position - transform.position;
            offset.z = 0;
            //update camera position based on bird position
            if (offset.x <= 0 || bird.transform.position.x < 1)
                offset.x = 0;
            if (offset.y == 0 || bird.transform.position.y < 0)
                offset.y = 0;
            gameObject.transform.position = gameObject.transform.position + offset;
        }
    }

    /*void LateUpdate()
    {
        GameObject bird = GameObject.FindWithTag("Launched");
        gameObject.transform.position = bird.transform.position + new Vector3(0, 0, -10);
    }*/
}
