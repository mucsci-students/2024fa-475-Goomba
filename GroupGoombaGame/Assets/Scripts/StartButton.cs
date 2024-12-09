using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] SceneAsset MainHub;

    public void StartGame()
    {
        SceneManager.LoadScene(MainHub.name);
    }
}
