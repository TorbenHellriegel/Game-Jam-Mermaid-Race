using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject cam;
    public AudioSource sharkAudioSource;
    public AudioClip sharkAttack;
    private string sharkState;
    private float timeElapsed;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        sharkAudioSource = GetComponent<AudioSource>();
        sharkState = "FollowPlayer";
        timeElapsed = 0;
    }
    void Update()
    {
        switch (sharkState)
        {
            case "FollowPlayer":
                FollowPlayer();
                break;
            case "TurnToCamera":
                TurnToCamera();
                break;
            case "JumpAtCamera":
                JumpAtCamera();
                break;
            default:
                break;
        }
    }

    private void FollowPlayer()
    {
        Vector3 player = playerHealth.gameObject.transform.position;
        int health = playerHealth.health;
        transform.position =  new Vector3(player.x, 0, -1 -2*health);
    }

    private void TurnToCamera()
    {
        transform.Rotate(new Vector3(0, 150, 0) * Time.deltaTime);
    }

    private void JumpAtCamera()
    {
        timeElapsed += Time.deltaTime;
        transform.Translate(new Vector3(0, 2, 20) * timeElapsed);
    }

    void Jump()
    {
        transform.Rotate(new Vector3(-25, 0, 0));
        timeElapsed = 0;
        sharkState = "JumpAtCamera";
    }

    void StopRotation()
    {
        sharkState = "null";
        Invoke("Jump", 0.5f);
    }

    public void EndOfGameMovement()
    {
        sharkState = "TurnToCamera";
        sharkAudioSource.PlayOneShot(sharkAttack);
        Invoke("StopRotation", 1.2f);
    }
}
