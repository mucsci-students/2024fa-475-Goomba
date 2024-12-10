using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;

    [Header("Minigame 'doors'")]
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    private GameObject[] doors;

    private void Start()
    {
        doors = new GameObject[] { door1, door2, door3 };
        player.transform.position = FindObjectOfType<BetweenScenes>().GetPoint();
        bool[] bools = FindObjectOfType<BetweenScenes>().GetActive();
        for(int i = 0; i < doors.Length; i++)
        {
            doors[i].SetActive(!(bools[i]));
        }
    }
}
