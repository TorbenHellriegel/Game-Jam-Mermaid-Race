using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public float distanceUnit = 0.0f;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        InvokeRepeating(nameof(DistanceChecker), 0.0f, 0.05f);
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
        distanceUnit += 0.3f;
        if (distanceUnit == 0)
        {
            distanceText.text = string.Format("Distance: 0 m");
        }
        else
        {
            distanceText.text = string.Format("Distance: {0:#0.0} m", distanceUnit);
        }
    }
}
