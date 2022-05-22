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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAudioSource.PlayOneShot(jumpAudio[randomSFX]);
        }
    }

    void RandomAudioEffect()
    {
        randomSFX = Random.Range(0, jumpAudio.Length);
    }
}
