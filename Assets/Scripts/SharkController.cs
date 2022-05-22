using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    public PlayerController pc;
    public GameObject cam;
    private bool gameOver = false;
    private bool facingCamera = false;
    private float timeElapsed;

    private void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        facingCamera = false;
        timeElapsed = 0;
    }
    void Update()
    {
        CheckTranform();

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

    void CheckTranform()
    {
        switch (pc.lives)
        {
            case 3:
                {
                    transform.position = new Vector3(0, 0, -7);
                    break;
                }
            case 2:
                {
                    transform.position = new Vector3(0, 0, -5);
                    break;
                }

            case 1:
                {
                    transform.position = new Vector3(0, 0, -3);
                    break;
                }

            case 0:
                {
                    transform.position = new Vector3(0, 0, 0);
                    break;
                }
        }
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
        Invoke("StopRotation", 1.2f);
        //facingCamera = true;

        // Trigger Shark Laugh
    }
}
