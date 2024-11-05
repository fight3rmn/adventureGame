using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UIElements;

public class heartUpdate : MonoBehaviour
{
    public GameObject thisObject;
    public Sprite poisonedHeart;
    public Sprite heart;
    public Sprite halfHeart;
    public Sprite poisonedHalfHeart;
    public playerDamage pd;
    public int hpRepresenting;
    void Start() {
        pd.hearts.Add(thisObject.GetComponent<heartUpdate>());
        onHit(halfHeart, heart);
    }
    public void onHit(Sprite halfy, Sprite wholeHeart) {
        if(PlayerPrefs.GetInt("playerHp") == hpRepresenting - 1) {
            thisObject.GetComponent<UnityEngine.UI.Image>().sprite = halfy;
        }
        else {
            thisObject.GetComponent<UnityEngine.UI.Image>().sprite = wholeHeart;
        }
        if(PlayerPrefs.GetInt("playerHp") < hpRepresenting - 1) {
            thisObject.GetComponent<UnityEngine.UI.Image>().enabled = false;
        }
        if(PlayerPrefs.GetInt("playerHp") >= hpRepresenting - 1) {
            thisObject.GetComponent<UnityEngine.UI.Image>().enabled = true;
        }
    }
}
