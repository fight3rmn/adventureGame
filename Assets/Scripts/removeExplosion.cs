using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeExplosion : MonoBehaviour
{
    float timer;
    public GameObject thisObject;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1) {
            Destroy(thisObject);
        }
    }
}
