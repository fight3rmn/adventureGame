using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class creeperCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp;
    public enemyMovement thisMovement;
    public GameObject explosion;
    float timer;
    public string enemyName;
    public itemDropRates irelandIDR;
    public List<GameObject> dropItems;
    int f;
    public List<int> dropRates;
    public GameObject thisObject;
    Boolean startFuse = false;
    void OnCollisionEnter2D(Collision2D hit) {
        if(hit.gameObject.name == "playerSword") {
            hp -= 5;
        }
        if(hit.gameObject.tag == "enemyArrow") {
            hp -= 3;
        }
        if(hit.gameObject.tag == "Player") {
            hp -= 1;
        }
        if(hit.gameObject.tag == "playerArrow") {
            hp -= 1;
        }
        if(hp <= 0) {
            explosion.transform.position = thisObject.transform.position;
            Instantiate(explosion, thisObject.transform.position, quaternion.identity);
            timer = 0;
            startFuse = false;
            Destroy(thisObject);
        }
    }

    void Update() {
        if(Vector2.Distance(thisMovement.player1.transform.position, thisObject.transform.position) <= thisMovement.playerDist) {
            startFuse = true;
        }
        if(startFuse == true) {
            timer += Time.deltaTime;
            if(timer >= 3.5) {
                Instantiate(explosion, thisObject.transform.position, quaternion.identity);
                timer = 0;
                startFuse = false;
            foreach(UnityEngine.Vector3 i in irelandIDR.dropDropRates()) {
                if(enemyName.Equals(irelandIDR.enemyNames[(int)i.x])) {
                    dropRates.Add((int)i.z);
                    dropItems.Add(irelandIDR.itemDrops[(int)i.y]);
                }
            }
            f = UnityEngine.Random.Range(0, dropItems.Count);
            if(UnityEngine.Random.Range(1, 201) <= dropRates[f]) {
                Instantiate(dropItems[f], this.transform.position, quaternion.identity);
            }
                Destroy(thisObject);
            }
        }
    }
}
