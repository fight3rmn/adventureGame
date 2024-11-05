using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyLineAngle : MonoBehaviour
{
    public GameObject thisObject;
    public Vector3 lineAngle;
    float timer;
    void Start()
    {
        thisObject.transform.eulerAngles = new Vector3(0, 0, lineAngle.z + 90);
    }
    void Update() {
        timer += Time.deltaTime;
        if(timer >= 1.05) {
            Destroy(thisObject);
        }
    }
}
