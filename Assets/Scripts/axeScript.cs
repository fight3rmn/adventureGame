using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class axeScript : MonoBehaviour
{
    
    float initialX;
    float initialY;
    public GameObject player1;
    public GameObject axe;
    float x;
    float timer;
    
    void Start() {
        initialX = player1.transform.position.x - axe.transform.position.x;
        initialY = player1.transform.position.y - axe.transform.position.y;
        x = math.atan((initialY)/(initialX));
        if(player1.transform.position.x < axe.transform.position.x) {
            axe.transform.eulerAngles = new Vector3(0,0,90+(float)(x * 180/3.1415926535898));
        }
        else {
            axe.transform.eulerAngles = new Vector3(0,0,-90+(float)(x * 180/3.1415926535898));
        }
    }

    void Update() {
        timer += Time.deltaTime;
        if(timer >= 0.3) {
            Destroy(axe);
        }
    }
}
