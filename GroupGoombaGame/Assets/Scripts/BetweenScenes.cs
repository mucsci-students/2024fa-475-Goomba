using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetweenScenes : MonoBehaviour
{
    private Vector3 returnPoint;
    private bool[] minigamesWon = new bool[4];
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        returnPoint = new Vector3(0f, 0f, -2f);
    }

    public void UpdateValues(Vector3 pos)
    {
        this.returnPoint = pos;
    }

    public void UpdateMinigameWon(int index)
    {
        minigamesWon[index] = true;
        counter++;
    }

    public Vector3 GetPoint()
    {
        return returnPoint;
    }

    public bool[] GetActive()
    {
        return minigamesWon;
    }

    public int GetCounter()
    {
        return counter;
    }
}
