using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    public float diveSpeed;
    private float diveTimer;
    public float timeBetweenDives = 1;
    public int switchPosition;
    private Vector3[] position = new Vector3[] {new Vector3(-5, 0, 0), new Vector3(0, 0, 0), new Vector3(5, 0, 0)};
    public float floatSpeed;
    public float camSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        diveTimer = 0;
        switchPosition = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Count to determine when the next dive is allowed
        diveTimer += Time.deltaTime;

        // Dive when the player presses space
        if(Input.GetKeyDown(KeyCode.Space) && diveTimer > timeBetweenDives)
        {
            playerRb.AddForce(Vector3.down * diveSpeed, ForceMode.Impulse);
            diveTimer = 0;
        }

        // Swich lanes left and right
        if(Input.GetKeyDown(KeyCode.A) && switchPosition > 0)
        {
            switchPosition--;
            playerRb.MovePosition(new Vector3(position[switchPosition].x, transform.position.y, transform.position.z));
        }
        if(Input.GetKeyDown(KeyCode.D) && switchPosition < 2)
        {
            switchPosition++;
            playerRb.MovePosition(new Vector3(position[switchPosition].x, transform.position.y, transform.position.z));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Bounce the player up if hes in the water
        if(other.CompareTag("Water"))
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
            playerRb.AddForce(transform.up * floatSpeed * updrift);
        }
        if(other.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle");
        }
    }
}
