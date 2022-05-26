using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObstacleDifficultyMoving : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] collectables;

    private int difficulty;

    void OnEnable()
    {
        difficulty = gameObject.GetComponentInParent<ControlSpawnedObstacles>().diff;

        if(difficulty % 2 == 1)
        {
            SetUnsafePosition(Random.Range(0, obstacles.Length));
        }
        else
        {
            SetSafePosition(Random.Range(0, obstacles.Length));
        }
    }

    int GetBlockedPos(int pos, float direction)
    {
        float position = pos + Mathf.Round(direction)*2;
        Debug.Log("pos: " + pos);
        Debug.Log("dir: " + direction);
        Debug.Log("safepo: " + position);
        switch (position)
        {
            case -2.0f:
            case 4.0f:
                return 1;
            case -1.0f:
            case 0.0f:
                return 0;
            case 3.0f:
            case 2.0f:
                return 2;
            default:
                return 1;
        }
    }
    
    void SetSafePosition(int index)
    {
        // ---------------WARNING---------------
        // this part of the code seems useless but without it
        // obstacles[i].GetComponent<MovePufferfish>().direction
        // returns 0 instead of the direction
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
        }
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(true);
        }

        bool[] safePos = {true, true, true};

        for (int i = 0; i < obstacles.Length; i++)
        {
            if(i == index)
            {
                obstacles[i].SetActive(false);
            }
            else
            {
                float direction = obstacles[i].GetComponent<MovePufferfish>().direction;
                int blockedPos = GetBlockedPos(i, direction);
                safePos[blockedPos] = false;
            }
        }

        for (int i = 0; i < obstacles.Length; i++)
        {
            if(safePos[i])
            {
                collectables[i].SetActive(true);
            }
        }
    }
    
    void SetUnsafePosition(int index)
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
        }
        
        bool[] safePos = {true, true, true};

        for (int i = 0; i < obstacles.Length; i++)
        {
            if(i == index)
            {
                obstacles[i].SetActive(true);
                float direction = obstacles[i].GetComponent<MovePufferfish>().direction;
                int blockedPos = GetBlockedPos(i, direction);
                safePos[blockedPos] = false;
            }
        }

        for (int i = 0; i < obstacles.Length; i++)
        {
            if(safePos[i])
            {
                collectables[i].SetActive(true);
            }
        }
    }
}
