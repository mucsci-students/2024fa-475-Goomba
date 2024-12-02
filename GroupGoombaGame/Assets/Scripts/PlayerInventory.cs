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
    int keys;
    public TextMeshProUGUI keyDisplay;

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        keys = 0;
    }

    public void UpdateCoins(int amount)
    {
        coins += amount;
        coinDisplay.text = "Coins: " + coins.ToString();
    }

    public void KeyGet(int amount)
    {
        keys += amount;
        keyDisplay.text = "Keys: " + keys.ToString();
    }

    public bool CheckKeys()
    {
        return keys >= 1;
    }
}
