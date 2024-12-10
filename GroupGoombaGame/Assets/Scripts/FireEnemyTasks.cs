using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DO NOT USE DESTROY. DESTROYING PREVENTS THE UPDATE CHECK FROM WORKING.
public class FireEnemyTasks : MonoBehaviour
{
    //Global Variable Declarations:
    //-----------------------------

    public GameObject player;
    public GameObject currentFireEnemy;
    //public GameObject timerObject;

    public GameManager gameManager;

    //could show how many enemies have been defeated & are left.
    private int enemiesDefeated = 0;
    public int enemiesLeft;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesLeft == 0)
        {
            gameManager.setHasWonCurrentMinigame(true);
        }
    }

    //Player destroys a FireEnemy when they contact them. What doesn't happen is the player losing the game when contacting.
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        //{

        //}
        if (collision.gameObject.Equals(player))
        {
            //gameManager.lostMinigame();
            //player.GetComponent<Timer>().setSecondsLeft(0);

            //can we do this instead of getting the currentFireEnemy?
            enemiesDefeated++;
            enemiesLeft--;
            Debug.Log("Destroyed a FireEnemy. " + enemiesDefeated + " defeated. " + enemiesLeft + " left.");
            //Destroy(this);
            //Destroy(currentFireEnemy);
            
            currentFireEnemy.SetActive(false);
        }
    }
}
