using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{ 
    public SceneAsset mainMenu;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void GoHome()
    {
        SceneManager.LoadScene(mainMenu.name);
    }

    public void Quit()
    {
       Application.Quit();
    }
}
