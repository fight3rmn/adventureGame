using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportCircleSpawn : MonoBehaviour
{

float timer;
public float timeToSpawn;
public GameObject thisObject;
public boss1Script BS;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeToSpawn) {
            thisObject.GetComponent<SpriteRenderer>().enabled = true;
            BS.teleports.Add(thisObject);
            BS.teleports2.Add(thisObject);
            thisObject.GetComponent<teleportCircleSpawn>().enabled = false;
        }
    }
}
