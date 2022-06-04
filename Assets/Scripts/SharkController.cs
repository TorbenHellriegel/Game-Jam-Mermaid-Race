using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject cam;
    private bool gameOver = false;
    private bool facingCamera = false;
    private float timeElapsed;
    public AudioSource sharkAudioSource;
    public AudioClip sharkAttack;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        facingCamera = false;
        timeElapsed = 0;
        sharkAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(playerHealth.health > 0)
        {
            transform.position = CalculatePosition();
        }
        //CheckTranform();

        if (gameOver)
        {
            transform.Rotate(new Vector3(0, 150, 0) * Time.deltaTime);
        }

        if (facingCamera)
        {
            timeElapsed += Time.deltaTime;
            transform.Translate(new Vector3(0, 2, 20) * timeElapsed);
        }
    }

    private Vector3 CalculatePosition()
    {
        Vector3 player = playerHealth.gameObject.transform.position;
        int health = playerHealth.health;
        return new Vector3(player.x, 0, -1 -2*health);
    }

    void Jump()
    {
        transform.Rotate(new Vector3(-25, 0, 0));
        facingCamera = true;
    }

    void StopRotation()
    {
        gameOver = false;
        Invoke("Jump", 0.5f);
    }

    public void EndOfGameMovement()
    {
        //transform.Rotate(new Vector3(-25, 180, 0));
        gameOver = true;
        sharkAudioSource.PlayOneShot(sharkAttack);
        Invoke("StopRotation", 1.2f);
        //facingCamera = true;

        // Trigger Shark Laugh
    }
}
