using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Item : MonoBehaviour
{ 
    public GameManager gameManager;
    public OutOfBounds oob;


    [Header("Item Type")]
    public bool key;
    public bool coin;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter for Item has been called.");

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

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                Vector3 newSpawn = player.transform.position;
                oob.setPlayerSpawnPosition(newSpawn);

                GameObject collectedkey = GameObject.FindGameObjectWithTag("collectedkey");
                TextMeshProUGUI collectedkeyText = collectedkey.GetComponent<TextMeshProUGUI>();
                collectedkeyText.text = "You have collected the Key!" + "\n" + "Return back to Start to Open the Chest!";
            }
            else
            {
                gameManager.setHasWonCurrentMinigame(true);
            }
            

            Destroy(this.gameObject);
        }
    }
}
