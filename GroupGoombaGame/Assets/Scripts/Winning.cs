using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject between = GameObject.FindGameObjectWithTag("Between");
            Destroy(between);
            SceneManager.LoadScene("Winning");
        }
    }
}
