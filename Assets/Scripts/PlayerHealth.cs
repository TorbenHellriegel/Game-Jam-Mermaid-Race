using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Values")]
    public int health;
    public int currentNumberOfHearts;
    private int maxNumberOfHearts = 4;
    [Header("Heart Values")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emtpyHeart;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        InitializeHealth();
        CheckForDeath();
    }

    private void InitializeHealth()
    {
        if (health > maxNumberOfHearts)
        {
            health = maxNumberOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emtpyHeart;
            }

            if (i < maxNumberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            LooseLives(1);
        }

        if (other.CompareTag("Obstacle"))
        {
            LooseLives(1);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Section"))
        {
            GainLives(1);
        }
    }

    private void GainLives(int amount)
    {
            health+=amount;
    }

    private void LooseLives(int amount)
    {
        health-=amount;
    }

    private void CheckForDeath()
    {
        if (health <= 0)
        {
            gameManager.isGameOver = true;
            gameManager.GameOver();
            Destroy(gameObject, 0.1f);
        }
    }
}
