using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class ingotUI : MonoBehaviour
{
    public UnityEngine.UI.Image thisImage;
    public Text thisText;
    void Start()
    {
        if(PlayerPrefs.GetInt("ingots") != 0) {
            thisImage.GetComponent<UnityEngine.UI.Image>().enabled = true;
            thisText.GetComponent<Text>().enabled = true;
            thisText.text = "x" + PlayerPrefs.GetInt("ingots");
        }
    }
}
