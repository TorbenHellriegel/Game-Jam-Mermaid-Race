using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    public float floatSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float VerticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float upDownInput = Input.GetAxis("UpDown");
        playerRb.AddForce(Vector3.forward * VerticalInput * speed);
        playerRb.AddForce(Vector3.right * horizontalInput * speed);
        playerRb.AddForce(Vector3.up * upDownInput * speed * 1.5f);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Water"))
        {
            float updrift = - transform.position.y + 0.5f;
            playerRb.AddForce(Vector3.up * floatSpeed * updrift, ForceMode.Force);
        }
    }
}
