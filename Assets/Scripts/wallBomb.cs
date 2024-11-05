using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.Mathematics;
using UnityEngine;

public class wallBomb : MonoBehaviour
{
    public GameObject thisObject;
    public float xBreakRange;
    public float yBreakRange;
    public GameObject openWall;
    public int doorRotation;
    public GameObject door;
    void OnCollisionEnter2D(Collision2D hit) {
        if(hit.gameObject.tag == "explosion") {
            ContactPoint2D[] wallContacts = new ContactPoint2D[hit.contactCount];
            hit.GetContacts(wallContacts);
            foreach(ContactPoint2D i in wallContacts) {
                if(math.abs(i.point.x - thisObject.transform.position.x) <= xBreakRange && math.abs(i.point.y - thisObject.transform.position.y) <= yBreakRange) {
                    openWall.GetComponent<brokenWallAngle>().wallRotation = thisObject.transform.eulerAngles.z;
                    Instantiate(openWall, thisObject.transform.position, quaternion.identity);
                    door.GetComponent<door>().doorRotation = doorRotation;
                    //studpidest fuckin command lmao
                    Instantiate(door, thisObject.transform.position, quaternion.identity);
                    Destroy(thisObject);
                }
            }
        }
    }
}
