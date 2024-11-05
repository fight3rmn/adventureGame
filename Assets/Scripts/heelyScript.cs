using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heelyScript : MonoBehaviour
{
    public GameObject thisObject;
    public pauseMenu pm;
    public string thisPlayerPrefs;
    public GameObject thisMenuObject;
    public GameObject thisMenuObject2;

    void Start() {
        if(PlayerPrefs.GetInt(thisPlayerPrefs) == 1) {
            Destroy(thisObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D hit) {
        PlayerPrefs.SetInt(thisPlayerPrefs, 1);
        pm.pauseObjects.Add(thisMenuObject);
        pm.pauseObjects.Add(thisMenuObject2);
        Destroy(thisObject);
    }
}
