using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

//Class should NOT be used in MainHub. Create a seperate class to manage the MainHub.
public class GameManager : MonoBehaviour
{
    //Global Variable Declarations:
    //-----------------------------

    public GameObject player;
    public GameObject freeLookCamera;

    private bool hasEnteredMinigame = false;
    private bool hasReadHTP;
    private bool delayInitialized = false;
    private bool isGamePaused;
    private bool hasWonCurrentMinigame = false;
    private bool hasLostCurrentMinigame = false;

    private int startDelay = 0;
    private int pauseKeyCount = 0;
    public int currentMinigameIndex;

    public GameObject canvas;
    public GameObject htpDisplay;
    public TextMeshProUGUI htpText;
    public TextMeshProUGUI pauseText;

    private Scene thisScene;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        hasEnteredMinigame = true; // <----- with DontDestroyOnLoad, this could be an issue. It needs to be set to true when a minigame scene is loaded.
        thisScene = SceneManager.GetActiveScene();
        //everything should be false by default.
        //minigamesWon = new bool[minigameScenes.Length];
        //minigamesWon[currentMinigameIndex()] = hasWonCurrentMinigame;
        //DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        isGamePaused = Input.GetKeyDown(KeyCode.P);
        OnApplicationPause(isGamePaused);

        if (hasEnteredMinigame == true)
        {
            deactivate();
            showHowToPlay(currentMinigameIndex);

            hasReadHTP = Input.GetKeyDown(KeyCode.K);
            if (hasReadHTP == true)
            {
                Debug.Log("K key has been pressed.");

                delayInitialized = true;
                hasEnteredMinigame = false;
                hasReadHTP = false;
            }
        }
        else if (hasWonCurrentMinigame == true)
        {
            wonMinigame(currentMinigameIndex);
            hasReadHTP = Input.GetKeyDown(KeyCode.K);
            if (hasReadHTP == true)
            {
                Debug.Log("K key has been pressed.");
                htpText.text = "Loading Main Hub";
                SceneManager.LoadScene("MainHub");
            }
        }
        else if (hasLostCurrentMinigame == true)
        {
            bool isRetry = Input.GetKeyDown(KeyCode.C);

            //being used for main hub:
            hasReadHTP = Input.GetKeyDown(KeyCode.K);
            if (hasReadHTP == true)
            {
                Debug.Log("K key has been pressed.");
                htpText.text = "Loading Main Hub";
                SceneManager.LoadScene("MainHub");

                hasLostCurrentMinigame = false;
                //hasWonCurrentMinigame = false;
            }
            else if (isRetry == true)
            {
                Debug.Log("C key has been pressed.");
                htpText.text = "Loading Minigame";
                SceneManager.LoadScene(thisScene.name);

                hasLostCurrentMinigame = false;
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

    void showHowToPlay(int minigameIndex)
    {
        htpDisplay.SetActive(true);
        htpText.text = minigameHTPS()[minigameIndex] + "\n" + "Press the [K] Key to Continue.";
    }

    void showPauseText(int minigameIndex)
    {
        htpText.text = "Paused";
        pauseText.text = "How To Play: " + "\n" + (minigameHTPS()[minigameIndex]) + "\n" + "\n" + "Controls: " + "\n" + (minigameControls()[minigameIndex]);
    }

    string[] minigameHTPS()
    {
        string[] htpstrings = new string[10];

        //Movement
        htpstrings[0] = "Collect the Key to Open the Chest.";
        //KartRacing
        htpstrings[1] = "Race to the Goal and Beat the Target Time."; //collect coins to extend time?
        //PenguinRacing
        htpstrings[2] = htpstrings[1];
        //FireEnemies
        htpstrings[3] = "Avoid all Fire Enemies" + "\n" + "Until the Time runs out.";

        return htpstrings;
    }

    string[] minigameControls()
    {
        string[] controlsStrings = new string[10];

        controlsStrings[0] = "Move Around: WASD Keys |OR| Arrow Keys" + "\n" + "Jump: [SPACEBAR]" + "\n" + "Dash: [LEFT SHIFT]";
        //controlsStrings[1] = "Move Around: WASD Keys |OR| Arrow Keys";
        controlsStrings[1] = controlsStrings[0];
        controlsStrings[2] = "Move Around: WASD Keys |OR| Arrow Keys";
        controlsStrings[3] = controlsStrings[0];

        return controlsStrings;
    }


    //Minigame Winning/Losing:
    //**************************************************************************************************************

    //called when a minigame is won.
    public void wonMinigame(int minigameIndex)
    {
        BetweenScenes between = GameObject.FindGameObjectWithTag("Between").GetComponent<BetweenScenes>();
        between.UpdateMinigameWon(minigameIndex);

        deactivate();
        pauseText.text = "";
        htpText.text = "You have won the Minigame: " + SceneManager.GetActiveScene().name + "\n" + "Press the [K] Key to Continue.";
    }

    public void setHasWonCurrentMinigame(bool condition)
    {
        hasWonCurrentMinigame = condition;
    }

    public bool getHasWonCurrentMinigame()
    {
        return hasWonCurrentMinigame;
    }

    public void lostMinigame()
    {
        //Debug.Log("lostMinigame has been called.");
        deactivate();
        pauseText.text = "";
        htpText.text = "You have lost the Minigame: " + SceneManager.GetActiveScene().name + "\n" + "\n" + "Press the [K] Key to Continue to Main Hub." + "\n" + "Press the [C] Key to Try Again.";
        //make sure this gets reset to false:
        hasLostCurrentMinigame = true;
    }
}
