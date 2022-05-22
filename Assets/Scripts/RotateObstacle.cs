using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(Random.Range(0, 360), 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(-200, 0, 0) * Time.deltaTime);
    }
}
