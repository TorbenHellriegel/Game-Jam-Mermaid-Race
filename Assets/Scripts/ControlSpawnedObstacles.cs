using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpawnedObstacles : MonoBehaviour
{
    public GameObject[] obstacles;
    
    public void SpawnObstacles(int difficulty)
    {
        // int num = Random.Range(1, 3);
        // for (int j = 0; j < num; j++)
        // {
        //     int index = Random.Range(0, 3);
        //     obstacles[index].SetActive(false);
        //     collectables[index].SetActive(true);
        // }
        for (int i = 0; i < difficulty; i++)
        {
            obstacles[i].SetActive(true);
        }
    }
}
