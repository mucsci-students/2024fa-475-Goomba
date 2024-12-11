using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;

    private int prevSecondsLeft = 200;
    private int currentSecondsLeft;
    private int enemiesIndex = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("EnemyStartManager start.");
        currentSecondsLeft = player.GetComponent<Timer>().getSecondsLeft();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //A new enemy should spawn every 10 seconds (or however many is decided on).
    void FixedUpdate()
    {
        currentSecondsLeft = player.GetComponent<Timer>().getSecondsLeft();
        if ((currentSecondsLeft == (prevSecondsLeft - 15)) && (enemiesIndex < enemies.Length))
        {
            enemies[enemiesIndex].SetActive(true);
            enemiesIndex++;
            prevSecondsLeft = currentSecondsLeft;
            Debug.Log("prevSecondsLeft " + prevSecondsLeft);
            Debug.Log("enemiesIndex " + enemiesIndex);
        }
        //Spawns in the first enemy.
        else if (currentSecondsLeft == 199)
        {
            enemies[0].SetActive(true);
        }
    }
}
