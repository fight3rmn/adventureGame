using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class coinCollect : MonoBehaviour
{
    // Start is called before the first frame update
    public int value;
    public GameObject thisObject;
    public Text txt;
    //void OnCollisionEnter2D(Collision2D hit) {
    void OnTriggerEnter2D(Collider2D hit) {
        if(hit.gameObject.tag == "Player") {
            PlayerPrefs.SetInt("playerMoney", PlayerPrefs.GetInt("playerMoney") + value);
            txt.text = "" + PlayerPrefs.GetInt("playerMoney");
            Destroy(thisObject);
        }
    }
    //}
}
