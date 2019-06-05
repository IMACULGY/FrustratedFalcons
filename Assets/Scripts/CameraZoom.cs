using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    //public float size = 0.1f;
    //public float x = 0.1f;
    //public float y = 0.1f;
    //public float maxZoomY = 2.6f;

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

    public void followPlayer()
    {
        GameObject[] bird = GameObject.FindGameObjectsWithTag("Launched");
        if(!bird[0].GetComponent<OnFirstCollision>().hasCollided)
        {
            //update camera position based on bird position
            Vector3 cameraPos = new Vector3(1, 0, -10);
            if (bird[0].transform.position.x > gameObject.transform.position.x)
                cameraPos += new Vector3(bird[0].transform.position.x, 0, 0);
            if (bird[0].transform.position.y > gameObject.transform.position.y)
                cameraPos += new Vector3(0, bird[0].transform.position.y, 0);
            gameObject.transform.position = cameraPos;
            followPlayer();
        }
    }
}
