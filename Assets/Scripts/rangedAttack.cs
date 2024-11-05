using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class rangedAttack : MonoBehaviour
{
    public GameObject arrow;
    public GameObject player1;
    float timer;
    float x;
    float initialX;
    float initialY;
    public float angle;
    public float timeOnScreen;
    public float speed;
    float xSpeed;
    float ySpeed;
    void Start()
    {
        initialX = player1.transform.position.x - arrow.transform.position.x;
        initialY = player1.transform.position.y - arrow.transform.position.y;
        x = math.atan((initialY)/(initialX));
        if(player1.transform.position.x < arrow.transform.position.x) {
            arrow.transform.eulerAngles = new Vector3(0,0,90+(float)(x * 180/3.1415926535898));
        }
        else {
            arrow.transform.eulerAngles = new Vector3(0,0,-90+(float)(x * 180/3.1415926535898));
        }
        xSpeed = math.sqrt((initialX * initialX)/(Vector2.Distance(player1.transform.position, arrow.transform.position) * Vector2.Distance(player1.transform.position, arrow.transform.position)));
        ySpeed = math.sqrt((initialY * initialY)/(Vector2.Distance(player1.transform.position, arrow.transform.position) * Vector2.Distance(player1.transform.position, arrow.transform.position)));
        if(math.abs(xSpeed) > math.abs(ySpeed)) {
            float xAngle = math.asin(xSpeed);
            xSpeed = math.sin(xAngle + angle);
            ySpeed = math.cos(xAngle + angle);
        }
        else {
            float yAngle = math.asin(ySpeed);
            ySpeed = math.sin(yAngle + angle);
            xSpeed = math.cos(yAngle + angle);
        }
        if(player1.transform.position.x < arrow.transform.position.x) {
            xSpeed = -xSpeed;
        }
        if(player1.transform.position.y < arrow.transform.position.y) {
            ySpeed = -ySpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D hit) {
        Destroy(arrow);
    }
    void Update()
    {
        timer += Time.deltaTime;
        arrow.transform.position += new Vector3(xSpeed * speed * Time.deltaTime, ySpeed * speed * Time.deltaTime, 0);
        if(timer >= timeOnScreen) {
            timer = 0;
            Destroy(arrow);
        }
    }
}
