using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogScript : MonoBehaviour
{
    public int effect;
    float timer;
    public GameObject thisObject;
    public float fogTime;
    int numFogGrowths = 0;
    public GameObject player1;
    void Update() {
        timer += Time.deltaTime;
        if(timer >= 0.07 && numFogGrowths < 12) {
            thisObject.transform.localScale += new Vector3((float)0.5, (float)0.5, 0);
            timer = 0;
            numFogGrowths++;
        }
        if(Vector3.Distance(player1.transform.position, this.transform.position) <= (18.5 * numFogGrowths/12)) {
            if(effect == 2) {
                player1.GetComponent<playerDamage>().poisonTicks = 0;
                player1.GetComponent<playerDamage>().halfHeart = player1.GetComponent<playerDamage>().hearts[0].poisonedHalfHeart;
                player1.GetComponent<playerDamage>().fullHeart = player1.GetComponent<playerDamage>().hearts[0].poisonedHeart;
            }
            if(effect == 3) {
                player1.GetComponent<attack>().swordPresent = true;
                player1.GetComponent<attack>().bombPresent = true;
                player1.GetComponent<attack>().arrowPresent = true;
            }
        }
        if(timer >= fogTime) {
            if(effect == 3) {
                player1.GetComponent<attack>().swordPresent = false;
                player1.GetComponent<attack>().bombPresent = false;
                player1.GetComponent<attack>().arrowPresent = false;
                player1.GetComponent<attack>().timer = 0;
                player1.GetComponent<attack>().bombTimer = 0;
                player1.GetComponent<attack>().arrowTimer = 0;
                player1.GetComponent<playerController>().speed = player1.GetComponent<playerController>().defaultSpeed;
                player1.GetComponent<attack>().sword.transform.position = player1.GetComponent<attack>().swordDisappear;
            }
            numFogGrowths = 0;
            Destroy(thisObject);
        }
    }
}
