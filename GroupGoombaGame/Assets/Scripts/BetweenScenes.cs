using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetweenScenes : MonoBehaviour
{
    private int coins = 0;
    private int keys = 0;
    private Scene prevScene;

    private Transform spawnPoint;
    private Transform spawnPoint1;

    // Start is called before the first frame update
    void Start()
    {
        prevScene = SceneManager.GetActiveScene();
        DontDestroyOnLoad(this.gameObject);
        spawnPoint = this.gameObject.transform;
        spawnPoint1 = GameObject.FindGameObjectWithTag("Point1").transform;
    }

    public void UpdateValues(Scene prev)
    {
        this.prevScene = prev;
    }

    public Transform GetSpawn()
    {
        if (prevScene.buildIndex == 1)
        {
            return spawnPoint1;
        }
        return spawnPoint;
    }
}
