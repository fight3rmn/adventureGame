using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonThis : MonoBehaviour
{
    public boss1Script b1;
    public GameObject thisObject;
    void Start() {
        b1.summonList.Add(thisObject);
    }
    
}
