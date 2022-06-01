using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

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
        score += Mathf.RoundToInt(amount * Time.timeScale);
        scoreText.text = score.ToString();
    }
}
