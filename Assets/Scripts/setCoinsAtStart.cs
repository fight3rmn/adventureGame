using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setCoinsAtStart : MonoBehaviour
{
    public Text txt;
    void Start()
    {
        txt.text = "" + PlayerPrefs.GetInt("playerMoney");
    }
}
