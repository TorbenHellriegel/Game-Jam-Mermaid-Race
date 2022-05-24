using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpawnedObstacles : MonoBehaviour
{
    public GameObject[] obstacles;
    public int difficulty;
    
    public void SpawnObstacles(int difficulty)
    {
        difficulty = difficulty;

        for (int i = 0; i < difficulty; i++)
        {
            obstacles[i].SetActive(true);
        }
    }
}
