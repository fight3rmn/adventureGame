using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class bomberBombThrow : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    public GameObject arrow1;
    public float thisAngle;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject grenade1;
    public Transform thisTransform;
    public GameObject player2;
    public BoxCollider2D thisCollider;
    public float aggroDist;
    public float timeBetweenHits;

    void throwBomb(GameObject arrow, float angle) {
        UnityEngine.Vector2 dist = new UnityEngine.Vector2(thisTransform.position.x - player2.transform.position.x, thisTransform.position.y - player2.transform.position.y);
            float xDist = math.sqrt((dist.x * dist.x)/(UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position)));
            float yDist = math.sqrt((dist.y * dist.y)/(UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position)));
        if(math.abs(xDist) > math.abs(yDist)) {
            float xAngle = math.asin(xDist);
            xDist = math.sin(xAngle + angle);
            yDist = math.cos(xAngle + angle);
        }
        else {
            float yAngle = math.asin(yDist);
            yDist = math.sin(yAngle + angle);
            xDist = math.cos(yAngle + angle);
        }
            if(player2.transform.position.x < thisTransform.position.x) {
                xDist = -xDist;
            }
            if(player2.transform.position.y < thisTransform.position.y) {
                yDist = -yDist;
            }
            timer = 0;

            arrow.GetComponent<rangedBomb>().player1 = player2;
            Instantiate(arrow, new Vector3(thisTransform.position.x + (xDist * (float)2.3), thisTransform.position.y + (yDist * (float)2.3), thisTransform.position.z), quaternion.identity);
            Physics2D.IgnoreCollision(arrow.GetComponent<BoxCollider2D>(), thisCollider);
    }

    void throwGrendade(GameObject grenade, float angle) {
        UnityEngine.Vector2 dist = new UnityEngine.Vector2(thisTransform.position.x - player2.transform.position.x, thisTransform.position.y - player2.transform.position.y);
            float xDist = math.sqrt((dist.x * dist.x)/(UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position)));
            float yDist = math.sqrt((dist.y * dist.y)/(UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position)));
        if(math.abs(xDist) > math.abs(yDist)) {
            float xAngle = math.asin(xDist);
            xDist = math.sin(xAngle + angle);
            yDist = math.cos(xAngle + angle);
        }
        else {
            float yAngle = math.asin(yDist);
            yDist = math.sin(yAngle + angle);
            xDist = math.cos(yAngle + angle);
        }
            if(player2.transform.position.x < thisTransform.position.x) {
                xDist = -xDist;
            }
            if(player2.transform.position.y < thisTransform.position.y) {
                yDist = -yDist;
            }
            timer = 0;

            grenade.GetComponent<grenadeScript>().player1 = player2;
            grenade.GetComponent<grenadeScript>().angle = angle;
            Instantiate(grenade, new Vector3(thisTransform.position.x + (xDist * (float)2.3), thisTransform.position.y + (yDist * (float)2.3), thisTransform.position.z), quaternion.identity);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenHits && UnityEngine.Vector2.Distance(player2.transform.position, thisTransform.position) <= aggroDist) {
            int whichBomb = UnityEngine.Random.Range(0, 2);
            if(whichBomb == 0) {
                throwBomb(arrow1, thisAngle);
                throwBomb(arrow2, 0);
                throwBomb(arrow3, -thisAngle);
            }
            else {
                throwGrendade(grenade1, thisAngle);
                throwGrendade(grenade1, 0);
                throwGrendade(grenade1, -thisAngle);
            }
        }
    }
}
