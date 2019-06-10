using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Secret room that closes the
 * game 5-10 seconds after entry
 */
public class SecretRoom : MonoBehaviour
{
    public int frames = 0;

    // Start is called before the first frame update
    void Update()
    {
        frames++;
        if (frames > 300)
            Application.Quit();
    }
}
