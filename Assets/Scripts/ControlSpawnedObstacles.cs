using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpawnedObstacles : MonoBehaviour
{
    public GameObject[] obstacles;
    public int diff;
    
    public void SpawnObstacles(int difficulty)
    {
        diff = difficulty;

        for (int i = 0; i < Mathf.CeilToInt(diff/2.0f); i++)
        {
            obstacles[i].SetActive(true);
        }
    }
}
