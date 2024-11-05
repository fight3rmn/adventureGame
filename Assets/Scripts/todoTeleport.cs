using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class todoTeleport : MonoBehaviour
{
    public List<Vector3> teleportPositions;
    public GameObject thisTodo;
    public GameObject arrow;
    float timer;
    public GameObject energyLine;
    public GameObject player2;
    public int numTodo;
    bool sequence1Complete = false;
    bool sequence2Complete = false;
    int tpCount;
    float todoSpeed;
    int i;
    void Start() {
        i = 0;
        todoSpeed = thisTodo.GetComponent<enemyMovement>().speed;
    }

    void tpSequence1() {
        timer = 0;
        if(teleportPositions.Count >= 3) {
            thisTodo.GetComponent<enemyMovement>().speed = 0;
            float initialX = teleportPositions[0].x - thisTodo.transform.position.x;
            float initialY = teleportPositions[0].y - thisTodo.transform.position.y;
            float x = math.atan((initialY)/(initialX));
            if(teleportPositions[0].x < thisTodo.transform.position.x) {
                energyLine.GetComponent<energyLineAngle>().lineAngle = new Vector3(0,0,90+(float)(x * 180/3.1415926535898));
            }
            else {
                energyLine.GetComponent<energyLineAngle>().lineAngle = new Vector3(0,0,-90+(float)(x * 180/3.1415926535898));
            }
            energyLine.transform.localScale = new Vector3(((float)1.83*(Vector3.Distance(teleportPositions[0], teleportPositions[1])/19)), 1, 1);
            Instantiate(energyLine, new Vector3((this.transform.position.x + teleportPositions[0].x)/2, (this.transform.position.y + teleportPositions[0].y)/2, 0), quaternion.identity);
            thisTodo.GetComponent<crystalShoot>().timer = 0;
            sequence1Complete = true;
        }
    }
    void tpSequence2() {
        if(i<teleportPositions.Count - 1) {
            float initialX = teleportPositions[i+1].x - teleportPositions[i].x;
            float initialY = teleportPositions[i+1].y - teleportPositions[i].y;
            float x = math.atan((initialY)/(initialX));
            if(teleportPositions[i].x < teleportPositions[i+1].x) {
                energyLine.GetComponent<energyLineAngle>().lineAngle = new Vector3(0,0,90+(float)(x * 180/3.1415926535898));
            }
            else {
                energyLine.GetComponent<energyLineAngle>().lineAngle = new Vector3(0,0,-90+(float)(x * 180/3.1415926535898));
            }
            energyLine.transform.localScale = new Vector3(((float)1.83*(Vector3.Distance(teleportPositions[i], teleportPositions[i+1])/19)), 1, 1);
            Instantiate(energyLine, new Vector3((teleportPositions[i].x + teleportPositions[i+1].x)/2, (teleportPositions[i].y + teleportPositions[i+1].y)/2, 0), quaternion.identity);
            thisTodo.GetComponent<crystalShoot>().timer = 0;
            i++;
        }
        else {
            i = 0;
            tpCount = teleportPositions.Count;
            sequence2Complete = true;
        }
        timer = 0;
    }
    void tpSequence3() {
        if(i < tpCount) {
            thisTodo.transform.position = teleportPositions[0];
            thisTodo.GetComponent<crystalShoot>().timer = 0;

            UnityEngine.Vector2 dist = new UnityEngine.Vector2(thisTodo.transform.position.x - player2.transform.position.x, thisTodo.transform.position.y - player2.transform.position.y);
            float xDist = math.sqrt((dist.x * dist.x)/(UnityEngine.Vector2.Distance(thisTodo.transform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisTodo.transform.position, player2.transform.position)));
            float yDist = math.sqrt((dist.y * dist.y)/(UnityEngine.Vector2.Distance(thisTodo.transform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisTodo.transform.position, player2.transform.position)));
            if(player2.transform.position.x < thisTodo.transform.position.x) {
                xDist = -xDist;
            }
            if(player2.transform.position.y < thisTodo.transform.position.y) {
                yDist = -yDist;
            }
            Instantiate(arrow, new Vector3(thisTodo.transform.position.x + (xDist * (float)2.5), thisTodo.transform.position.y + (yDist * (float)2.5), thisTodo.transform.position.z), quaternion.identity);
            arrow.GetComponent<rangedAttack>().player1 = player2;
            Physics2D.IgnoreCollision(arrow.GetComponent<BoxCollider2D>(), thisTodo.GetComponent<BoxCollider2D>());

            i++;
        }
        else {
            teleportPositions.Clear();
            sequence1Complete = false;
            sequence2Complete = false;
            i = 0;
        }
        timer = 0;
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if(sequence1Complete == false) {
            tpSequence1();
        }
        else if(timer >= 0.35 && sequence2Complete == false) {
            tpSequence2();
        }
        if(sequence2Complete == true && timer >= 0.35) {
            tpSequence3();
            thisTodo.GetComponent<enemyMovement>().speed = todoSpeed;
        }
        /*if(teleportPositions.Count >= 3) {
            energyLine.GetComponent<energyLineAngle>().lineAngle = lineAngles[0];
            Instantiate(energyLine, new Vector3((this.transform.position.x + teleportPositions[0].x)/2, (this.transform.position.y + teleportPositions[0].y)/2, 0), quaternion.identity);
            thisTodo.GetComponent<crystalShoot>().timer = 0;
            while(timer < 0.35) {timer += Time.deltaTime;}
            timer = 0;
            for(int i = 0; i<teleportPositions.Count - 1; i++) {
                energyLine.GetComponent<energyLineAngle>().lineAngle = lineAngles[i+1];
                Instantiate(energyLine, new Vector3((teleportPositions[i].x + teleportPositions[i+1].x)/2, (teleportPositions[i].y + teleportPositions[i+1].y)/2, 0), quaternion.identity);
                thisTodo.GetComponent<crystalShoot>().timer = 0;
                while(timer < 0.35) {timer += Time.deltaTime;}
                timer = 0;
            }
            foreach(Vector3 i in teleportPositions) {
                thisTodo.transform.position = i;
                thisTodo.GetComponent<crystalShoot>().timer = 0;
                while(timer < 0.35) {timer += Time.deltaTime;}
                timer = 0;
            }
            teleportPositions.Clear();
            lineAngles.Clear();
        }*/
    }
}
