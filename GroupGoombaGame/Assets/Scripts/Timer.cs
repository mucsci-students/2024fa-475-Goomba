using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

//An int can be incremented/decremented by 50 for 1 second.
public class Timer : MonoBehaviour
{
    //Global Variable Declarations:
    //-----------------------------

    private Scene currentScene;

    public TextMeshProUGUI timeDisplay;

    public GameManager gameManager;

    //This bool only applies to the FireEnemies minigame.
    private bool enemyTouchedPlayer = false;

    private int timerValue;
    private int secondsLeft;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        Debug.Log("Timer's Start has been called.");

        if (currentScene.name.Equals("KartRacing"))
        {
            timerValue = 5000;
            secondsLeft = 100;
        }
        else if (currentScene.name.Equals("PenguinRacing"))
        {
            timerValue = 7500;
            secondsLeft = 150;
        }
        else if (currentScene.name.Equals("FireEnemies"))
        {
            timerValue = 10000;
            secondsLeft = 200;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //should this be secondsLeft, or timerValue && secondsLeft ?
        if ((timerValue > 0) && (secondsLeft > 0) && (gameManager.getHasWonCurrentMinigame() == false))
        {
            timerValue--;

            //timerValue will decrement by 50 for 1 second.
            if ((timerValue % 50) == 0)
            {
                secondsLeft--;
            }

            timeDisplay.text = "Seconds Left: " + secondsLeft.ToString();
        }
        //Losing Condition:
        else if ((secondsLeft <= 0) && ((currentScene.name.Equals("PenguinRacing")) || (currentScene.name.Equals("KartRacing"))))
        {
            gameManager.lostMinigame();
        }
        //Specific to FireEnemies minigame:
        else if ((secondsLeft <= 0) && (currentScene.name.Equals("FireEnemies")))
        {
            if (enemyTouchedPlayer == true)
            {
                gameManager.lostMinigame();
            }
            else
            {
                gameManager.setHasWonCurrentMinigame(true);
            }    
        }
        //Winning Condition could be somewhere else?
        //as for the kart racing minigame, the player should enter a collision zone and when they enter it, call: gameManager.setHasWonCurrentMinigame(true);
    }

    public void setSecondsLeft(int newSecondsLeft)
    {
        secondsLeft = newSecondsLeft;
    }

    public int getSecondsLeft()
    {
        return secondsLeft;
    }

    public void setEnemyTouchedPlayer(bool condition)
    {
        enemyTouchedPlayer = condition;
    }
}
