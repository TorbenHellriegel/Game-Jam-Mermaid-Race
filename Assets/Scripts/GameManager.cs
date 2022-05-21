using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] segmentPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            int index = Random.Range(0, segmentPrefabs.Length);
            Instantiate(segmentPrefabs[index], new Vector3(0, 0, 160 + 60*i), segmentPrefabs[index].gameObject.transform.rotation);
        }
        InvokeRepeating("SpawnSegment", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnSegment()
    {
        int index = Random.Range(0, segmentPrefabs.Length);
        Instantiate(segmentPrefabs[index], new Vector3(0, 0, 400), segmentPrefabs[index].gameObject.transform.rotation);
    }
}
