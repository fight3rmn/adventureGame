using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ingotCollect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thisObject;
    public Text txt;
    public Image uiIngot;
    void OnCollisionEnter2D(Collision2D hit) {
        if(hit.gameObject.tag == "Player") {
            PlayerPrefs.SetInt("ingots", PlayerPrefs.GetInt("ingots") + 1);
            txt.GetComponent<Text>().enabled = true;
            uiIngot.GetComponent<Image>().enabled = true;
            txt.text = "x" + PlayerPrefs.GetInt("ingots");
            Destroy(thisObject);
        }
    }
}
