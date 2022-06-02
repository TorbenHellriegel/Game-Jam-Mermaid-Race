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
    public TMP_InputField playerNameInputField;
    private string playerID;
    public int scoreLeaderboardID = 3314;
    public int distanceLeaderboardID = 3315;
    private int maxScores = 10;
    public TextMeshProUGUI[] returnedScores;

    // Start is called before the first frame update
    void Start()
    {
        distanceTracker = FindObjectOfType<DistanceTracker>();
        gameManager = FindObjectOfType<GameManager>();
        playerID = PlayerPrefs.GetString("PlayerID");
        maxScores = returnedScores.Length;
        ConnectToLootLockerAsGuest();
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

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(playerID, gameManager.finalScore, scoreLeaderboardID, (response) =>
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
        LootLockerSDKManager.SubmitScore(playerID, distanceTracker.distanceUnit, distanceLeaderboardID, (response) =>
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
                if(scores[i].player.name != "")
                {
                    returnedScores[i].text = (scores[i].rank + ". " + scores[i].player.name + " " + scores[i].score);
                }
                else
                {
                    returnedScores[i].text = (scores[i].rank + ". " + scores[i].player.id + " " + scores[i].score);
                }
                
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

    public void SaveName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputField.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Player name saved successfully. ");
            }
            else
            {
                Debug.Log("Could not save player name. " + response.Error);
            }
        });
    }
}
