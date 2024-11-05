using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class stomachAttack : MonoBehaviour
{
    public float timer;
    public Boolean attacking;
    public GameObject[] activeObjectsArray;
    public GameObject player1;
    List<GameObject> acidObjects = new List<GameObject>();
    public Vector3[] possibleDirections;
    public int atkNum;
    public float acidTimer;
    public float booberTimer;
    public float atk2Timer;
    public float throwTimerInterval;
    public booberDamage booberD;
    public GameObject safePustule;
    public List<GameObject> safePustules;
    public List<GameObject> bigAcids;
    Boolean directionSelected;
    public int booberShrink;
    public int throwSpeed;
    public Boolean acidSplashed;
    public float throwTimer;
    public int throwDirection;
    void Start()
    {
        Vector3[] assFuck = {new Vector3(throwSpeed, 0, 0), new Vector3(-throwSpeed, 0, 0), new Vector3(0, throwSpeed, 0), new Vector3(0, -throwSpeed, 0)};
        possibleDirections = assFuck;
        booberShrink = 0;
        directionSelected = false;
        activeObjectsArray = UnityEngine.Object.FindObjectsOfType<GameObject>();
        atkNum = 0;
        timer = 0;
        acidSplashed = false;
        attacking = false;
        for(int i = 0; i < activeObjectsArray.Length; i++) {
            if(activeObjectsArray[i].tag == "acid") {
                acidObjects.Add(activeObjectsArray[i]);
            }
        }
    }

    void Update()
    {
        if(attacking == false) {
            timer += Time.deltaTime;
        }
        else {
            booberTimer += Time.deltaTime;
        }
        if(timer >= 5) {
            timer = 0;
            atkNum = UnityEngine.Random.Range(1, 4);
            attacking = true;
        }
        if(booberTimer >= 0.068 && booberShrink < 5) {
            foreach(GameObject i in booberD.spawner.boobers) {
                i.transform.localScale.Set(i.transform.localScale.x - (float)0.19, i.transform.localScale.y - (float)0.19, 1);
            }
            booberTimer = 0;
            booberShrink++;
        }
        if(booberShrink == 5) {
            foreach(GameObject i in booberD.spawner.boobers) {
                Destroy(i);
            }
            booberShrink++;
            booberTimer = 0;
        }

        if(atkNum == 1) {
            if(acidSplashed == false) {
                foreach(GameObject i in acidObjects) {
                    i.GetComponent<acid>().splashing = true;
                }
                acidSplashed = true;
            }
            if(acidObjects[acidObjects.Count - 1].GetComponent<acid>().splashing == false) {
                atkNum = 0;
                attacking = false;
                acidSplashed = false;
                booberShrink = 0;
                booberD.spawnBoobers();
            }
        }

        if(atkNum == 2) {
            throwTimer += Time.deltaTime;
            atk2Timer += Time.deltaTime;
            if(directionSelected == false) {
                throwDirection = UnityEngine.Random.Range(0, 4);
                directionSelected = true;
                throwTimerInterval = UnityEngine.Random.Range((float)0.3, (float)0.7);
            }
            player1.transform.position += new Vector3(possibleDirections[throwDirection].x * Time.deltaTime, possibleDirections[throwDirection].y * Time.deltaTime, 0);
            if(throwTimer >= throwTimerInterval) {
                throwTimer = 0;
                directionSelected = false;
            }
            if(atk2Timer >= 5.5) {
                atkNum = 0;
                throwTimer = 0;
                atk2Timer = 0;
                directionSelected = false;
                booberD.spawnBoobers();
                booberShrink = 0;
                attacking = false;
            }
        }

        if(atkNum == 3) {
            acidTimer += Time.deltaTime;
            /*for(int i = 1; i < acidObjects.Count; i++) {
                Destroy(acidObjects[i]);
            }*/
            if(bigAcids.Count <= 1) {
                acidObjects[0].transform.position = new Vector3(248, -48, 0);
                bigAcids.Add(Instantiate(acidObjects[0], new Vector3((float)915.85, (float)-114.45, 0), quaternion.identity));
                bigAcids.Add(Instantiate(acidObjects[0], new Vector3((float)1036.15, (float)-203.95, 0), quaternion.identity));
                bigAcids.Add(Instantiate(acidObjects[0], new Vector3((float)915.85, (float)-203.95, 0), quaternion.identity));
                bigAcids.Add(Instantiate(acidObjects[0], new Vector3((float)1036.15, (float)-114.45, 0), quaternion.identity));
                foreach(GameObject i in bigAcids) {
                    i.GetComponent<SpriteRenderer>().sortingLayerName = "passThrough";
                }
                safePustules.Add(Instantiate(safePustule, new Vector3(UnityEngine.Random.Range(857, 974), UnityEngine.Random.Range(-251, -157), 0), quaternion.identity));
                safePustules.Add(Instantiate(safePustule, new Vector3(UnityEngine.Random.Range(978, 1094), UnityEngine.Random.Range(-162, -67), 0), quaternion.identity));
                safePustules.Add(Instantiate(safePustule, new Vector3(UnityEngine.Random.Range(857, 974), UnityEngine.Random.Range(-162, -67), 0), quaternion.identity));
                safePustules.Add(Instantiate(safePustule, new Vector3(UnityEngine.Random.Range(978, 1094), UnityEngine.Random.Range(-250, -157), 0), quaternion.identity));
                safePustules.Add(Instantiate(safePustule, new Vector3(UnityEngine.Random.Range(916, 1036), UnityEngine.Random.Range(-115, -204), 0), quaternion.identity));
            }
            if(acidTimer < 10) {
                foreach(GameObject i in bigAcids) {
                    i.transform.localScale = new Vector3((float)4.2 * acidTimer, (float)4.2 * acidTimer, 0);
                }
            }
            if(acidTimer >= 11) {
                if(acidSplashed == false) {
                    foreach(GameObject i in acidObjects) {
                        i.GetComponent<acid>().splashing = true;
                    }
                    acidSplashed = true;
                }
                foreach(GameObject i in bigAcids) {
                    i.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - ((acidTimer - 11)/2));
                }
            }
            if(acidTimer >= 13) {
                foreach(GameObject i in bigAcids) {
                    Destroy(i);
                }
                bigAcids.Clear();
                foreach(GameObject i in safePustules) {
                    Destroy(i);
                }
                safePustules.Clear();
                booberD.spawnBoobers();
                atkNum = 0;
                acidSplashed = false;
                acidTimer = 0;
                booberShrink = 0;
                attacking = false;
            }
        }

    }
}
