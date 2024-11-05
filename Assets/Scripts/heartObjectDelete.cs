using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartObjectDelete : MonoBehaviour
{
    public GameObject thisObject;
    public int healAmount;

    void OnTriggerEnter2D(Collider2D hit) {
        if(hit.gameObject.tag == "Player") {
            Destroy(thisObject);
        }
    }
}
