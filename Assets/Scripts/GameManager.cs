using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float respawnSpeed = 60.0f/30.0f;

    public int spawnedSegments;
    public GameObject nextSectionSegment;
    public GameObject[] segmentPrefabs;
    public GameObject[] characters;
    public PlayerController player;
    public SharkController shark;
    public GameObject gameOverScreen;
    public GameObject finalScoreTextgo;
    public TextMeshProUGUI finalScoreText;
    public int finalScore = 0;
    public bool isGameOver = false;
    public bool isGameOverScreen = false;

    // Start is called before the first frame update
    void Start()
    {
        shark = GameManager.FindObjectOfType<SharkController>();

        Time.timeScale = 1;
        isGameOver = false;
        spawnedSegments = 0;

        // Spawn the selected character
        int CharacterIndex = PlayerPrefs.GetInt("Character");
        characters[CharacterIndex].SetActive(true);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        // Spawn the first 5 segments
        for (int i = 0; i < 5; i++)
        {
            int index = Random.Range(0, segmentPrefabs.Length);
            Instantiate(segmentPrefabs[index], new Vector3(0, 0, 160 + 60*i), segmentPrefabs[index].gameObject.transform.rotation);
            spawnedSegments++;
        }
        // Spawn a new segment every second
        InvokeRepeating("SpawnSegment", respawnSpeed, respawnSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            finalScore = player.score;
        }
        
        if(Input.anyKey && isGameOverScreen)
        {
            RestartGame();
        }
    }

    // Spawns a random segment
    void SpawnSegment()
    {
        if (spawnedSegments % 10 == 0)
        {
            Instantiate(nextSectionSegment, new Vector3(0, 0, 400), nextSectionSegment.gameObject.transform.rotation);
        }
        else
        {
            int index = Random.Range(0, segmentPrefabs.Length);
            Instantiate(segmentPrefabs[index], new Vector3(0, 0, 400), segmentPrefabs[index].gameObject.transform.rotation);
        }
        spawnedSegments++;
    }

    public void GameOver()
    {
        isGameOver = true;
        CancelInvoke(nameof(SpawnSegment));
        shark.EndOfGameMovement();
        Invoke("GameOverScreen", 2.1f);
    }

    void GameOverScreen()
    {
        isGameOverScreen = true;
        gameOverScreen.SetActive(true);
        finalScoreText = finalScoreTextgo.GetComponent<TextMeshProUGUI>();
        finalScoreText.text = "Final Score: " + finalScore;
    }

    void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
