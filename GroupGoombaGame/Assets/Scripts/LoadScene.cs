using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad;
    private GameObject player;
    private BetweenScenes between;
    public bool isOnRight;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainGuy");
        between = GameObject.FindGameObjectWithTag("Between").GetComponent<BetweenScenes>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float offset = isOnRight ? -2f : 2f; 
            Vector3 returnPoint = new Vector3(gameObject.transform.position.x + offset, gameObject.transform.position.y, gameObject.transform.position.z);
            between.UpdateValues(returnPoint);
            SceneManager.LoadSceneAsync(sceneToLoad);
        }
    }
}
