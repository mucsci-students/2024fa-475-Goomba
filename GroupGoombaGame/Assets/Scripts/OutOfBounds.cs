using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class OutOfBounds : MonoBehaviour
{
    //Global Variable Declarations:
    //-----------------------------

    public GameObject player;

    private Vector3 playerSpawnPosition;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpawnPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player has hit Out Of Bounds Detection.");
        //transport player back to spawn position or some position.
        player.transform.position = playerSpawnPosition;
    }
}
