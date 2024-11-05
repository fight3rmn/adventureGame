using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject thisPlayer;
    public float timer;
    public float speed;
    public Boolean dashCooldown = false;
    public Boolean speedReset = true;
    public float defaultSpeed;

    void Start() {
        if(PlayerPrefs.GetInt("usedTeleport") != 0) {
            thisPlayer.transform.position = new Vector3(PlayerPrefs.GetFloat("teleportXCoord"), PlayerPrefs.GetFloat("teleportYCoord"), 0);
            PlayerPrefs.SetInt("usedTeleport", 0);
        }
    }
    void Update()
    {
        if(PlayerPrefs.GetInt("hasHeelies") == 1) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                if(dashCooldown == false) {
                    speed *= (float)15.5;
                    dashCooldown = true;
                    speedReset = false;
                }
            }
            if(dashCooldown == true) {
                timer += Time.deltaTime;
                if(timer >= 0.02 && speedReset == false) {
                    speed = defaultSpeed;
                    speedReset = true;
                }
                if(timer >= 0.51) {
                    dashCooldown = false;
                    timer = 0;
                }
            }
        }
        if(Input.GetKey("w")) {
            if((Input.GetKey("a") && !Input.GetKey("d")) || (Input.GetKey("d") && !Input.GetKey("a"))) {
                thisPlayer.transform.position += new Vector3(0, (float)0.7 * speed * Time.deltaTime, 0);
            }
            else {
                thisPlayer.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
        /*if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp("w")) {
            thisPlayer.transform.position -= new Vector2(0, speed, 0);
        }*/


        if(Input.GetKey("s")) {
            if((Input.GetKey("a") && !Input.GetKey("d")) || (Input.GetKey("d") && !Input.GetKey("a"))) {
                thisPlayer.transform.position += new Vector3(0, (float)0.7 * -speed * Time.deltaTime, 0);
            }
            else {
                thisPlayer.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            }
        }
        /*if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s")) {
            thisPlayer.transform.position -= new Vector2(0, -speed);
        }*/


        if(Input.GetKey("d")) {
            if((Input.GetKey("w") && !Input.GetKey("s")) || (Input.GetKey("s") && !Input.GetKey("w"))) {
                thisPlayer.transform.position += new Vector3((float)0.7 * speed * Time.deltaTime, 0, 0);
            }
            else {
                thisPlayer.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }
        /*if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp("d")) {
            thisPlayer.transform.position -= new Vector2(speed, 0);
        }*/


        if(Input.GetKey("a")) {
            if((Input.GetKey("s") && !Input.GetKey("w")) || (Input.GetKey("w") && !Input.GetKey("s"))) {
                thisPlayer.transform.position += new Vector3((float)0.7 * -speed * Time.deltaTime, 0, 0);
            }
            else {
                thisPlayer.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }
        }
        /*if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp("a")) {
            thisPlayer.velocity -= new Vector2(-speed, 0);
        }*/
    }
} 
