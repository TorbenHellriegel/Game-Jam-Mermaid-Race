using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    public PlayerController pc;
    void Update()
    {
        switch (pc.lives)
        {
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
