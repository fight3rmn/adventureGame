using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormHeartObtain : MonoBehaviour
{
    public GameObject thisObject;
    public int upgradeIndex;
    void Start() {
        if(PlayerPrefs.GetInt("healthUpgrade" + upgradeIndex + "Found") == 1) {
            Destroy(thisObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hit) {
        if(hit.gameObject.tag == "Player") {
            PlayerPrefs.SetInt("healthUpgrade" + upgradeIndex + "Found", 1);
            PlayerPrefs.SetInt("wormHeartObtained", 1);
            Destroy(thisObject);
        }
    }
}
