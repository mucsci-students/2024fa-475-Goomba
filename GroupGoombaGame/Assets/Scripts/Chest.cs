using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [Header("Keys")]
    public bool needKey;
    public int keyNeeded;
    public GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter for Chest has been called.");
        if (other.CompareTag("Player"))
        {
            if (other.GetComponentInParent<PlayerInventory>().CheckKeys())
            {
                other.GetComponentInParent<PlayerInventory>().KeyGet(-1);
                //gameManager.wonMinigame(0);
                gameManager.setHasWonCurrentMinigame(true);
                Destroy(this.gameObject);
                //maybe this can stay here?
            }
        }
    }
}
