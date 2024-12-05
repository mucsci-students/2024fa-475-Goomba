using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Global Variable Declarations:
    //-----------------------------

    public GameObject player;
    public GameObject freeLookCamera;

    //set to true when player first enters a minigame from the ice castle. if its true, show how to play the current minigame.
    private bool hasEnteredMinigame = false;
    private bool hasReadHTP;
    private bool delayInitialized = false;
    private bool isGamePaused;
    private bool hasWonCurrentMinigame = false;
    private bool[] minigamesWon;

    private int currentMinigameIndex;
    private int startDelay = 0;
    private int pauseKeyCount = 0;

    public GameObject canvas;
    public GameObject htpDisplay;
    public TextMeshProUGUI htpText;
    public TextMeshProUGUI pauseText;

    public SceneAsset mainHub;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
      //FOR TESTING PURPOSES (need to move these to another method. i want it to be called once: when hasEnteredMinigame = true.)
        hasEnteredMinigame = true;
        currentMinigameIndex = 0;
        minigamesWon = new bool[10];
        minigamesWon[currentMinigameIndex] = hasWonCurrentMinigame;
    }

    // Update is called once per frame
    void Update()
    {
        isGamePaused = Input.GetKeyDown(KeyCode.P);
        OnApplicationPause(isGamePaused);

        if (hasEnteredMinigame == true)
        {
            deactivate();
            //int minigameIndex;
            showHowToPlay(0);

            hasReadHTP = Input.GetKeyDown(KeyCode.K);
            if (hasReadHTP == true)
            {
                Debug.Log("K key has been pressed.");
                //not sure whether to put controls and how to play together or not.
                delayInitialized = true;
                hasEnteredMinigame = false;
                //activate();
                //htpDisplay.SetActive(false);
                hasReadHTP = false;
            }
        }
        else if (hasWonCurrentMinigame == true)
        {
            //wonMinigame(currentMinigameIndex);
            hasReadHTP = Input.GetKeyDown(KeyCode.K);
            if (hasReadHTP == true)
            {
                Debug.Log("K key has been pressed.");
                htpText.text = "Make me do something plz." + "\n" + "like taking me to the ice castle";
                SceneManager.LoadSceneAsync(mainHub.name);
            }
        }
    }

    void FixedUpdate()
    {
        if (delayInitialized == true)
        {
            startDelay++;

            if (startDelay == 1)
            {
                Debug.Log("3");
                htpText.text = "3";
            }
            if (startDelay == 50)
            {
                Debug.Log("2");
                htpText.text = "2";
            }
            if (startDelay == 100)
            {
                Debug.Log("1");
                htpText.text = "1";
            }
            if (startDelay == 150)
            {
                Debug.Log("Start Delay Complete.");
                showPauseText(currentMinigameIndex);
                activate();
                delayInitialized = false;
            }
        }
    }

    void activate()
    {
        player.SetActive(true);
        freeLookCamera.SetActive(true);
        canvas.SetActive(true);

        htpDisplay.SetActive(false);
    }

    void deactivate()
    {
        player.SetActive(false);
        freeLookCamera.SetActive(false);
        canvas.SetActive(false);

        htpDisplay.SetActive(true);
    }

    private void OnApplicationPause(bool pause)
    {
        //may need multiple conditions.
        if ((pause == true) && (hasEnteredMinigame == false))
        {
            pauseKeyCount++;
        }
        //Pauses the game.
        if (pauseKeyCount == 1)
        {
            //Debug.Log("Game Paused");
            deactivate();
        }
        //Unpauses the game.
        if (pauseKeyCount == 2)
        {
            activate();
            pause = false;
            pauseKeyCount = 0;
        }
    }

    //should be slightly different dependent on the minigame.
    void showHowToPlay(int minigameIndex)
    {
        htpDisplay.SetActive(true);
        string[] htpstrings = minigameHTPS();
        htpText.text = htpstrings[minigameIndex] + "\n" + "Press the [K] Key to Continue.";
    }

    void showPauseText(int minigameIndex)
    {
        htpText.text = "Paused";
        pauseText.text = "How To Play: " + "\n" + (minigameHTPS()[minigameIndex]) + "\n" + "\n" + "Controls: " + "\n" + (minigameControls()[minigameIndex]);
    }

    string[] minigameHTPS()
    {
        string[] htpstrings = new string[10];
        htpstrings[0] = "Collect the Key to Open the Chest.";

        return htpstrings;
    }

    string[] minigameControls()
    {
        string[] controlsStrings = new string[10];

        controlsStrings[0] = "Move Around: WASD Keys |OR| Arrow Keys" + "\n" + "Jump: [SPACEBAR]";

        return controlsStrings;
    }

    string[] minigameNames()
    {
        string[] minigameStrings = new string[10];

        minigameStrings[0] = "Test";

        return minigameStrings;
    }


    //Minigame winning code: (messy wip)
    //**************************************************************************************************************

    //called when a minigame is won.
    public void wonMinigame(int minigameIndex)
    {
        Debug.Log("wonMinigame has been called.");
        minigamesWon[minigameIndex] = true;
        deactivate();
        pauseText.text = "";
        htpText.text = "You have won the Minigame: " + minigameNames()[minigameIndex] + "\n" + "Press the [K] Key to Continue.";
        hasWonCurrentMinigame = true;

        //switch statement instead of else ifs. <<--- maybe do this if there will be seperate methods for each minigame.
        //if (minigameIndex == 0)
        //{

        //}
    }

    //Winning Different Minigames:
    //*************************************************************************************************************

    //determines if the test minigame has been won. (seperate methods for each because each objective is different.) ????

    //bool hasWonGame0()
    //{
        
        //hasWonCurrentMinigame = true;
        //return hasWonCurrentMinigame;
    //}
}
