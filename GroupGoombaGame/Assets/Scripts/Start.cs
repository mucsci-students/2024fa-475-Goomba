using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public GameObject player;

    public void Spawn()
    {
        player.transform.position = FindObjectOfType<BetweenScenes>().GetSpawn().transform.position;
    }
}
