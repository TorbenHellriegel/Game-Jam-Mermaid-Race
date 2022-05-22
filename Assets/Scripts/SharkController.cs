using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    public PlayerController pc;

    private void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        switch (pc.lives)
        {
            case 3:
                {
                    transform.position = new Vector3(0, 0, -7);
                    break;
                }
            case 2:
                {
                    transform.position = new Vector3(0, 0, -5);
                    break;
                }

            case 1:
                {
                    transform.position = new Vector3(0, 0, -3);
                    break;
                }

            case 0:
                {
                    transform.position = new Vector3(0, 0, 0);
                    break;
                }
        }
    }
}
