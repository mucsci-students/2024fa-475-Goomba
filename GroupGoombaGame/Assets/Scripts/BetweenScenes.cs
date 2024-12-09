using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetweenScenes : MonoBehaviour
{
    private Vector3 returnPoint;
    private bool[] activeDoors = new bool[4];

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        returnPoint = new Vector3(0f, 0f, -2f);
    }

    public void UpdateValues(Vector3 pos, int index)
    {
        this.returnPoint = pos;
        activeDoors[index] = true;
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
