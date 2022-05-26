using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePufferfish : MonoBehaviour
{
    private float bound = 7;
    private float speed = 3;
    public float direction;

    // Start is called before the first frame update
    void Awake()
    {
        direction = (Random.Range(0, 2) - 0.5f) * 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed * direction);

        if(transform.position.x > bound)
        {
            direction = -1;
        }
        if(transform.position.x < -bound)
        {
            direction = 1;
        }
    }
}
