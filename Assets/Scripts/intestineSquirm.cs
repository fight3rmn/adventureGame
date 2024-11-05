using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intestineSquirm : MonoBehaviour
{
    public GameObject thisObject;
    public float timer;
    public Boolean goingUp;
    public Vector3 squirmSpeed;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(goingUp == true) {
            thisObject.transform.position += squirmSpeed;
        }
        else {
            thisObject.transform.position -= squirmSpeed;
        }
        if(timer >= 1.9) {
            goingUp = !goingUp;
            timer = 0;
        }
    }
}
