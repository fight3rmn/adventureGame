using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class axeSwing : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    public GameObject arrow;
    public Transform thisTransform;
    public GameObject playerSword;
    public GameObject player2;
    public BoxCollider2D thisCollider;
    public float aggroDist;
    public float timeBetweenHits;

    void Start() {
        UnityEngine.Vector2 dist = new UnityEngine.Vector2(thisTransform.position.x - player2.transform.position.x, thisTransform.position.y - player2.transform.position.y);
        float xDist = math.sqrt((dist.x * dist.x)/(UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position)));
        float yDist = math.sqrt((dist.y * dist.y)/(UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position)));
        if(player2.transform.position.x < thisTransform.position.x) {
            xDist = -xDist;
        }
        if(player2.transform.position.y < thisTransform.position.y) {
            yDist = -yDist;
        }
        timer = 0;

        Instantiate(arrow, new Vector3(thisTransform.position.x + (xDist * 2), thisTransform.position.y + (yDist * 2), thisTransform.position.z), quaternion.identity);
        arrow.GetComponent<axeScript>().player1 = player2;
        Physics2D.IgnoreCollision(arrow.GetComponent<BoxCollider2D>(), thisCollider);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenHits && (UnityEngine.Vector2.Distance(playerSword.transform.position, thisTransform.position)  <= aggroDist || UnityEngine.Vector2.Distance(player2.transform.position, thisTransform.position)  <= aggroDist)) {
            UnityEngine.Vector2 dist = new UnityEngine.Vector2(thisTransform.position.x - player2.transform.position.x, thisTransform.position.y - player2.transform.position.y);
            float xDist = math.sqrt((dist.x * dist.x)/(UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position)));
            float yDist = math.sqrt((dist.y * dist.y)/(UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position)));
            if(player2.transform.position.x < thisTransform.position.x) {
                xDist = -xDist;
            }
            if(player2.transform.position.y < thisTransform.position.y) {
                yDist = -yDist;
            }
            timer = 0;

            Instantiate(arrow, new Vector3(thisTransform.position.x + (xDist * 2), thisTransform.position.y + (yDist * 2), thisTransform.position.z), quaternion.identity);
            arrow.GetComponent<axeScript>().player1 = player2;
            Physics2D.IgnoreCollision(arrow.GetComponent<BoxCollider2D>(), thisCollider);
        }
    }
}
