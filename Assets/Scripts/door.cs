using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public int doorRotation;
    public GameObject thisObject;
    public int leadsTo;
    void Start() {
        thisObject.transform.eulerAngles = new Vector3(0, 0, doorRotation);
    }
    void OnCollisionEnter2D(Collision2D hit) {
        if(hit.gameObject.tag == "Player") {
                SceneManager.LoadScene(leadsTo);
        }
    }
}
