using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class npc : MonoBehaviour
{
    public GameObject player1;
    public TextMeshPro toTalk;
    public Text topText;
    public Text bottomText;
    public Text smithText;
    Boolean talking;
    public GameObject selector;
    public int steelResponse;
    public float timer;
    public int textScroll;
    public int dialogueState;

    string[] playerResponses = {"Are you a blacksmith?", "Bye", "So can you like... do some work on my sword then?", "Damn nigga chill I aint' trynna get all up in yo business", "I found some of that skysteel "};
    string[] smithResponses = {};
    string [] steelResponses = {"stuff that you were talking about", "that you said you could use to upgrade my shit", "for you. Will this work?"};
    //Vector2 pResponseSet1 = (0, 2);

    // Update is called once per frame
    void Start() {
        talking = false;
        dialogueState = 0;
    }
    void Update()
    {
        if(Vector3.Distance(player1.transform.position, this.transform.position) <= 2.4) {
            timer += Time.deltaTime;
            if(talking == false) {
                toTalk.text = "e to talk";
            }
            if(Input.GetKeyDown("e") && dialogueState == 0) {
                steelResponse = UnityEngine.Random.Range(0, 3);
                timer = 0;
                player1.GetComponent<playerController>().speed = 0;
                smithText.text = "What the fuck do you want?";
                dialogueState = 1;
            }
            if(dialogueState == 1 && timer >= 0.4) {
                if(PlayerPrefs.GetInt("talkedToBlacksmith") == 0) {
                    topText.text = "Are you a blacksmith?";
                    bottomText.text = "Bye";
                }
                else if(PlayerPrefs.GetInt("talkedToBlacksmith") == 1) {
                    topText.text = "So can you like... do some work on my sword then?";
                    bottomText.text = "Damn nigga chill I aint' trynna get all up in yo business";
                }
                else if(PlayerPrefs.GetInt("talkedToBlacksmith") == 2) {
                    topText.text = "I found some of that skysteel " + steelResponses[steelResponse];
                    bottomText.text = "Bye";
                }
            }

        }
        else if(Vector3.Distance(player1.transform.position, this.transform.position) <= 5) {
            toTalk.text = "";
        }
    }
}
