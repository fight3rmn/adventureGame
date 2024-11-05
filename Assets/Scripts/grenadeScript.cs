using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class grenadeScript : MonoBehaviour
{
    public GameObject thisObject;
    public float knockSpeed;
    public float initialSpeed;
    public GameObject player1;
    float xSpeed;
    float ySpeed;
    public GameObject explosion;
    public float angle;
    float timer;
    void Start() {
        float initialX = player1.transform.position.x - thisObject.transform.position.x;
        float initialY = player1.transform.position.y - thisObject.transform.position.y;
        float x = math.atan((initialY)/(initialX));
        if(player1.transform.position.x < thisObject.transform.position.x) {
            thisObject.transform.eulerAngles = new Vector3(0,0,90+(float)(x * 180/3.1415926535898));
        }
        else {
            thisObject.transform.eulerAngles = new Vector3(0,0,-90+(float)(x * 180/3.1415926535898));
        }
        xSpeed = math.sqrt((initialX * initialX)/(Vector2.Distance(player1.transform.position, thisObject.transform.position) * Vector2.Distance(player1.transform.position, thisObject.transform.position)));
        ySpeed = math.sqrt((initialY * initialY)/(Vector2.Distance(player1.transform.position, thisObject.transform.position) * Vector2.Distance(player1.transform.position, thisObject.transform.position)));
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
        if(player1.transform.position.x < thisObject.transform.position.x) {
            xSpeed = -xSpeed;
        }
        if(player1.transform.position.y < thisObject.transform.position.y) {
            ySpeed = -ySpeed;
        }
        thisObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed * initialSpeed, ySpeed * initialSpeed);
        
    }
    void OnCollisionEnter2D(Collision2D hit) {
        ContactPoint2D[] allContacts = new ContactPoint2D[hit.contactCount];
        hit.GetContacts(allContacts);
        int middle = allContacts.Length/2;
        UnityEngine.Vector2 dist = new UnityEngine.Vector2(math.abs(thisObject.transform.position.x - allContacts[middle].point.x), math.abs(thisObject.transform.position.y - allContacts[middle].point.y));
        float xSpeed = math.sqrt((dist.x * dist.x)/(UnityEngine.Vector2.Distance(thisObject.transform.position, allContacts[middle].point) * UnityEngine.Vector2.Distance(thisObject.transform.position, allContacts[middle].point)));
        float ySpeed = math.sqrt((dist.y * dist.y)/(UnityEngine.Vector2.Distance(thisObject.transform.position, allContacts[middle].point) * UnityEngine.Vector2.Distance(thisObject.transform.position, allContacts[middle].point)));
        if(thisObject.transform.position.x < allContacts[middle].point.x) {
            xSpeed = -xSpeed;
        }
        if(thisObject.transform.position.y < allContacts[middle].point.y) {
            ySpeed = -ySpeed;
        }
        thisObject.GetComponent<Rigidbody2D>().velocity += new UnityEngine.Vector2(xSpeed * knockSpeed, ySpeed * knockSpeed);
    }
    void Update() {
        timer += Time.deltaTime;
        if(timer >= 1) {
            Instantiate(explosion, this.transform.position, quaternion.identity);
            Destroy(thisObject);
        }
    }
}
