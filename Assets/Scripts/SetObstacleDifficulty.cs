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
        difficulty = gameObject.GetComponentInParent<ControlSpawnedObstacles>().difficulty;

        // get safe positions (multiple)

        // for each safe position...

        for (int i = 2; i > difficulty % 2; i--)
        {
            int index = Random.Range(0, obstacles.Length);
            obstacles[index].SetActive(true);
            collectables[index].SetActive(false);
        }
    }
}
