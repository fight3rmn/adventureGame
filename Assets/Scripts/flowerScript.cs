using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.Mathematics;
using UnityEngine;

public class flowerScript : MonoBehaviour
{
    public float aggroDist;
    public GameObject player1;
    public GameObject safeFog;
    public float timeBetweenAttacks;
    public GameObject poisonFog;
    float timer = (float)2.3;
    public GameObject sleepFog;
    void Update() {
        if(Vector3.Distance(player1.transform.position, this.transform.position) <= aggroDist) {
            timer += Time.deltaTime;
            if(timer >= timeBetweenAttacks) {
                int x = UnityEngine.Random.Range(0, 3);
                safeFog.GetComponent<fogScript>().effect = 1;
                poisonFog.GetComponent<fogScript>().effect = 2;
                sleepFog.GetComponent<fogScript>().effect = 3;
                if(x == 0) {
                    safeFog.GetComponent<fogScript>().player1 = player1;
                    Instantiate(safeFog, this.transform.position, quaternion.identity);
                }
                else if(x == 1) {
                    poisonFog.GetComponent<fogScript>().player1 = player1;
                    Instantiate(poisonFog, this.transform.position, quaternion.identity);
                }
                else {
                    sleepFog.GetComponent<fogScript>().player1 = player1;
                    Instantiate(sleepFog, this.transform.position, quaternion.identity);
                }
                timer = 0;
            }
        }
    }
}
