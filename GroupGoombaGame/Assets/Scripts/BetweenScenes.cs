using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetweenScenes : MonoBehaviour
{
    private int coins = 0;
    private int keys = 0;

    private Vector3 returnPoint;
    private bool[] activeDoors = new bool[4];

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        returnPoint = new Vector3(0f, 0f, -2f);
        activeDoors[0] = true;
        activeDoors[1] = true;
        activeDoors[2] = true;
        activeDoors[3] = true;
    }

    public void UpdateValues(Vector3 pos, int index)
    {
        this.returnPoint = pos;
        activeDoors[index] = false;
    }

    public Vector3 GetPoint()
    {
        return returnPoint;
    }

    public bool[] GetActive()
    {
        return activeDoors;
    }
}
