using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using System.Numerics;
using System.Linq;
using System.Xml.Serialization;

public class booberDamage : MonoBehaviour
{
    public GameObject thisObject;
    public GameObject blueBoober;
    public string enemyName;
    public itemDropRates irelandIDR;
    public List<GameObject> dropItems;
    int f;
    public GameObject purpleBoober;
    public booberDamage spawner;
    public List<int> dropRates;
    public Boolean blue = false;
    public UnityEngine.Vector3 pulse = new UnityEngine.Vector3((float)0.002, (float)0.002, 0);
    public List<GameObject> boobers;
    public float timer;
    public float timer2;

    public void spawnBoobers() {
        int loops = UnityEngine.Random.Range(3, 6);
        boobers.Clear();
        for(int i = 0; i< loops; i++) {
            int spawnX = UnityEngine.Random.Range(861, 1093);
            int spawnY = UnityEngine.Random.Range(-244, -75);
            if(UnityEngine.Random.Range(0, 9) == 1) {
                blue = true;
            }
            if(blue == false) {
                boobers.Add(Instantiate(thisObject, new UnityEngine.Vector3(spawnX, spawnY, 0), quaternion.identity));
            }
            else {
                boobers.Add(Instantiate(blueBoober, new UnityEngine.Vector3(spawnX, spawnY, 0), quaternion.identity));
                boobers[boobers.Count-1].GetComponent<booberDamage>().blue = true;
                blue = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D hit) {
        if(hit.gameObject.name == "playerSword") {
            PlayerPrefs.SetInt("wormHP", PlayerPrefs.GetInt("wormHP") - (4 + PlayerPrefs.GetInt("playerWeaponDamage")));
        }
        if(hit.gameObject.tag == "enemyArrow") {
            PlayerPrefs.SetInt("wormHP", PlayerPrefs.GetInt("wormHP") - (3));
        }
        if(hit.gameObject.tag == "explosion") {
            if(blue == true) {
                Instantiate(purpleBoober, new UnityEngine.Vector3(983, -168, 0), quaternion.identity);
                Instantiate(purpleBoober, new UnityEngine.Vector3(983, -168, 0), quaternion.identity);
                foreach(GameObject i in spawner.boobers) {
                    Destroy(i);
                }
            }
            PlayerPrefs.SetInt("wormHP", PlayerPrefs.GetInt("wormHP") - (9));
        }
        if(hit.gameObject.tag == "playerArrow") {
            PlayerPrefs.SetInt("wormHP", PlayerPrefs.GetInt("wormHP") - (PlayerPrefs.GetInt("playerWeaponDamage")));
        }
        if(PlayerPrefs.GetInt("wormHP") <= 0) {
            foreach(UnityEngine.Vector3 i in irelandIDR.dropDropRates()) {
                if(enemyName.Equals(irelandIDR.enemyNames[(int)i.x])) {
                    dropRates.Add((int)i.z);
                    dropItems.Add(irelandIDR.itemDrops[(int)i.y]);
                }
            }
            f = UnityEngine.Random.Range(0, dropItems.Count);
            if(UnityEngine.Random.Range(1, 201) <= dropRates[f]) {
                dropItems[f].transform.localScale = new UnityEngine.Vector3(10, 10, 10);
                Instantiate(dropItems[f], new UnityEngine.Vector3(983, -168, 0), quaternion.identity);
            }
            Destroy(thisObject);
        }
    }

    void Update() {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if(timer >= 0.1) {
            thisObject.transform.localScale += pulse;
            timer = 0;
        }
        if(timer2 >= 2.3) {
            pulse.x = pulse.x * -1;
            pulse.y = pulse.y * -1;
            timer2 = 0;
        }
    }
}
