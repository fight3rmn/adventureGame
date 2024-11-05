using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class bubbleScript : MonoBehaviour
{
    public GameObject seaWorm;
    public float timer;
    public GameObject thisObject;

    void Start() {
        timer = 0;
    }

    void Update() {
        timer += Time.deltaTime;
        if(timer >= 1.5) {
            Instantiate(seaWorm, thisObject.transform.position, quaternion.identity);
            Destroy(thisObject);
        }
    }
}
