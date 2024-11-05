using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class acid : MonoBehaviour
{
    public GameObject thisObject;
    public GameObject player1;
    public float timer;
    public Vector3 direction;
    public Boolean splashing;
    public Boolean playerInside;

    void Start() {
        splashing = false;
        playerInside = false;
        direction = new Vector3(UnityEngine.Random.Range(-51, 52), UnityEngine.Random.Range(-51, 52), 0);
    }

    void OnTriggerEnter2D(Collider2D hit) {
        playerInside = true;
        if(hit.gameObject.tag == "Player" && player1.GetComponent<stomachPlayer>().acidImmune == false) {
            player1.GetComponent<playerDamage>().hitAcid();
        }
    }

    void OnTriggerExit2D(Collider2D hit) {
        playerInside = false;
    }

    void Update() {
        if(playerInside == true && player1.GetComponent<playerDamage>().poisonTicks >= 3) {
            player1.GetComponent<playerDamage>().hitAcid();
        }


        if(splashing == true) {
            timer += Time.deltaTime;
            thisObject.transform.eulerAngles = new Vector3(0, 0, (math.atan(direction.y/direction.x) * 180/math.PI));
            thisObject.transform.position += direction * Time.deltaTime;
            thisObject.GetComponent<BoxCollider2D>().enabled = true;
            thisObject.GetComponent<PolygonCollider2D>().enabled = false;
            if(thisObject.transform.position.y > -75.4 || thisObject.transform.position.y < -245) {
                direction.y *= -1;
            }

            if(thisObject.transform.position.x > 1093 || thisObject.transform.position.x < 860.7) {
                direction.x *= -1;
            }

            if(timer >= 0.35) {
                timer = 0;
                splashing = false;
                direction = new Vector3(UnityEngine.Random.Range(-51, 52), UnityEngine.Random.Range(-51, 52), 0);
                thisObject.GetComponent<BoxCollider2D>().enabled = false;
                thisObject.GetComponent<PolygonCollider2D>().enabled = true;
            }
        }
    }
}
