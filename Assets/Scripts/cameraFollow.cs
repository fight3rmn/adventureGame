using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player1;
    Vector3 relativePosition;
    public GameObject thisObject;
    void Start()
    {
        thisObject.transform.position = new Vector3(player1.transform.position.x, player1.transform.position.y, thisObject.transform.position.z);
        relativePosition = transform.position - player1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = relativePosition + player1.transform.position;
    }
}
