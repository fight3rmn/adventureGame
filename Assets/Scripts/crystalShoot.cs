using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class crystalShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    public GameObject arrow;
    public Transform thisTransform;
    public GameObject thisTodo;
    public GameObject stationaryCrystal;
    public GameObject player2;
    public BoxCollider2D thisCollider;
    public float aggroDist;
    public float timeBetweenHits;

   void Start() {
        stationaryCrystal.GetComponent<crystalSpawnCrystal>().thisTodo = thisTodo;
        stationaryCrystal.GetComponent<crystalSpawnCrystal>().arrow = arrow;
        stationaryCrystal.GetComponent<crystalSpawnCrystal>().player2 = player2;
        /*UnityEngine.Vector2 dist = new UnityEngine.Vector2(thisTransform.position.x - player2.transform.position.x, thisTransform.position.y - player2.transform.position.y);
        float xDist = math.sqrt((dist.x * dist.x)/(UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position)));
        float yDist = math.sqrt((dist.y * dist.y)/(UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position) * UnityEngine.Vector2.Distance(thisTransform.position, player2.transform.position)));
        if(player2.transform.position.x < thisTransform.position.x) {
            xDist = -xDist;
        }
        if(player2.transform.position.y < thisTransform.position.y) {
            yDist = -yDist;
        }
        timer = 0;
        arrow.GetComponent<todoCrystalScript>().setCrystal = stationaryCrystal;
        arrow.GetComponent<todoCrystalScript>().todo = thisTodo;
        Instantiate(arrow, new Vector3(thisTransform.position.x + (xDist * 3), thisTransform.position.y + (yDist * 3), thisTransform.position.z), quaternion.identity);
        arrow.GetComponent<rangedAttack>().player1 = player2;
        Physics2D.IgnoreCollision(arrow.GetComponent<BoxCollider2D>(), thisCollider);*/
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenHits && UnityEngine.Vector2.Distance(player2.transform.position, thisTransform.position) <= aggroDist) {
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
            arrow.GetComponent<todoCrystalScript>().setCrystal = stationaryCrystal;
            arrow.GetComponent<todoCrystalScript>().todo = thisTodo;
            arrow.GetComponent<todoCrystalScript>().player1 = player2;
            Instantiate(arrow, new Vector3(thisTransform.position.x + (xDist * 3), thisTransform.position.y + (yDist * 3), thisTransform.position.z), quaternion.identity);
        }
    }
}
