using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeTeleportCrystal : MonoBehaviour
{
    public GameObject thisObject;
    void OnCollisionEnter2D(Collision2D hit) {
        if(hit.gameObject.tag == "Player") {
            PlayerPrefs.SetInt("teleportCrystalSet", 0);
            Destroy(thisObject);
        }
    }
}
