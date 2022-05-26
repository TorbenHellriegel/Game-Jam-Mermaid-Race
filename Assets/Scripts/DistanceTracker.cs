using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    private float distanceUnit = 0.0f;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        InvokeRepeating("DistanceChecker", 0.0f, 0.25f);
    }

    private void Update()
    {
        if (gameManager.isGameOver)
        {
            CancelInvoke("DistanceChecker");
        }
    }

    private void DistanceChecker()
    {
        distanceUnit += 1.5f;
        distanceText.text = "Distance:" + distanceUnit.ToString();
    }
}
