using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool key;
    public bool coin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (coin)
            {
                other.GetComponentInParent<PlayerInventory>().UpdateCoins(1);
            }
            if (key)
            {
                other.GetComponentInParent<PlayerInventory>().KeyGet(1);
            }
            Destroy(this.gameObject);
        }
    }
}
