using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Global Stats
    public string playerName;
    public int totalTimePlayed;
    public int totalStarsCollected;
    public int totalDistanceTraveled;
    public int totalObstaclesHit;
    public int timesEatenByShark;
    #endregion

    #region Endless Mode Stats
    public int eHighScore;
    public int eLongestDistanceTraveled;
    public int eHighestRank;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
