using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using System.Numerics;
using System.Linq;
using Unity.VisualScripting;

public class playerDamage : MonoBehaviour
{
    public GameObject thisObject;
    public Rigidbody2D thisRigidbody;
    public playerController p;
    public Sprite halfHeart;
    public Sprite fullHeart;
    public float speed;
    public float poisonTimer = 0;
    public BoxCollider2D thisCollider;
    public CapsuleCollider2D thisCollider2;
    string[] safeObjects = {"heart", "wall", "coin", "playerArrow", "heartUpgrade", "acid"};
    public PolygonCollider2D swordCollider;
    public float iFrames;
    float invincibilityTimer;
    Boolean invincible = false;
    public List<heartUpdate> hearts;
    Boolean playerStopped;
    public int poisonTicks = 10;
    float timer = 0;
    public void Start() {
        Physics2D.IgnoreCollision(thisCollider, swordCollider);
        Physics2D.IgnoreCollision(thisCollider2, swordCollider);
    }
    public void reduceHp(int hpReduction) {
            PlayerPrefs.SetInt("playerHp", PlayerPrefs.GetInt("playerHp") - hpReduction);
            foreach(heartUpdate i in hearts) {
                i.onHit(halfHeart, fullHeart);
            }
    }

    public void hitAcid() {
        poisonTicks = 1;
        poisonTimer = 0;
        halfHeart = hearts[0].poisonedHalfHeart;
        fullHeart = hearts[0].poisonedHeart;
        reduceHp(2);
    }
    
    void OnCollisionEnter2D(Collision2D hit) {
        if(invincible == false) {
            if(hit.gameObject.tag == "enemyBody") {
                invincible = true;
                reduceHp(2);
            }
            else if(hit.gameObject.tag == "enemyArrow") {
                invincible = true;
                reduceHp(2);
            }
            else if(hit.gameObject.tag == "explosion") {
                invincible = true;
                reduceHp(4);
            }
            else if(hit.gameObject.tag == "spiderBody") {
                invincible = true;
                poisonTicks = 0;
                poisonTimer = 0;
                halfHeart = hearts[0].poisonedHalfHeart;
                fullHeart = hearts[0].poisonedHeart;
                reduceHp(1);
            }
            else if(hit.gameObject.tag == "energyBeam") {
                invincible = true;
                reduceHp(2);
            }
        }
        if(hit.gameObject.tag == "heart") {
            if(PlayerPrefs.GetInt("playerHp") <= PlayerPrefs.GetInt("playerMaxHp") - hit.gameObject.GetComponent<heartObjectDelete>().healAmount) {
                reduceHp(-hit.gameObject.GetComponent<heartObjectDelete>().healAmount);
            }
            else {
                reduceHp(PlayerPrefs.GetInt("playerHp") - PlayerPrefs.GetInt("playerMaxHp"));
            }
        }
        if(hit.gameObject.tag == "heartUpgrade") {
                PlayerPrefs.SetInt("playerMaxHp", PlayerPrefs.GetInt("playerMaxHp") + 2);
                reduceHp(-2);
            
        }
        ContactPoint2D[] allContacts = new ContactPoint2D[hit.contactCount];
        hit.GetContacts(allContacts);
        /*if(allContacts[0].point.y == allContacts[1].point.y && allContacts[0].point.y > thisObject.transform.position.y) {
            thisRigidbody.velocity += (new Vector2(0, -9));
            p.speed = 0;
        }
        else if(allContacts[0].point.y == allContacts[1].point.y && allContacts[0].point.y < thisObject.transform.position.y) {
            thisRigidbody.velocity += (new Vector2(0, 9));
            p.speed = 0;
        }
        else if(allContacts[0].point.x == allContacts[1].point.x && allContacts[0].point.x > thisObject.transform.position.x) {
            thisRigidbody.velocity += (new Vector2(-9, 0));
            p.speed = 0;
        }
        else {
            thisRigidbody.velocity += (new Vector2(9, 0));
            p.speed = 0;
        }*/
        if(!safeObjects.Contains<string>(hit.gameObject.tag)) {
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
            thisRigidbody.velocity += new UnityEngine.Vector2(xSpeed * speed, ySpeed * speed);
            p.speed = 0;
            playerStopped = true;
        }
        if(PlayerPrefs.GetInt("playerHp") <= 0) {
            SceneManager.LoadScene(1);
        }
    }

    void Update() {
        if(invincible == true) {
            invincibilityTimer += Time.deltaTime;
            if(invincibilityTimer >= iFrames) {
                invincibilityTimer = 0;
                invincible = false;
            }
        }
        if(playerStopped == true) {
            timer += Time.deltaTime;
            if(timer >= 0.2) {
                timer = 0;
                p.speed = p.defaultSpeed;
                playerStopped = false;
            }
        }
        if(poisonTicks < 3) {
            poisonTimer += Time.deltaTime;
            if(poisonTimer >= 1) {
                PlayerPrefs.SetInt("playerHp", PlayerPrefs.GetInt("playerHp") - 1);
                if(PlayerPrefs.GetInt("playerHp") <= 0) {
                    SceneManager.LoadScene(1);
                }
                poisonTicks++;
                if(poisonTicks == 3) {
                    halfHeart = hearts[0].halfHeart;
                    fullHeart = hearts[0].heart;
                }
                foreach(heartUpdate i in hearts) {
                    i.onHit(halfHeart, fullHeart);
                }
                poisonTimer = 0;
            }
        }
    }
}
