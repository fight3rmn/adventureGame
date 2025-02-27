using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    public List<int> activeObjects;
    public Image cursor;
    public playerDamage pd;
    public Image itemSelected;
    GameObject[] activeObjectsArray;
    public Vector3[] selectorPositions;
    //{new Vector3(-161, 90, 0), new Vector3(-534, -184, 0), new Vector3(-414, 194, 0), new Vector3(357, -118, 0), new Vector3(410, 201, 0)};
    public Boolean gamePaused = false;
    public List<GameObject> pauseObjects;
    void Start() {
        selectorPositions = new Vector3[]{new Vector3(-606, 201, 0), new Vector3(-606, 201, 0), new Vector3(-606, 201, 0), new Vector3(-606, 201, 0), new Vector3(-606, 201, 0),  new Vector3(-606, -240, 0)};
        if(PlayerPrefs.GetInt("hasBow") == 1) {
            selectorPositions[1] = new Vector3(-225, 149, 0);
            if(PlayerPrefs.GetInt("hasBomb") == 0) {
                selectorPositions[2] = new Vector3(-225, 149, 0);
            }
        }
        if(PlayerPrefs.GetInt("hasBomb") == 1) {
            selectorPositions[2] = new Vector3(-60, 150, 0);
            if(PlayerPrefs.GetInt("hasBow") == 0) {
                selectorPositions[1] = new Vector3(-60, 150, 0);
            }
        }
        if(PlayerPrefs.GetInt("hasTeleportCrystal") == 1) {
            selectorPositions[3] = new Vector3(93, 160, 0);
            if(PlayerPrefs.GetInt("hasHealthPotion") == 0) {
                selectorPositions[4] = new Vector3(93, 160, 0);
            }
        }
        if(PlayerPrefs.GetInt("hasHealthPotion") == 1) {
            selectorPositions[4] = new Vector3(260, 157, 0);
            if(PlayerPrefs.GetInt("hasTeleportCrystal") == 0) {
                selectorPositions[3] = new Vector3(260, 157, 0);
            }
        }
        if(PlayerPrefs.GetInt("itemSelected") == 1) {
            itemSelected.transform.localPosition = new Vector3 (-174, 163, 0);
        }
        else if(PlayerPrefs.GetInt("itemSelected") == 2) {
            itemSelected.transform.localPosition = new Vector3(-14, 163, 0);
        }
        else if(PlayerPrefs.GetInt("itemSelected") == 3) {
            itemSelected.transform.localPosition = new Vector3(143, 163, 0);
        }
        else if(PlayerPrefs.GetInt("itemSelected") == 4) {
            itemSelected.transform.localPosition = new Vector3(298, 163, 0);
        }
    }
    void moveCursor(int vCur, int vNext, KeyCode k) {
        if(cursor.rectTransform.localPosition == selectorPositions[vCur] && Input.GetKeyDown(k)) {
            cursor.rectTransform.localPosition = selectorPositions[vNext];
        }
    }
    void Update() {
        if(Input.GetKeyDown("p")) {
            activeObjectsArray = UnityEngine.Object.FindObjectsOfType<GameObject>();
            for(int i = 0; i < activeObjectsArray.Length; i++) {
                if(activeObjectsArray[i].name != "Canvas" && activeObjectsArray[i].activeSelf == true && activeObjectsArray[i].tag != "MainCamera") {
                    activeObjects.Add(i);
                }
            }
            foreach(int i in activeObjects) {
               activeObjectsArray[i].SetActive(false);
            }
            foreach(GameObject i in pauseObjects) {
                i.SetActive(true);
            }
            gamePaused = true;
        }
        if(gamePaused == true) {
            //moveCursor(0, 3, KeyCode.RightArrow);
            for(int i = 3; i >= 0; i--) {
                moveCursor(i, i+1, KeyCode.RightArrow);
            }
            for(int i = 1; i <= 4; i++) {
                if(cursor.rectTransform.localPosition != selectorPositions[0]) {
                    moveCursor(i, i-1, KeyCode.LeftArrow);
                }
            }
            moveCursor(0, 5, KeyCode.DownArrow);
            moveCursor(5, 0, KeyCode.UpArrow);
            if(cursor.transform.localPosition == selectorPositions[0] && Input.GetKeyDown(KeyCode.Return)) {
                foreach(GameObject i in pauseObjects) {
                    i.SetActive(false);
                }
                foreach(int i in activeObjects) {
                    activeObjectsArray[i].SetActive(true);
                }
                activeObjects.Clear();
                pd.Start();
                gamePaused = false;
            }
            if(cursor.transform.localPosition == selectorPositions[1] && PlayerPrefs.GetInt("hasBow") == 1 && Input.GetKeyDown(KeyCode.Return)) {
                PlayerPrefs.SetInt("itemSelected", 1);
                itemSelected.transform.localPosition = new Vector3(-174, 163, 0);
            }
            else if(cursor.transform.localPosition == selectorPositions[2] && PlayerPrefs.GetInt("hasBomb") == 1 && Input.GetKeyDown(KeyCode.Return)) {
                PlayerPrefs.SetInt("itemSelected", 2);
                itemSelected.transform.localPosition = new Vector3(-14, 163, 0);
            }
            else if(cursor.transform.localPosition == selectorPositions[3] && PlayerPrefs.GetInt("hasTeleportCrystal") == 1 && Input.GetKeyDown(KeyCode.Return)) {
                PlayerPrefs.SetInt("itemSelected", 3);
                itemSelected.transform.localPosition = new Vector3(143, 163, 0);
            }
            else if(cursor.transform.localPosition == selectorPositions[4] && PlayerPrefs.GetInt("hasHealthPotion") == 1 && Input.GetKeyDown(KeyCode.Return)) {
                PlayerPrefs.SetInt("itemSelected", 4);
                itemSelected.transform.localPosition = new Vector3(298, 163, 0);
            }
            else if(cursor.transform.localPosition == selectorPositions[5] && Input.GetKeyDown(KeyCode.Return)) {
                SceneManager.LoadScene(4);
            }
        }
    }
}
