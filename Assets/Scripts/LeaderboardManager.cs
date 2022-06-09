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
    private int scoreLeaderboardID;
    private int distanceLeaderboardID;
    private int maxScores = 10;
    public TextMeshProUGUI[] returnedRanks;
    public TextMeshProUGUI[] returnedNames;
    public TextMeshProUGUI[] returnedScores;
    public TextMeshProUGUI[] returnedDistances;
    private int difficulty;

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

        difficulty = gameManager.difficulty;
    }

    public void SubmitScore()
    {
        difficulty = gameManager.difficulty;
        switch (difficulty)
        {
            case 1:
                scoreLeaderboardID = 3328;
                distanceLeaderboardID = 3329;
                break;
            case 3:
                scoreLeaderboardID = 3616;
                distanceLeaderboardID = 3617;
                break;
            case 5:
                scoreLeaderboardID = 3618;
                distanceLeaderboardID = 3619;
                break;
        }

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
        difficulty = gameManager.difficulty;
        switch (difficulty)
        {
            case 1:
                scoreLeaderboardID = 3328;
                distanceLeaderboardID = 3329;
                break;
            case 3:
                scoreLeaderboardID = 3616;
                distanceLeaderboardID = 3617;
                break;
            case 5:
                scoreLeaderboardID = 3618;
                distanceLeaderboardID = 3619;
                break;
        }

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
        difficulty = gameManager.difficulty;
        switch (difficulty)
        {
            case 1:
                scoreLeaderboardID = 3328;
                distanceLeaderboardID = 3329;
                break;
            case 3:
                scoreLeaderboardID = 3616;
                distanceLeaderboardID = 3617;
                break;
            case 5:
                scoreLeaderboardID = 3618;
                distanceLeaderboardID = 3619;
                break;
        }

        LootLockerSDKManager.GetScoreList(scoreLeaderboardID, maxScores, (response) =>
        {
            LootLockerLeaderboardMember[] scores = response.items;

            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i].player.name != "")
                {
                    returnedRanks[i].text = scores[i].rank.ToString();
                    returnedNames[i].text = scores[i].player.name;
                    returnedScores[i].text = scores[i].score.ToString();
                }
                else
                {
                    returnedRanks[i].text = scores[i].rank.ToString();
                    // may change to playerprefs playerID?
                    returnedNames[i].text = scores[i].player.id.ToString();
                    returnedScores[i].text = scores[i].score.ToString();
                }

            }

            if (scores.Length < maxScores)
            {
                for (int i = scores.Length; i < maxScores; i++)
                {
                    returnedNames[i].text = "None";
                    returnedScores[i].text = "0";
                }
            }
        });

        LootLockerSDKManager.GetScoreList(distanceLeaderboardID, maxScores, (response) =>
        {
            LootLockerLeaderboardMember[] distances = response.items;
            for (int i = 0; i < distances.Length; i++)
            {
                returnedDistances[i].text = distances[i].score.ToString() + " m";
            }

            if (distances.Length < maxScores)
            {
                for (int i = distances.Length; i < maxScores; i++)
                {
                    returnedDistances[i].text = "0" + " m";
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

