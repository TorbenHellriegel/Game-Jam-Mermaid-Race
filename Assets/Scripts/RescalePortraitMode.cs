using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescalePortraitMode : MonoBehaviour
{
    public float landscapeScale = 1;
    public float portraitScale = 1;
    
    // Update is called once per frame
    void Update()
    {
        // Adjust scale of object based on horizintal and vertical play mode
        if(Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
        {
            transform.localScale = new Vector3(portraitScale, portraitScale, 1);
        }
        else if(Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            transform.localScale = new Vector3(landscapeScale, landscapeScale, 1);
        }
    }
}
