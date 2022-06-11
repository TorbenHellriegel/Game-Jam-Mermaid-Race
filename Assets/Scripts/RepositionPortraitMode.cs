using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionPortraitMode : MonoBehaviour
{
    public Vector3 landscapePos;
    public Vector3 portraitPos;
    private Vector3 defaultPos;

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        // Adjust position of object based on horizintal and vertical play mode
        if(Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
        {
            transform.position = defaultPos + portraitPos;
        }
        else if(Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            transform.position = defaultPos + landscapePos;
        }
    }
}
