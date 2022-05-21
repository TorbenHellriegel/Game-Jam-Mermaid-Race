using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpawnedObstacles : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] collectables;

    // Start is called before the first frame update
    void Start()
    {
        int num = Random.Range(1, 3);
        for (int j = 0; j < num; j++)
        {
            int index = Random.Range(0, 3);
            obstacles[index].SetActive(false);
            collectables[index].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
