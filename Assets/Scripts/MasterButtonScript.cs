using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Houses the methods that all the buttons use, including
 * changing the displayed scene and zooming out the camera.
 */
public class MasterButtonScript : MonoBehaviour
{
    public int numClicks = 0;

    public void onChangeScene(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void secretButton()
    {
        numClicks++;
        if (numClicks >= 19)
            Application.LoadLevel("Secret");
    }

    public void zoomButton(GameObject button)
    {
        button.SetActive(true);
        GameObject otherButton;
        if (button.tag == "ZoomOut")
            otherButton = GameObject.FindWithTag("ZoomIn");
        else
            otherButton = GameObject.FindWithTag("ZoomOut");
        otherButton.SetActive(false);
    }
}
