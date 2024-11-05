using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seaWormScript : MonoBehaviour
{
    public GameObject thisObject;
    public oceanScript seaScript;
    public float timer;
    void Start()
    {
        if(UnityEngine.Random.Range(0, 2) == 0) {
            thisObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else {
            thisObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if(UnityEngine.Random.Range(0, 2) == 0) {
            thisObject.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else {
            thisObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1) {
            seaScript.readyForBubbles = true;
            Destroy(thisObject);
        }
    }
}
