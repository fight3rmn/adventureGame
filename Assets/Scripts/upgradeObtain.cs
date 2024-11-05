using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeObtain : MonoBehaviour
{
    public GameObject thisObject;
    public int upgradeIndex;
    void Start() {
        if(PlayerPrefs.GetInt("healthUpgrade" + upgradeIndex + "Found") == 1) {
            Destroy(thisObject);
        }
    }
    void OnCollisionEnter2D(Collision2D hit) {
        if(hit.gameObject.tag == "Player") {
            PlayerPrefs.SetInt("healthUpgrade" + upgradeIndex + "Found", 1);
            Destroy(thisObject);
        }
    }
}
