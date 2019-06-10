using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Update the text in the top-left corner that shows
 * the number of birds the user has left to use.
 */
public class UpdateLifeText : MonoBehaviour
{
    //change the number of birds shown to the given value
    public void changeText(int num)
    {
        gameObject.GetComponent<Text>().text = "" + num;
    }
}