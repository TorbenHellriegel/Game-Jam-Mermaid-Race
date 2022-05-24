using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObstacleDifficultyRocks : MonoBehaviour
{
    public GameObject[] obstacles;

    private int difficulty;

    void OnEnable()
    {
        int index = Random.Range(0, obstacles.Length);
        obstacles[index].SetActive(true);
    }
}
