using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public int distanceUnit = 1;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        InvokeRepeating(nameof(DistanceChecker), 0.0f, 0.1f);
    }

    private void Update()
    {
        if (gameManager.isGameOver)
        {
            CancelInvoke(nameof(DistanceChecker));
        }
    }

    private void DistanceChecker()
    {
        distanceUnit += 1;
        if (distanceUnit == 0)
        {
            distanceText.text = string.Format("Distance: 0 m");
        }
        else
        {
            distanceText.text = string.Format("Distance: " + distanceUnit + " m");
        }
    }
}
