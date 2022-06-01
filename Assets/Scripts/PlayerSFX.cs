using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public AudioSource playerAudioSource;
    public AudioClip[] jumpAudio;
    public AudioClip coinCollected;
    public AudioClip rockCrash;
    public AudioClip pufferCrash;

    private int randomSFX;

    private void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpAudio()
    {
        RandomAudioEffect();
        playerAudioSource.PlayOneShot(jumpAudio[randomSFX]);
    }

    void RandomAudioEffect()
    {
        randomSFX = Random.Range(0, jumpAudio.Length);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            playerAudioSource.PlayOneShot(rockCrash);
        }
        if (other.CompareTag("Obstacle"))
        {
            playerAudioSource.PlayOneShot(pufferCrash);
        }
        if (other.CompareTag("Coin"))
        {
            playerAudioSource.PlayOneShot(coinCollected);
            Destroy(other.gameObject);
        }
    }
}
