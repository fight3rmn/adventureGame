using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stomachPlayer : MonoBehaviour
{
    public GameObject player1;
    public float stomachSpeed;
    public GameObject playerSword;
    public Boolean acidImmune;

    void Start() {
        acidImmune = false;
    }

    void Update()
    {
        if(player1.transform.position.x < 854) {
            player1.transform.position = new Vector3(player1.transform.position.x + (stomachSpeed*Time.deltaTime), player1.transform.position.y, 0);
        }
        if(playerSword.transform.position.x < 855) {
            playerSword.transform.position = new Vector3(playerSword.transform.position.x + (stomachSpeed*Time.deltaTime), playerSword.transform.position.y, 0);
        }
    }
}
