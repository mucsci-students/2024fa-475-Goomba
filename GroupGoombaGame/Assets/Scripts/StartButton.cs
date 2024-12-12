using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("MainHub");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
