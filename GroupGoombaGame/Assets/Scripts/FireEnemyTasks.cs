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
    public Rigidbody rb;
    //public GameObject timerObject;

    public GameManager gameManager;

    //could show how many enemies have been defeated & are left.
    //private int enemiesDefeated = 0;
    //public int enemiesLeft;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (enemiesLeft <= 0)
        //{
        //    gameManager.setHasWonCurrentMinigame(true);
        //}
        ////I would like the fire enemies to be inactive when the player is inactive. but how to do that without bugs?
        //else
        //{
        //    if (player.activeSelf == true)
        //    {
        //        followPlayer();
        //    }
        //}

        //if (player.GetComponent<Timer>().getSecondsLeft() <= 0)
        //{

        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        //{

        //}
        //if (collision.gameObject.Equals(player))
        //{
        //    //gameManager.lostMinigame();
        //    //player.GetComponent<Timer>().setSecondsLeft(0);

        //    //can we do this instead of getting the currentFireEnemy?
        //    enemiesDefeated++;
        //    enemiesLeft--;
        //    Debug.Log("Destroyed a FireEnemy. " + enemiesDefeated + " defeated. " + enemiesLeft + " left.");
        //    //Destroy(this);
        //    //Destroy(currentFireEnemy);
            
        //    currentFireEnemy.SetActive(false);
        //}

        //If the player contacts an enemy, they lose.
        if (collision.gameObject.Equals(player))
        {
            player.GetComponent<Timer>().setSecondsLeft(0);
            player.GetComponent<Timer>().setEnemyTouchedPlayer(true);
        }
    }

    void followPlayer()
    {
        //Debug.Log("followPlayer has been called.");
        //How far away is the Player?
        Vector3 directionToPlayer = (player.transform.position - currentFireEnemy.transform.position).normalized;
        directionToPlayer.y = 0;

        //Rotate where to move toward Player?
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);

        // Move forward
        //Rigidbody rb = currentFireEnemy.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 2.0f);
    }
}
