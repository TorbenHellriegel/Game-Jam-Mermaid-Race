using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public int score;
    private int scoreMultiplyer = 3;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetString("Difficulty", "Medium"))
        {
            case "Easy":
                scoreMultiplyer = 1;
                break;
            case "Medium":
                scoreMultiplyer = 3;
                break;
            case "Hard":
                scoreMultiplyer = 5;
                break;
            default:
                scoreMultiplyer = 3;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GainScore(10);
            Destroy(other.gameObject);
        }

    }
    private void GainScore(int amount)
    {
        score += Mathf.RoundToInt(amount * Time.timeScale * scoreMultiplyer);
        scoreText.text = score.ToString();
    }
}
