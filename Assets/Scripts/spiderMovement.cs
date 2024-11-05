using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class spiderMovement : MonoBehaviour
{
    float timer;
    public Transform thisTransform;
    public Transform playerTransform;
    public float speed;
    public int followRange;
    float xMove;
    Boolean followPlayer = false;
    float yMove;
    float xDist;
    float yDist;
    UnityEngine.Vector2 dist;
    Boolean moveVariables = false;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1.25) {
            if(moveVariables == false) {
                xMove = UnityEngine.Random.Range(-6, 7);
                yMove = UnityEngine.Random.Range(-6, 7);
                if(UnityEngine.Random.Range(1,6) <= 2) {
                    followPlayer = true;
                }
                else {
                    followPlayer = false;
                }
                moveVariables = true;
            }
            if(UnityEngine.Vector2.Distance(thisTransform.position, playerTransform.position) < followRange && followPlayer == true) {
                dist = new UnityEngine.Vector2(thisTransform.position.x - playerTransform.position.x, thisTransform.position.y - playerTransform.position.y);
                xDist = math.sqrt((dist.x * dist.x)/(UnityEngine.Vector2.Distance(thisTransform.position, playerTransform.position) * UnityEngine.Vector2.Distance(thisTransform.position, playerTransform.position)));
                yDist = math.sqrt((dist.y * dist.y)/(UnityEngine.Vector2.Distance(thisTransform.position, playerTransform.position) * UnityEngine.Vector2.Distance(thisTransform.position, playerTransform.position)));
                if(playerTransform.position.x < thisTransform.position.x) {
                    xDist = -xDist;
                }
                if(playerTransform.position.y < thisTransform.position.y) {
                    yDist = -yDist;
                }
                xMove = math.abs(xMove);
                yMove = math.abs(yMove);
                thisTransform.position += new UnityEngine.Vector3(xMove * xDist * speed * Time.deltaTime, xMove * yDist * speed * Time.deltaTime, 0);
            }
            else {
                thisTransform.position += new UnityEngine.Vector3(xMove*speed * Time.deltaTime, yMove*speed * Time.deltaTime, 0);
            }
            if(timer >= 1.5) {
                timer = 0;
                moveVariables = false;
            }
        }
    }
}
