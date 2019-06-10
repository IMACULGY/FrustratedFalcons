using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Camera functions for the game, including methods
 * for following the player as it moves
 * and zooming the camera in and out.
 */
public class CameraZoom : MonoBehaviour
{

    public Vector3 origPos = new Vector3(1f, 0f, -10f);
    public bool zoomed = false;

    public void revertCamera()
    {
        //Original coordinates and size for the camera
        Vector3 origPos = new Vector3(1f, 0f, -10f);
        float origSize = 5f;

        //Set values to the original
        gameObject.transform.position = origPos;
        GetComponent<Camera>().orthographicSize = origSize;
        zoomed = false;
    }

    public void zoomOut()
    {
        //Zoomed-out coordinates and size for the camera
        Vector3 zoomPos = new Vector3(8.9f, 4.37f, -10f);
        float zoomSize = 10.22104f;

        //Set values to the zoomed-out ones
        gameObject.transform.position = zoomPos;
        GetComponent<Camera>().orthographicSize = zoomSize;
        zoomed = true;
    }

    void LateUpdate()
    {
        GameObject bird = GameObject.FindWithTag("Launched");

        //Camera will follow the bird as long as it has been launched and has not collided for the first time
        if (!zoomed && bird != null && !bird.GetComponent<OnFirstCollision>().hasCollided)
        {
            //Calculate the offset between the bird's location and the camera's location.
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
}
