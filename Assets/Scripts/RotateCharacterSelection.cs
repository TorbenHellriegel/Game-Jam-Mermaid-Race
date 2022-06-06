using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacterSelection : MonoBehaviour
{
    private float hight;
    public float floatHight;
    public float floatHightDifference;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, -Time.deltaTime * 100, 0));

        hight += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Sin(hight)*floatHightDifference + floatHight, transform.position.z);
    }
}
