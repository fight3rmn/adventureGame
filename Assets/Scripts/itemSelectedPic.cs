using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSelectedPic : MonoBehaviour
{
    public GameObject bomb;
    public GameObject nullVoid;
    public GameObject teleportCrystal;
    public GameObject bow;
    public GameObject healthPot;
    public pauseMenu pm;
    GameObject[] selectableItems;
    void Start() {
        GameObject[] selectableItems1 = {nullVoid, healthPot, bomb, teleportCrystal, bow, nullVoid};
        selectableItems = selectableItems1;
        //i don't fucking know how to set the values of a global array to a series of (technically nonstatic) variables another way. I don't wanna use a list. Fuck it.

    }
    void Update()
    {
        if(pm.gamePaused == true) {
            for(int i = 0; i < selectableItems.Length; i++) {
                if(selectableItems[i].activeSelf == true) {
                    selectableItems[i].SetActive(false);
                }
                if(pm.cursor.transform.localPosition == pm.selectorPositions[i] && PlayerPrefs.GetInt(selectableItems[i].GetComponent<pauseObject>().unlockKey) == 1) {
                    selectableItems[i].SetActive(true);
                }
            }
        }
    }
}
