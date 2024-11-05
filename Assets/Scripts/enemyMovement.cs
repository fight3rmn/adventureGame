using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public GameObject player1;
    public GameObject thisObject;
    public float speed;
    public float playerDist;
    float timer;
    float xMove;
    float yMove;

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(thisObject.transform.position, player1.transform.position) < playerDist) {
            if(player1.transform.position.y > thisObject.transform.position.y + 0.3) {
                if(player1.transform.position.x > thisObject.transform.position.x + 0.3 || player1.transform.position.x < thisObject.transform.position.x - 0.3) {
                    thisObject.transform.position += new Vector3(0, (float)0.7 * speed * Time.deltaTime, 0);
                }
                else {
                    thisObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                }
            }


            if(player1.transform.position.y < thisObject.transform.position.y - 0.3) {
                if(player1.transform.position.x > thisObject.transform.position.x + 0.3 || player1.transform.position.x < thisObject.transform.position.x - 0.3) {
                    thisObject.transform.position += new Vector3(0, (float)0.7 * -speed * Time.deltaTime, 0);
                }
                else {
                    thisObject.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
                }
            }


            if(player1.transform.position.x > thisObject.transform.position.x + 0.3) {
                if(player1.transform.position.y > thisObject.transform.position.y + 0.3 || player1.transform.position.y < thisObject.transform.position.y - 0.3) {
                    thisObject.transform.position += new Vector3((float)0.7 * speed * Time.deltaTime, 0, 0);
                }
                else {
                    thisObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                }
            }


            if(player1.transform.position.x < thisObject.transform.position.x - 0.3) {
                if(player1.transform.position.y > thisObject.transform.position.y + 0.3 || player1.transform.position.y < thisObject.transform.position.y - 0.3) {
                    thisObject.transform.position += new Vector3((float)0.7 * -speed * Time.deltaTime, 0, 0);
                }
                else {
                    thisObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                }
            }
        }
        else{
            timer += Time.deltaTime;
            if(timer >= 0.8) {
                xMove = UnityEngine.Random.Range(-2, 2);
                yMove = UnityEngine.Random.Range(-2, 2);
                timer = 0;
            }
            thisObject.transform.position += new Vector3(xMove * speed * Time.deltaTime/4, yMove * speed * Time.deltaTime/4, 0);
        }
    }
}
