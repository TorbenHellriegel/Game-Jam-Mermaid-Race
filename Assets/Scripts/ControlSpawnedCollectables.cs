using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpawnedCollectables : MonoBehaviour
{
    public GameObject[] collectables;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < collectables.Length/3; i++)
        {
            int num = Random.Range(1, 3);
            for (int j = 0; j < num; j++)
            {
                int index = Random.Range(0, 3);
                collectables[index + 3*i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
