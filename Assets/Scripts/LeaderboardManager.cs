using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    private DistanceTracker distanceTracker;
    private GameManager gameManager;
    public TextMeshProUGUI playerScore, playerDistance;
    private int memberID;
    public int scoreLeaderboardID = 3314;
    public int distanceLeaderboardID = 3315;
    private int maxScores = 10;
    public TextMeshProUGUI[] returnedScores;

    // Start is called before the first frame update
    void Start()
    {
        distanceTracker = FindObjectOfType<DistanceTracker>();
        gameManager = FindObjectOfType<GameManager>();
        GenerateMemberID();
        ConnectToLootLockerAsGuest();
        // ConnectToLootLockerAsUser();
    }

    // Used for testing
    public void ConnectToLootLockerAsGuest()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });
    }

    // Will grab user's Android Username to fill information and connect
    public void ConnectToLootLockerAsUser()
    {
        LootLockerSDKManager.StartSession("Player", (response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(memberID.ToString(), gameManager.finalScore, scoreLeaderboardID, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("error submitting high score");

                return;
            }

            Debug.Log("successfully submitted high score");
        });
    }

    public void SubmitDistance()
    {
        LootLockerSDKManager.SubmitScore(memberID.ToString(), distanceTracker.distanceUnit, distanceLeaderboardID, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("error submitting distance");

                return;
            }

            Debug.Log("successfully submitted distance");
        });
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(scoreLeaderboardID, maxScores, (response) =>
        {
            LootLockerLeaderboardMember[] scores = response.items;

            for(int i = 0; i < scores.Length; i++)
            {
                returnedScores[i].text = (scores[i].rank + ". " + scores[i].member_id + " " + scores[i].score);
            }

            if(scores.Length < maxScores)
            {
                for(int i = scores.Length; i < maxScores; i++)
                {
                    returnedScores[i].text = (i + 1).ToString() + ". None"; 
                }
            }
        });
    }

    // Will replace with Input for User Name
    public void GenerateMemberID()
    {
        memberID = Random.Range(0, 999999);
    }
}
