using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.SceneManagement;

//Should this class be called in GameManager?
public class Timer : MonoBehaviour
{
    //Global Variable Declarations:
    //-----------------------------

    public SceneAsset currentScene;

    public TextMeshProUGUI timeDisplay;

    public GameManager gameManager;

    //private bool isKartRacing;

    private int timerValue;
    private int secondsLeft;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Timer's Start has been called.");

        if (currentScene.name.Equals("KartRacing"))
        {
            //isKartRacing = true;
            timerValue = 5000;
            secondsLeft = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //should this be secondsLeft, or timerValue && secondsLeft ?
        if ((timerValue > 0) && (gameManager.getHasWonCurrentMinigame() == false))
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
        else if (secondsLeft == 0)
        {
            //what happens when the player loses the game?
            //Debug.Log("Time is Up.");
            gameManager.lostMinigame();
        }
        //Winning Condition could be somewhere else?
        //as for the kart racing minigame, the player should enter a collision zone and when they enter it, call: gameManager.setHasWonCurrentMinigame(true);
    }
}
