using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Coins")]

    int coins;
    public TextMeshProUGUI coinDisplay;

    [Header("Items")]
    bool[] keys;


    AreaManager areaManager;
    
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        areaManager = FindObjectOfType<AreaManager>();
        keys = new bool[areaManager.numKeys];
    }

    public void UpdateCoins(int amount)
    {
        coins += amount;

        coinDisplay.text = "Coins: " + coins.ToString();
    }

    public void KeyGet(int keyId)
    {
        keys[keyId] = true;
    }

    public bool CheckKeys(int id)
    {
        return keys[id];
    }
}
