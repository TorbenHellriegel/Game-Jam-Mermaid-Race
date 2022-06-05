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
    private Vector3 playerPosition;
    private Vector3 direction;
    private Quaternion lookRotation;

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
        if(playerPosition.x != playerHealth.gameObject.transform.position.x)
        {
            playerPosition = playerHealth.gameObject.transform.position;
            timeElapsed = 0;
        }
        
        timeElapsed += Time.deltaTime / 25;

        transform.position = Vector3.Lerp(transform.position, new Vector3(playerPosition.x, 0, -1 -2*playerHealth.health), timeElapsed);
    }

    private void TurnToCamera()
    {
        timeElapsed += Time.deltaTime / 25;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, timeElapsed);
    }

    private void JumpAtCamera()
    {
        transform.Translate(new Vector3(0, 0, 20) * Time.deltaTime);
    }

    public void EndOfGameMovement()
    {
        timeElapsed = 0;
        direction = (cam.transform.position - transform.position).normalized;
        lookRotation = Quaternion.LookRotation(direction);
        sharkState = "TurnToCamera";
        sharkAudioSource.PlayOneShot(sharkAttack);
        Invoke("StopRotation", 2);
    }

    private void StopRotation()
    {
        timeElapsed = 0;
        sharkState = "JumpAtCamera";
    }
}
