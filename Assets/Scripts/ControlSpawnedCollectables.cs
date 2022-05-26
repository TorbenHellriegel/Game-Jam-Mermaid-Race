using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpawnedCollectables : MonoBehaviour
{
    public GameObject[] collectables;

    // Start is called before the first frame update
    void Start()
    {
        int num = Random.Range(1, collectables.Length);
        for (int i = 0; i < num; i++)
        {
            int index = Random.Range(0, collectables.Length);
            collectables[index].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
