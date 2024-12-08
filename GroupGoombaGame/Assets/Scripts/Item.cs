using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Item : MonoBehaviour
{ 
    public GameManager gameManager;


    [Header("Item Type")]
    public bool key;
    public bool coin;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter for Item has been called.");
        //why is it not going past this line in the kartracing scene

        if (other.CompareTag("Player"))
        {
            if (coin)
            {
                Debug.Log("TriggerEnter - Coin");
                other.GetComponentInParent<PlayerInventory>().UpdateCoins(1);
            }
            else if (key)
            {
                Debug.Log("TriggerEnter - Key");
                other.GetComponentInParent<PlayerInventory>().KeyGet(1);
            }
            else
            {
                gameManager.setHasWonCurrentMinigame(true);
            }
            

            Destroy(this.gameObject);
        }
    }
}
