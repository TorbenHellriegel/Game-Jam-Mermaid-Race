using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    public float diveSpeed;
    public float floatSpeed;
    public float camSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player around
        float VerticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float upDownInput = Input.GetAxis("UpDown");
        playerRb.AddForce(transform.forward * VerticalInput * speed);
        playerRb.AddForce(transform.right * horizontalInput * speed);
        playerRb.AddForce(transform.up * upDownInput * diveSpeed * 1.5f);

        // Rotate player
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 movementVector = new Vector3(0,mouseX,0);
        transform.Rotate(movementVector * camSensitivity);
    }

    private void OnTriggerStay(Collider other)
    {
        // Bounce the player up if hes in the water
        if(other.CompareTag("Water"))
        {
            float updrift = - transform.position.y + 0.5f;
            if(transform.position.y > 0)
            {
                updrift /= 5;
            }
            playerRb.AddForce(transform.up * floatSpeed * updrift);
        }
    }
}
