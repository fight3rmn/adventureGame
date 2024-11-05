using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UIElements;

public class testChagneImage : MonoBehaviour
{
    public Sprite newSprite;
    public GameObject thisObject;
    void Start()
    {
        thisObject.GetComponent<UnityEngine.UI.Image>().sprite = newSprite;
    }
}
