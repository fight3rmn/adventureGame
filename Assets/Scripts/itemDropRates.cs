using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDropRates : MonoBehaviour
{
    public List<string> enemyNames;
    public GameObject coin;
    public GameObject coinBag;
    public GameObject halfHeart;
    public GameObject fullHeart;
    public GameObject bomb;
    public GameObject superCoin;
    public GameObject tpCrystal;
    public List<GameObject> itemDrops;
    public Vector3[] dropDropRates() {
        Vector3[] dropRates = {new Vector3(0, 2, 200), new Vector3(1, 4, 200), new Vector3(2, 0, 200), new Vector3(2, 1, 199), new Vector3(2, 5, 121), new Vector3(3, 0, 65), new Vector3(3, 1, 80), 
        new Vector3(3, 3, 70), new Vector3(4, 5, 75), new Vector3(4, 1, 100), new Vector3(5, 0, 87), new Vector3(5, 1, 91), new Vector3(5, 3, 82), new Vector3(5, 5, 75), new Vector3(6, 0, 155), new Vector3(6, 1, 123), new Vector3(6, 3, 109), 
        new Vector3(4, 3, 120), new Vector3(8, 6, 200), new Vector3(7, 0, 154), new Vector3(7 , 1, 199), new Vector3(7, 3, 150), new Vector3(7, 5, 75), new Vector3(9, 4, 200)};
        return dropRates;
    }
    void Start()
    {
        enemyNames.Add("daria");
        enemyNames.Add("todo");
        enemyNames.Add("reginaldKnight");
        enemyNames.Add("heliaMeleeAttacker");
        enemyNames.Add("megumin");
        enemyNames.Add("MaekoRangedAttacker");
        enemyNames.Add("aaronSpider");
        enemyNames.Add("lindseyFlower");
        enemyNames.Add("dustinBomber");
        enemyNames.Add("thrussyBoober");
        itemDrops.Add(fullHeart);
        itemDrops.Add(halfHeart);
        itemDrops.Add(coinBag);
        itemDrops.Add(coin);
        itemDrops.Add(tpCrystal);
        itemDrops.Add(superCoin);
        itemDrops.Add(bomb);
    }
}
