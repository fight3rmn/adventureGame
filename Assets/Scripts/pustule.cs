using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pustule : MonoBehaviour
{
    public stomachPlayer tumTum;
    void OnTriggerEnter2D(Collider2D hit) {
        if(hit.gameObject.tag == "Player") {
            tumTum.acidImmune = true;
        }
    }
    void OnTriggerExit2D(Collider2D hit) {
        if(hit.gameObject.tag == "Player") {
            tumTum.acidImmune = false;
        }
    }
}
