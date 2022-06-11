using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private PlayerSFX playerSFX;
    private GameObject character;

    [Header("Dive Variables")]
    public float speed;
    public float diveSpeed;
    private float diveTimer;
    private bool isDiving;
    public float timeBetweenDives = 1;
    [Header("Control Varaibles")]
    public int currentPosition;
    public int nextPosition;
    private float swichDistance;
    private Vector3[] position = new Vector3[] {new Vector3(-5, 0, 0), new Vector3(0, 0, 0), new Vector3(5, 0, 0)};
    public float floatSpeed;
    [Header("Particle Systems")]
    public ParticleSystem rockCrash;
    public ParticleSystem pufferCrash;
    public ParticleSystem coinCollect;
    public ParticleSystem waterSplash;

    private void Awake()
    {
        // Was giving error in start so moved to awake
        playerRb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        diveTimer = 0;
        isDiving = false;
        currentPosition = 1;
        nextPosition = 1;

        // Figure out how to make jump get called in PlayerSFX so we can get rid of this section
        playerSFX = GetComponent<PlayerSFX>();
    }

    // Update is called once per frame
    void Update()
    {
        // Count to determine when the next dive is allowed
        diveTimer += Time.deltaTime;

        // Animate the character swiching lane
        SwichLane();

        // Dive when the player presses space
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Dive();
        }

        // If the player hits the water after diving play the dive sound and vfx
        if(isDiving && transform.position.y < 0)
        {
            isDiving = false;
            Instantiate(waterSplash, transform.position, waterSplash.transform.rotation);
            // Figure out a way to call this just from PlayerSFX script to clean this up.
            playerSFX.PlayJumpAudio();
        }
        
        // Swich lanes left and right
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            MoveLeft();
        }

        if ((Input.GetKeyDown(KeyCode.D) ||Input.GetKeyDown(KeyCode.RightArrow)))
        {
            MoveRight();   
        }

    }

    // Animate the character swiching lane
    private void SwichLane()
    {
        if(currentPosition != nextPosition)
        {
            swichDistance += Time.deltaTime*20;
            swichDistance = Mathf.Min(swichDistance, 1);

            transform.position = Vector3.Lerp(new Vector3(position[currentPosition].x, transform.position.y, transform.position.z),
                                            new Vector3(position[nextPosition].x, transform.position.y, transform.position.z),
                                            swichDistance);

            if(position[nextPosition].x == transform.position.x)
            {
                currentPosition = nextPosition;
            }
        }
    }

    public void MoveLeft()
    {
        if (currentPosition > 0 && currentPosition == nextPosition)
        {
            swichDistance = 0;
            nextPosition = currentPosition-1;
        }
    }

    public void MoveRight()
    {
        if (currentPosition < 2 && currentPosition == nextPosition)
        {
            swichDistance = 0;
            nextPosition = currentPosition+1;
        }
    }

    public void Dive()
    {
        if (diveTimer > timeBetweenDives)
        {
            playerRb.AddForce(Vector3.down * diveSpeed, ForceMode.Impulse);
            isDiving = true;
            diveTimer = 0;
        }

    }

    private void Swim()
    {
        float updrift;
        if(transform.position.y > -0.5f)
        {
            updrift = -0.2f;
        }
        else
        {
            updrift = 1;
        }
        playerRb.AddForce(floatSpeed * updrift * transform.up);
    }

    private void OnTriggerStay(Collider other)
    {
        // Bounce the player up if hes in the water
        if(other.CompareTag("Water"))
        {
            Swim();
        }
    }

    // Possibly create a PlayerVFX script to deal with VFX in a separate area instead of PlayerController
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            Instantiate(rockCrash, transform.position,
            rockCrash.transform.rotation);
        }

        if(other.CompareTag("Obstacle"))
        {
            Instantiate(pufferCrash, transform.position,
            pufferCrash.transform.rotation);
        }

        // Think about PlayerVFX script possibly to change this section
        if (other.CompareTag("Coin"))
        {
            Instantiate(coinCollect, transform.position,
            coinCollect.transform.rotation);
        }

    }
}
