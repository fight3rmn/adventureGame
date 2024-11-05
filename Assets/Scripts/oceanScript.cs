using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class oceanScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject bubbles;
    public GameObject seaWorm;
    public float bubbleOffsetX;
    public float bubbleOffsetY;
    public int radiusSize;
    public Boolean readyForBubbles;
    public Boolean speedReduced;

    void Start() {
        bubbleOffsetX = 0;
        bubbleOffsetY = 0;
        readyForBubbles = true;
        speedReduced = false;
        seaWorm.GetComponent<seaWormScript>().seaScript = this;
    }
    void Update() {
        if(Vector3.Distance(player1.transform.position, this.transform.position) <= radiusSize) {
            if(readyForBubbles == true) {
                if(Input.GetKey("w")) {
                    bubbleOffsetY = (float)4.5;
                }
                else if(Input.GetKey("s")) {
                    bubbleOffsetY = (float)-4.5;
                }
                else if(bubbleOffsetY != 0) {
                    bubbleOffsetY = 0;
                }
                if(Input.GetKey("d")) {
                    bubbleOffsetX = (float)4.5;
                }
                else if(Input.GetKey("a")) {
                    bubbleOffsetX = (float)-4.5;
                }
                else if(bubbleOffsetX != 0) {
                    bubbleOffsetX = 0;
                }
                Instantiate(bubbles, new Vector3(player1.transform.position.x + bubbleOffsetX, player1.transform.position.y + bubbleOffsetY, this.transform.position.z), quaternion.identity);
                readyForBubbles = false;
            }
        }
        if(speedReduced == false && math.abs(this.transform.position.x - player1.transform.position.x) < 117 && math.abs(this.transform.position.y - player1.transform.position.y) < 96.5) {
                player1.GetComponent<playerController>().defaultSpeed *= (float)0.69;
                player1.GetComponent<playerController>().speed = player1.GetComponent<playerController>().defaultSpeed;
                speedReduced = true;
            }
        else if (speedReduced == true && math.abs(this.transform.position.x - player1.transform.position.x) >= 117 || speedReduced == true && math.abs(this.transform.position.y - player1.transform.position.y) >= 96.5) {
            player1.GetComponent<playerController>().defaultSpeed = player1.GetComponent<playerController>().defaultSpeed/(float)0.69;
            player1.GetComponent<playerController>().speed = player1.GetComponent<playerController>().defaultSpeed;
            speedReduced = false;
        }
    }
}
