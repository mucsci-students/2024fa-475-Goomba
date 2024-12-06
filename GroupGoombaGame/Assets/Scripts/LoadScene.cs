using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public SceneAsset sceneToLoad;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainGuy");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetInactive();
            SceneManager.LoadSceneAsync(sceneToLoad.name);
        }
    }

    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
