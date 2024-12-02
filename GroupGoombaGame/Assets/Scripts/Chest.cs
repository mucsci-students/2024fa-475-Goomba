using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [Header("Keys")]
    public bool needKey;
    public int keyNeeded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponentInParent<PlayerInventory>().CheckKeys(keyNeeded))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
