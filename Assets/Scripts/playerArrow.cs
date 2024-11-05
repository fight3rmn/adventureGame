using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerArrow : MonoBehaviour
{
    public Vector3 moveVector;
    public GameObject thisObject;
    float timer;
    public int angle;

    void Start() {
        thisObject.transform.eulerAngles = new Vector3(0, 0, angle);
    }
    void OnCollisionEnter2D(Collision2D hit) {
        Destroy(thisObject);
    }
    void Update()
    {
        timer += Time.deltaTime;
        thisObject.transform.position += new Vector3(Time.deltaTime * moveVector.x, Time.deltaTime * moveVector.y, 0);
        if(timer >= 2) {
            Destroy(thisObject);
        }
    }
}
