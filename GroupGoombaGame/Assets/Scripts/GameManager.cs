using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.SceneTemplate;
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
    private bool[] minigamesWon;

    private int startDelay = 0;
    private int pauseKeyCount = 0;

    public GameObject canvas;
    public GameObject htpDisplay;
    public TextMeshProUGUI htpText;
    public TextMeshProUGUI pauseText;

    public SceneAsset mainHub;
    public SceneAsset thisScene;
    public SceneAsset[] minigameScenes;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        hasEnteredMinigame = true; // <----- with DontDestroyOnLoad, this could be an issue. It needs to be set to true when a minigame scene is loaded.
        minigamesWon = new bool[minigameScenes.Length];
        minigamesWon[currentMinigameIndex()] = hasWonCurrentMinigame;
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
            showHowToPlay(currentMinigameIndex());

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
                htpText.text = "Loading Main Hub";
                GameObject.FindGameObjectWithTag("Manager").GetComponent<BetweenScenes>().UpdateValues(SceneManager.GetSceneByName(thisScene.name));
                SceneManager.LoadScene(mainHub.name);
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
                showPauseText(currentMinigameIndex());
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
        htpstrings[1] = "Race to the Goal and Beat the Target Time.";

        return htpstrings;
    }

    string[] minigameControls()
    {
        string[] controlsStrings = new string[10];

        controlsStrings[0] = "Move Around: WASD Keys |OR| Arrow Keys" + "\n" + "Jump: [SPACEBAR]";
        controlsStrings[1] = "Move Around: WASD Keys |OR| Arrow Keys";

        return controlsStrings;
    }

    int currentMinigameIndex()
    {
        int result = 0;
        string currentSceneName = SceneManager.GetActiveScene().name;

        for (result = 0; result < (minigameScenes.Length - 1); result++)
        {
            if (currentSceneName.Equals(minigameScenes[result].ToString()))
            {
                break;
            }
        }
        return result;
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
        htpText.text = "You have won the Minigame: " + SceneManager.GetActiveScene().name + "\n" + "Press the [K] Key to Continue.";
        hasWonCurrentMinigame = true;

        //SceneManager.GetAllScenes
        //SceneManager.GetSceneByName
        //SceneManager.GetActiveScene().name

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
