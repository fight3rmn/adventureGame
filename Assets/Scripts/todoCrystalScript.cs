using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class todoCrystalScript : MonoBehaviour
{
    public GameObject arrow;
    public GameObject player1;
    public GameObject setCrystal;
    float timer;
    public GameObject todo;
    float x;
    float initialX;
    Vector3 arrowAngle;
    float initialY;
    public float speed;
    float xSpeed;
    float ySpeed;
    void Start()
    {
        initialX = player1.transform.position.x - arrow.transform.position.x;
        initialY = player1.transform.position.y - arrow.transform.position.y;
        x = math.atan((initialY)/(initialX));
        if(player1.transform.position.x < arrow.transform.position.x) {
            arrowAngle = new Vector3(0,0,90+(float)(x * 180/3.1415926535898));
        }
        else {
            arrowAngle = new Vector3(0,0,-90+(float)(x * 180/3.1415926535898));
        }
        arrow.transform.eulerAngles = arrowAngle;
        xSpeed = math.sqrt((initialX * initialX)/(Vector2.Distance(player1.transform.position, arrow.transform.position) * Vector2.Distance(player1.transform.position, arrow.transform.position)));
        ySpeed = math.sqrt((initialY * initialY)/(Vector2.Distance(player1.transform.position, arrow.transform.position) * Vector2.Distance(player1.transform.position, arrow.transform.position)));
        if(player1.transform.position.x < arrow.transform.position.x) {
            xSpeed = -xSpeed;
        }
        if(player1.transform.position.y < arrow.transform.position.y) {
            ySpeed = -ySpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D hit) {
        todo.transform.position = this.transform.position;
        todo.GetComponent<crystalShoot>().timer = 0;
        Destroy(arrow);
    }
    void Update()
    {
        timer += Time.deltaTime;
        arrow.transform.position += new Vector3(xSpeed * speed * Time.deltaTime, ySpeed * speed * Time.deltaTime, 0);
        if(timer >= 0.8) {
            timer = 0;
            Instantiate(setCrystal, arrow.transform.position, quaternion.identity);
            todo.GetComponent<crystalShoot>().timer = 0;
            Destroy(arrow);
        }
    }
}
