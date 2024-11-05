using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow : MonoBehaviour
{
    public Transform player1;
    public SpriteRenderer thisSprite;

    // Update is called once per frame
    void Update()
    {
        /*
        if(Vector3.Distance(player1.position, this.transform.position) < 14) {
            thisSprite.color = new Color(0, 0, 0, 0.11f);
        }
        else {
            thisSprite.color = new Color(0, 0, 0, 0.993f);

        }
        */
        thisSprite.color = new Color(0, 0, 0, Vector3.Distance(player1.position, this.transform.position)/17);
    }
}
