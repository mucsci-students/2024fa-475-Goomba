using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public SceneAsset sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetInactive();
            SceneManager.LoadSceneAsync(sceneToLoad.name, LoadSceneMode.Additive);
            Scene next = SceneManager.GetSceneByName(sceneToLoad.name);
            SceneManager.SetActiveScene(next);
            //SceneManager.GetActiveScene();
            
        }
    }

    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
