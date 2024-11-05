using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class crystalSpawnCrystal : MonoBehaviour
{
    public GameObject arrow;
    public GameObject thisObject;
    public GameObject thisTodo;
    public GameObject player2;
    public CapsuleCollider2D thisCollider;
    void Start()
    {
        thisTodo.GetComponent<todoTeleport>().teleportPositions.Add(this.transform.position);
        if(thisTodo.GetComponent<todoTeleport>().teleportPositions.Count < 3) {
            UnityEngine.Vector2 dist = new UnityEngine.Vector2(thisObject.transform.position.x - player2.transform.position.x, thisObject.transform.position.y - player2.transform.position.y);
            float xDist = math.sqrt((dist.x * dist.x)/(UnityEngine.Vector2.Distance(thisObject.transform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisObject.transform.position, player2.transform.position)));
            float yDist = math.sqrt((dist.y * dist.y)/(UnityEngine.Vector2.Distance(thisObject.transform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisObject.transform.position, player2.transform.position)));
            if(player2.transform.position.x < thisObject.transform.position.x) {
                xDist = -xDist;
            }
            if(player2.transform.position.y < thisObject.transform.position.y) {
                yDist = -yDist;
            }
            /*arrow.GetComponent<todoCrystalScript>().setCrystal = stationaryCrystal;
            arrow.GetComponent<todoCrystalScript>().todo = thisTodo;*/
            Instantiate(arrow, new Vector3(thisObject.transform.position.x + (xDist * 3), thisObject.transform.position.y + (yDist * 3), thisObject.transform.position.z), quaternion.identity);
            //arrow.GetComponent<todoCrystalScript>().player1 = player2;
            //Physics2D.IgnoreCollision(arrow.GetComponent<BoxCollider2D>(), thisCollider);
        }

    }

    void OnCollisionEnter2D(Collision2D hit) {
        if(hit.gameObject.tag == "playerSword" || hit.gameObject.tag == "enemyBody") {
            thisTodo.GetComponent<todoTeleport>().teleportPositions.Remove(this.transform.position);
            Destroy(thisObject);
        }
    }
}
