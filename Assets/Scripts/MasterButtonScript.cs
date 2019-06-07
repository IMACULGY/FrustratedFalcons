using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
