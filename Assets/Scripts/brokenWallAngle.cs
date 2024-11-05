using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brokenWallAngle : MonoBehaviour
{
    public float wallRotation;
    public GameObject thisObject;
    void Start()
    {
        thisObject.transform.eulerAngles = new Vector3(0, 0, wallRotation);
    }
}
