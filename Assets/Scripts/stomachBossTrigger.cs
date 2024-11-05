using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stomachBossTrigger : MonoBehaviour
{
    public stomachAttack sAttack;
    public GameObject door;
    public BoxCollider2D bCT;
    void Start() {
        bCT.enabled = true;
    }
    void OnTriggerEnter2D(Collider2D hit) {
        if(hit.gameObject.tag == "Player") {
            sAttack.enabled = true;
            door.SetActive(true);
            bCT.enabled = false;
        }
    }
}
