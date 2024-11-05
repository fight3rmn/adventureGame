using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class purchase : MonoBehaviour
{
    public GameObject thisObject;
    public pauseMenu pm;
    public string thisPlayerPrefs;
    public int price;
    public Text txt;
    public Vector3 thisSelectorPosition;
    public int index1;
    public int adjacentIndex;
    public GameObject thisMenuObject;

    void Start() {
        if(PlayerPrefs.GetInt(thisPlayerPrefs) == 1) {
            Destroy(thisObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D hit) {
        if(PlayerPrefs.GetInt("playerMoney") >= price) {
            PlayerPrefs.SetInt("playerMoney", PlayerPrefs.GetInt("playerMoney") - price);
            txt.text = "" + PlayerPrefs.GetInt("playerMoney");
            PlayerPrefs.SetInt(thisPlayerPrefs, 1);
            if(pm.selectorPositions[0] == pm.selectorPositions[adjacentIndex]) {
                pm.selectorPositions[adjacentIndex] = thisSelectorPosition;
            }
            pm.selectorPositions[index1] = thisSelectorPosition;
            pm.pauseObjects.Add(thisMenuObject);
            Destroy(thisObject);
        }
    }
}
