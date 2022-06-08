using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Values")]
    public int health;
    public int maxHealth;
    private int maxNumberOfHearts = 5;
    [Header("Heart Values")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emtpyHeart;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        switch (PlayerPrefs.GetString("Difficulty", "Medium"))
        {
            case "Easy":
                health = 4;
                maxHealth = 4;
                break;
            case "Medium":
                health = 3;
                maxHealth = 3;
                break;
            case "Hard":
                health = 2;
                maxHealth = 2;
                break;
            default:
                health = 3;
                maxHealth = 3;
                break;
        }

        SetHealth();
    }

    private void SetHealth()
    {
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

            if (i < maxHealth)
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
        if(health == maxHealth && maxHealth < maxNumberOfHearts)
        {
            maxHealth++;
        }
        else if(health < maxHealth)
        {
            health += amount;
        }
        SetHealth();
    }

    private void LooseLives(int amount)
    {
        //health -= amount;
        SetHealth();
        CheckForDeath();
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
