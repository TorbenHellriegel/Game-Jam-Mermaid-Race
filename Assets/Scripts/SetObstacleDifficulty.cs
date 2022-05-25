using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObstacleDifficulty : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] collectables;

    private int difficulty;

    void OnEnable()
    {
        difficulty = gameObject.GetComponentInParent<ControlSpawnedObstacles>().diff;

        if(difficulty % 2 == 1)
        {
            SetUnsafePosition(Random.Range(0, obstacles.Length));
        }
        else
        {
            SetSafePosition(Random.Range(0, obstacles.Length));
        }
    }
    
    void SetSafePosition(int index)
    {
        obstacles[index].SetActive(false);
        collectables[index].SetActive(true);
    }
    
    void SetUnsafePosition(int index)
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
            collectables[i].SetActive(true);
        }
        obstacles[index].SetActive(true);
        collectables[index].SetActive(false);
    }
}
