using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using System.Numerics;
using System.Linq;

public class swordCollision : MonoBehaviour
{
    public int hp;
    public GameObject thisObject;
    public string bossName;
    public string enemyName;
    public itemDropRates irelandIDR;
    public List<GameObject> dropItems;
    int f;
    public List<int> dropRates;
    public Boolean boss;
    float timer;

    void Start() {
        if(boss == true && PlayerPrefs.GetInt("bossName") == 1) {
            Destroy(thisObject);
        }
    }
    void OnCollisionEnter2D(Collision2D hit) {
        if(hit.gameObject.name == "playerSword") {
            hp -= 4 + PlayerPrefs.GetInt("playerWeaponDamage");
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
            thisObject.GetComponent<Rigidbody2D>().velocity += new UnityEngine.Vector2(xSpeed * 15, ySpeed * 15);
        }
        if(hit.gameObject.tag == "enemyArrow") {
            hp -= 3;
        }
        if(hit.gameObject.tag == "explosion") {
            hp -= 9;
        }
        if(hit.gameObject.tag == "playerArrow") {
            hp -= PlayerPrefs.GetInt("playerWeaponDamage");
        }
        if(hp <= 0) {
            if(boss == true) {
                PlayerPrefs.SetInt(bossName, 1);
            }
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
