using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseObject : MonoBehaviour
{
    public pauseMenu pm;
    public GameObject thisObject;
    public string unlockKey;
    void Start()
    {
        if(PlayerPrefs.GetInt(unlockKey) == 1) {
            pm.pauseObjects.Add(thisObject);
        }
        thisObject.SetActive(false);
    }

}
