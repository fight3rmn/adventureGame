using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoom : MonoBehaviour
{
    public Camera mainCam;
    void Start()
    {
        mainCam.fieldOfView = 40;
    }

}
