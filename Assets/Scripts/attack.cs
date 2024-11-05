using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class attack : MonoBehaviour
{
    public GameObject sword;
    public GameObject player1;
    public playerDamage pd;
    public GameObject arrow;
    public Boolean bombPresent = false;
    public GameObject tpCrystalToSet;
    public GameObject potionInShop;
    public GameObject bomb;
    public pauseMenu pm;
    public float bombTimer = 0;
    public float arrowTimer = 0;
    public Text txt;
    public GameObject pauseHealthPotion;
    public float arrowSpeed;
    public Boolean arrowPresent = false;
    public float timer = 0;
    public Boolean swordPresent = false;
    public playerController p;
    public Vector3 swordDisappear = new Vector3(10000, 10000, 10000);

    void Start() {
        if(PlayerPrefs.GetInt("teleportCrystalSet") != 0) {
            Instantiate(tpCrystalToSet, new Vector3(PlayerPrefs.GetFloat("teleportXCoord"), PlayerPrefs.GetFloat("teleportYCoord"), 0), quaternion.identity);
        }
    }
    void keyPressed(Vector3 direction, int angel) {
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            if(PlayerPrefs.GetInt("itemSelected") == 1 && PlayerPrefs.GetInt("playerMoney") >= 1 && arrowPresent == false) {
                arrow.GetComponent<playerArrow>().moveVector = new Vector3(arrowSpeed * direction.x, arrowSpeed * direction.y, 0);
                arrow.GetComponent<playerArrow>().angle = angel;
                Instantiate(arrow, player1.transform.position + new Vector3(2 * direction.x, 2 * direction.y, 0), quaternion.identity);
                    
                Physics2D.IgnoreCollision(arrow.GetComponent<BoxCollider2D>(), player1.GetComponent<BoxCollider2D>());
                Physics2D.IgnoreCollision(arrow.GetComponent<BoxCollider2D>(), player1.GetComponent<CapsuleCollider2D>());
                PlayerPrefs.SetInt("playerMoney", PlayerPrefs.GetInt("playerMoney") - 1);
                txt.text = "" + PlayerPrefs.GetInt("playerMoney");
                arrowPresent = true;
            }
            else if(PlayerPrefs.GetInt("itemSelected") == 2 && PlayerPrefs.GetInt("playerMoney") >= 5 && bombPresent == false) {
                Instantiate(bomb, player1.transform.position + new Vector3(2 * direction.x, 2 * direction.y, 0), quaternion.identity);
                PlayerPrefs.SetInt("playerMoney", PlayerPrefs.GetInt("playerMoney") - 5);
                txt.text = "" + PlayerPrefs.GetInt("playerMoney");
                bombPresent = true;
            }
            else if(PlayerPrefs.GetInt("itemSelected") == 3) {
                if(PlayerPrefs.GetInt("teleportCrystalSet") == 0) {
                    Instantiate(tpCrystalToSet, player1.transform.position + new Vector3(2 * direction.x, 2 * direction.y, 0), quaternion.identity);
                    PlayerPrefs.SetInt("teleportCrystalSet", 1);
                    PlayerPrefs.SetFloat("teleportXCoord", player1.transform.position.x + (2 * direction.x));
                    PlayerPrefs.SetFloat("teleportYCoord", player1.transform.position.y + (2 * direction.y));
                    PlayerPrefs.SetInt("teleportScene", SceneManager.GetActiveScene().buildIndex);
                }
                else if(PlayerPrefs.GetInt("playerMoney") >= 15) {
                    PlayerPrefs.SetInt("playerMoney", PlayerPrefs.GetInt("playerMoney") - 15);
                    txt.text = "" + PlayerPrefs.GetInt("playerMoney");
                    PlayerPrefs.SetInt("usedTeleport", 1);
                    if(SceneManager.GetActiveScene().buildIndex != PlayerPrefs.GetInt("teleportScene")) {
                        SceneManager.LoadScene(PlayerPrefs.GetInt("teleportScene"));
                    }
                    else {
                        PlayerPrefs.SetInt("usedTeleport", 0);
                        player1.transform.position = new Vector3(PlayerPrefs.GetFloat("teleportXCoord"), PlayerPrefs.GetFloat("teleportYCoord"), 0);
                        
                    }
                }
            }
            else if(PlayerPrefs.GetInt("itemSelected") == 4) {
                pd.poisonTicks = 10;
                pd.poisonTimer = 0;
                pd.reduceHp(PlayerPrefs.GetInt("playerHp") - PlayerPrefs.GetInt("playerMaxHp"));
                pm.pauseObjects.Remove(pauseHealthPotion);
                pauseHealthPotion.SetActive(false);
                PlayerPrefs.SetInt("hasHealthPotion", 0);
                if(pm.selectorPositions[3] == pm.selectorPositions[4]) {
                    pm.selectorPositions[3] = pm.selectorPositions[0];
                }
                pm.selectorPositions[4] = pm.selectorPositions[0];
                pm.itemSelected.transform.localPosition = new Vector3(-25, -61, 0);
                
                PlayerPrefs.SetInt("itemSelected", 0);
            }
        }
        else {
            sword.transform.position = player1.transform.position + new Vector3((float)1.4 * direction.x, (float)1.4 * direction.y, 0);
            sword.transform.eulerAngles = new Vector3(0, 0, angel);
            sword.GetComponent<Animator>().Play("swordSwing", 0, 0.0f);

        }
        swordPresent = true;
    }
    void Update()
    {
        if(swordPresent == false) {
            if(Input.GetKeyDown(KeyCode.UpArrow) && swordPresent == false) {
                keyPressed(new Vector3(0, 1, 0), 0);
            }
            if(Input.GetKeyDown(KeyCode.DownArrow) && swordPresent == false) {
                keyPressed(new Vector3(0, -1, 0), 180);
            }
            if(Input.GetKeyDown(KeyCode.RightArrow) && swordPresent == false) {
                keyPressed(new Vector3(1, 0, 0), -90);
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow) && swordPresent == false) {
                keyPressed(new Vector3(-1, 0, 0), 90);
            }
        }
        if(swordPresent == true) {
            if(timer < 0.283) {
                p.speed = 0;
                timer += Time.deltaTime;
            }
            else {
                p.speed = p.defaultSpeed;
                sword.transform.position = swordDisappear;
                swordPresent = false;
                timer = 0;
            }
        }
        if(arrowPresent == true) {
            arrowTimer += Time.deltaTime;
            if(arrowTimer >= 0.7) {
                arrowTimer = 0;
                arrowPresent = false;
            }
        }
        if(bombPresent == true) {
            bombTimer += Time.deltaTime;
            if(bombTimer >= 1) {
                bombTimer = 0;
                bombPresent = false;
            }
        }
    }
}
