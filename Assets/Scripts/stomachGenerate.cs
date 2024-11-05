using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class stomachGenerate : MonoBehaviour
{
    public List<GameObject> levelObjects;
    public GameObject[] activeObjectsArray;
    public GameObject heartContainer;
    public GameObject healthyTooth;
    public GameObject brokenTooth;
    public int[] toothLocation = {5, 5, 5, 5, 5};
    public GameObject coinPouch;
    public GameObject boober;
    public GameObject miniWorm;
    public booberDamage stomachBoober;
    public GameObject coin;
    public Text moneyText;
    public itemDropRates idr;
    public GameObject player1;
    void Start()
    {
        stomachBoober.spawnBoobers();


        
        if(PlayerPrefs.GetInt("wormHeartObtained") != 0) {
            heartContainer = coinPouch;
        }
        coin.GetComponent<coinCollect>().txt = moneyText;
        miniWorm.GetComponent<swordCollision>().irelandIDR = idr;
        miniWorm.GetComponent<enemyMovement>().player1 = player1;

        List<Vector3> spawnCoords = new List<Vector3>();
        List<Vector3> spawnCoords2 = new List<Vector3>();
        Vector3 firstSpawnCoord = new Vector3(-75, -145, 0);
        for(int i = 0; i < 5; i++) {
            spawnCoords.Add(firstSpawnCoord);
            firstSpawnCoord += new Vector3(200, 0, 0);
        }
        firstSpawnCoord = new Vector3(-75, -190, 0);
        for(int i = 0; i < 5; i++) {
            spawnCoords2.Add(firstSpawnCoord);
            firstSpawnCoord += new Vector3(200, 0, 0);
        }





        activeObjectsArray = UnityEngine.Object.FindObjectsOfType<GameObject>();
        for(int i = 0; i < activeObjectsArray.Length; i++) {
            if(activeObjectsArray[i].tag == "wall" || activeObjectsArray[i].tag == "stomachObject") {
                levelObjects.Add(activeObjectsArray[i]);
            }
        }

        int heartLocation = UnityEngine.Random.Range(0, 10);
        int booberLocation = heartLocation;
        while(booberLocation == heartLocation) {
            booberLocation = UnityEngine.Random.Range(0, 9);
        }
        if(heartLocation < 5) {
            heartContainer.transform.position = spawnCoords[heartLocation];
            toothLocation[heartLocation] = 0;
        }
        else {
            heartContainer.transform.position = spawnCoords2[heartLocation - 5];
            toothLocation[heartLocation - 5] = 2;
        }
        if(booberLocation < 5) {
            boober.transform.position = spawnCoords[booberLocation];
                int numWorms = UnityEngine.Random.Range(2, 5);
                for(int ii = 0; ii < numWorms; ii++) {
                    Instantiate(miniWorm, spawnCoords[booberLocation], quaternion.identity);
                }
                toothLocation[booberLocation] = 0;
        }
        else {
            boober.transform.position = spawnCoords2[booberLocation - 5];
                int numWorms = UnityEngine.Random.Range(2, 5);
                for(int ii = 0; ii < numWorms; ii++) {
                    Instantiate(miniWorm, spawnCoords2[booberLocation-5], quaternion.identity);
                }
                toothLocation[booberLocation - 5] = 2;
        }
        for(int i = 0; i < spawnCoords.Count; i++) {
            int wormLocation = UnityEngine.Random.Range(0, 8);
            if(wormLocation <= 1 && i != heartLocation && i != booberLocation) {
                int numWorms = UnityEngine.Random.Range(2, 5);
                for(int ii = 0; ii < numWorms; ii++) {
                    Instantiate(miniWorm, spawnCoords[i], quaternion.identity);
                }
                toothLocation[i] = 1;
            }
            if(wormLocation >= 6 && i+5 != heartLocation && i+5 != booberLocation) {
                int numWorms = UnityEngine.Random.Range(2, 5);
                for(int ii = 0; ii < numWorms; ii++) {
                    Instantiate(miniWorm, spawnCoords2[i], quaternion.identity);
                }
                toothLocation[i] = 3;
            }
        }
        for(int i = 0; i < spawnCoords.Count; i++) {
            if(UnityEngine.Random.Range(0, 5) <= 1 && i != heartLocation) {
                int numCoins = UnityEngine.Random.Range(3, 7);
                for(int ii = 0; ii < numCoins; ii++) {
                    Instantiate(coin, spawnCoords[i] + new Vector3(UnityEngine.Random.Range(-34, 32), UnityEngine.Random.Range(-6, 6), 0), quaternion.identity);
                }
                if(i < 5) {
                    if(toothLocation[i] == 5) {
                        if(UnityEngine.Random.Range(0, 2) == 0) {
                            toothLocation[i] = 0;
                        }
                        else {
                            toothLocation[i] = 3;
                        }
                    }
                }
            }
            if(UnityEngine.Random.Range(0, 5) <= 1 && i+5 != heartLocation) {
                int numCoins = UnityEngine.Random.Range(3, 7);
                for(int ii = 0; ii < numCoins; ii++) {
                    Instantiate(coin, spawnCoords2[i] + new Vector3(UnityEngine.Random.Range(-34, 32), UnityEngine.Random.Range(-6, 6), 0), quaternion.identity);
                }
                if(i >= 5) {
                    if(toothLocation[i-5] == 5) {
                        if(UnityEngine.Random.Range(0, 2) == 0) {
                            toothLocation[i] = 2;
                        }
                        else {
                            toothLocation[i] = 1;
                        }
                    }
                }
            }
        }


        for(int i = 0; i<5; i++) {
            if(toothLocation[i] == 5) {
                toothLocation[i] = 0;
            }
        }


        for(int i = 0; i < 5; i++) {
            if(toothLocation[i] == 0) {
                Instantiate(healthyTooth, new Vector3((19*i) + UnityEngine.Random.Range(0, 19) - 248, (float)-141.8 - UnityEngine.Random.Range(0, 26), 0), healthyTooth.transform.rotation);
            }
            if(toothLocation[i] == 1) {
                Instantiate(brokenTooth, new Vector3((19*i) + UnityEngine.Random.Range(0, 19) - 248, (float)-141.8 - UnityEngine.Random.Range(0, 26), 0), healthyTooth.transform.rotation);
            }
            if(toothLocation[i] == 2) {
                Instantiate(healthyTooth, new Vector3((19*i) + UnityEngine.Random.Range(0, 19) - 248, (float)-196 + UnityEngine.Random.Range(0, 26), 0), brokenTooth.transform.rotation);
            }
            if(toothLocation[i] == 3) {
                Instantiate(brokenTooth, new Vector3((19*i) + UnityEngine.Random.Range(0, 19) - 248, (float)-196 + UnityEngine.Random.Range(0, 26), 0), brokenTooth.transform.rotation);
            }
        }


        for(int i = 0; i<levelObjects.Count;i++) {
            Instantiate(levelObjects[i], levelObjects[i].transform.position + new Vector3(200, 0, 0), levelObjects[i].transform.rotation);
            Instantiate(levelObjects[i], levelObjects[i].transform.position + new Vector3(400, 0, 0), levelObjects[i].transform.rotation);
            Instantiate(levelObjects[i], levelObjects[i].transform.position + new Vector3(600, 0, 0), levelObjects[i].transform.rotation);
            Instantiate(levelObjects[i], levelObjects[i].transform.position + new Vector3(800, 0, 0), levelObjects[i].transform.rotation);
        }
    }
}
