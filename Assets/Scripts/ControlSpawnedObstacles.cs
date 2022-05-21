using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpawnedObstacles : MonoBehaviour
{
    public GameObject[] obstacles;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < obstacles.Length/3; i++)
        {
            int num = Random.Range(1, 3);
            for (int j = 0; j < num; j++)
            {
                int index = Random.Range(0, 3);
                obstacles[index + 3*i].SetActive(false);
                Debug.Log("Inactive" + i + index);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
