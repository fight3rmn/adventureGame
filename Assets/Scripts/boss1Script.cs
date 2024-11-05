using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEditor.VersionControl;
using Unity.VisualScripting;

public class boss1Script : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    public float startAnimationTime;
    public GameObject player2;
    float playerSpeed;
    public int timeMovingTowardsPlayer;
    Boolean speedSet = false;
    public float bossSpeed;
    Boolean attack3Started = false;
    public Transform thisTransform;
    int relativeLocation;
    public BoxCollider2D thisCollider;
    int moveSelected = 0;
    public List<GameObject> teleports;
    int numSummons;
    public float pauseAfterAttack;
    int summonLocation;
    int xMovement = 0;
    int yMovement = 0;
    public GameObject magicBall;
    public List<GameObject> summonList;
    public List<GameObject> teleports2;
    public Boolean stopAttack3 = false;
    public List<int> teleports3;
    int curCircle;
    void Start() {
        playerSpeed = player2.GetComponent<playerController>().defaultSpeed;
        player2.GetComponent<playerController>().speed = 0;
        player2.GetComponent<playerController>().defaultSpeed = 0;
    }
    
    void OnCollisionEnter2D(Collision2D hit) {
        if(moveSelected == 3) {
            stopAttack3 = true;
            
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= startAnimationTime) {
            if(speedSet == false) {
                player2.GetComponent<playerController>().speed = playerSpeed;
                player2.GetComponent<playerController>().defaultSpeed = playerSpeed;
                speedSet = true;
            }
            if(teleports.Count > 0 && timer >= startAnimationTime + 0.9) {
                curCircle = UnityEngine.Random.Range(0, teleports.Count);
                thisTransform.position = teleports[curCircle].transform.position;
                teleports.RemoveAt(curCircle);
                timer = startAnimationTime;
            }
            if(moveSelected == 0 && teleports.Count == 0) {
                moveSelected = UnityEngine.Random.Range(1, 4);
            }
            if(moveSelected == 1) {
                UnityEngine.Vector2 dist = new UnityEngine.Vector2(thisTransform.position.x - player2.transform.position.x, thisTransform.position.y - player2.transform.position.y);
                float xDist = math.sqrt((dist.x * dist.x)/(UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position)));
                float yDist = math.sqrt((dist.y * dist.y)/(UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position)));
                if(player2.transform.position.x < thisTransform.position.x) {
                    xDist = -xDist;
                }
                if(player2.transform.position.y < thisTransform.position.y) {
                    yDist = -yDist;
                }
                magicBall.GetComponent<rangedAttack>().player1 = player2;
                Instantiate(magicBall, new Vector3(thisTransform.position.x + (xDist * 3), thisTransform.position.y + (yDist * 3), thisTransform.position.z), quaternion.identity);
                Physics2D.IgnoreCollision(magicBall.GetComponent<CircleCollider2D>(), thisCollider);
                timer = startAnimationTime - pauseAfterAttack;
                foreach(GameObject ii in teleports2) {
                    teleports.Add(ii);
                }
                moveSelected = 0;
            }
            if(moveSelected == 2) {
                for(int i = 0; i < teleports2.Count; i++) {
                    teleports3.Add(i);
                }
                numSummons = UnityEngine.Random.Range(1, 4);
                for(int i=0; i < numSummons; i++) {
                    summonLocation = UnityEngine.Random.Range(0, teleports3.Count);
                    if(teleports2[teleports3[summonLocation]].transform.position == thisTransform.position) {
                        teleports3.RemoveAt(summonLocation);
                        summonLocation = UnityEngine.Random.Range(0, teleports3.Count);
                    }
                    Instantiate(summonList[UnityEngine.Random.Range(0, summonList.Count)], teleports2[teleports3[summonLocation]].transform.position, quaternion.identity);
                    teleports3.RemoveAt(summonLocation);
                }
                teleports3.Clear();
                timer = startAnimationTime - pauseAfterAttack;
                foreach(GameObject ii in teleports2) {
                    teleports.Add(ii);
                }
                moveSelected = 0;
            }
            if(moveSelected == 3) {
                if(attack3Started == false) {
                    relativeLocation = UnityEngine.Random.Range(0, 4);
                    attack3Started = true;
                }
                if(relativeLocation == 0) {
                    thisTransform.position = player2.transform.position + new Vector3((float)4.7, 0, 0);
                    xMovement = -1;
                    relativeLocation = 5;
                }
                else if(relativeLocation == 1) {
                    thisTransform.position = player2.transform.position + new Vector3((float)-4.7, 0, 0);
                    xMovement = 1;
                    relativeLocation = 5;
                }
                else if(relativeLocation == 2) {
                    thisTransform.position = player2.transform.position + new Vector3(0, (float)-4.7, 0);
                    yMovement = 1;
                    relativeLocation = 5;
                }
                else if(relativeLocation == 3) {
                    thisTransform.position = player2.transform.position + new Vector3(0, (float)4.7, 0);
                    yMovement = -1;
                    relativeLocation = 5;
                }
                thisTransform.position += new Vector3(bossSpeed * Time.deltaTime * xMovement, bossSpeed * Time.deltaTime * yMovement, 0);
                if(stopAttack3 == false) {
                    if(timer >= timeMovingTowardsPlayer + startAnimationTime) {
                        stopAttack3 = true;
                    }
                }
                if(stopAttack3 == true) {
                    xMovement = 0;
                    yMovement = 0;
                    moveSelected = 0;
                    timer = startAnimationTime - pauseAfterAttack;
                    stopAttack3 = false;
                    attack3Started = false;
                    foreach(GameObject ii in teleports2) {
                        teleports.Add(ii);
                    }
                    thisTransform.position = teleports[UnityEngine.Random.Range(0, teleports.Count)].transform.position;
                }
            }
        }
    }
}
