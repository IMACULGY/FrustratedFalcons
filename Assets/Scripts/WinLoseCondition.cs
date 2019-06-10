using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Check for win and loss conditions for each level,
 * and trigger UI screens when conditions are fulfilled.
 */
public class WinLoseCondition : MonoBehaviour
{
    public int numBirds; //different for each level
    public GameObject winScreen, gameOverScreen, quit, restart, zoomOut, zoomIn, image, text;

    void Start()
    {
        GameObject.FindWithTag("LifeText").GetComponent<UpdateLifeText>().changeText(numBirds);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            //If there are no enemies, win
            Win();
            Destroy(this);
        }
        else if (this.numBirds == -1)
        {
            //If there are no birds, lose.
            GameOver();
            Destroy(this);
        }
    }

    void GameOver()
    {
        //Deactivate all UI elements except for the game over screen
        gameOverScreen.SetActive(true);
        quit.SetActive(false);
        restart.SetActive(false);
        zoomOut.SetActive(false);
        zoomIn.SetActive(false);
        image.SetActive(false);
        text.SetActive(false);
    }

    void Win()
    {
        //Deactivate all UI elements except for the win screen
        winScreen.SetActive(true);
        quit.SetActive(false);
        restart.SetActive(false);
        zoomOut.SetActive(false);
        zoomIn.SetActive(false);
        image.SetActive(false);
        text.SetActive(false);
    }

    public void setNumBirds(int num)
    {
        //adjust the number of birds to given value.
        numBirds = num;
    }
}
