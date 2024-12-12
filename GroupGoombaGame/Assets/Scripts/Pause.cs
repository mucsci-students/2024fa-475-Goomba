using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{ 
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void GoHome()
    {

        GameObject between = GameObject.FindGameObjectWithTag("Between");
        Destroy(between);
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
       Application.Quit();
    }
}
