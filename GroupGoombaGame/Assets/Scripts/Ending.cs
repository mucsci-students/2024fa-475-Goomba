using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{ 
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
       Application.Quit();
    }
}
