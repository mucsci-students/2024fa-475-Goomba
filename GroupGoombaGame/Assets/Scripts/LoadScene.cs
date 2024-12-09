using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public SceneAsset sceneToLoad;
    public int index;
    private GameObject player;
    private BetweenScenes between;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainGuy");
        between = GameObject.FindGameObjectWithTag("Between").GetComponent<BetweenScenes>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 returnPoint = new Vector3(gameObject.transform.position.x + 2f, gameObject.transform.position.y, gameObject.transform.position.z);
            between.UpdateValues(returnPoint, index);
            SetInactive();
            SceneManager.LoadSceneAsync(sceneToLoad.name);
        }
    }

    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
