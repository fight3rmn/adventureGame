using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class bombExplosion : MonoBehaviour
{
    float timer;
    public GameObject explosion;
    public GameObject thisObject;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1.7) {
            Instantiate(explosion, this.transform.position, quaternion.identity);
            Destroy(thisObject);
        }
    }
}
