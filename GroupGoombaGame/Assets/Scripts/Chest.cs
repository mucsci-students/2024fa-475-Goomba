using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [Header("Keys")]
    public bool needKey;
    public int keyNeeded;
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponentInParent<PlayerInventory>().CheckKeys())
            {
                other.GetComponentInParent<PlayerInventory>().KeyGet(-1);
                Destroy(this.gameObject);
                //maybe this can stay here?
                gameManager.wonMinigame(0);
            }
        }
    }
}
