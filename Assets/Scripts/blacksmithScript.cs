using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class blacksmithScript : MonoBehaviour
{

    public GameObject player1;
    public GameObject eToTalk;
    Boolean moveTextAway = false;
    float timer;
    public Image selector;
    public List<string> curResponses;
    Vector3 sPosition1 = new Vector3(-546, -163, 0);
    Vector3 sPosition2 = new Vector3(-546, -286, 0);
    int selected;
    public Text smithText;
    Boolean blacksmithTalking = false;
    int smithTextIndex = -1;
    int smithIndexIndex;
    int upgradeCost;
    int numIngotsRequired;
    
    string[] smithResponses = {"Alright. What are you looking to have done?"/*0*/, "The fuck\'s it look like? You just come here to waste my fuckin time?"/*1*/,
    "Sure, if you just let me take a look at it for a sec I can probly install the add on that makes it 30 feet long,"/*2*/, "or how about one that makes it shoot fire."/*3*/,
    "Oh, or how about I add one that makes it cut other people\'s swords? Wouldn't that be original."/*4*/, "\"Could you upgrade it or something\" it\'s a fuckin sword. The fuck do you expect me to do with it?"/*5*/,
    "You want a better sword buy a better fuckin sword. It\'s not like I have skysteel lying around to forge into it."/*6*/, "\"Upgrade a fuckin sword\" *chuckles*"/*7*/, "What metal?"/*8*/, "..."/*9*/,
    "Oh, skysteel? Bullshit. No way you actually found skysteel. Show it to me"/*10*/, "(quietly) Another fuckin one of these."/*11*/, "What kind of \"magic ingot\" is it this time?"/*12*/,
    "Thanks for wasting my fuckin time"/*13*/, "Fuck you. Get the fuck out of my shop"/*14*/, "You\'ve never heard of skysteel? It's metal imbued with magic"/*15*/,
    "It doesn't occur in nature but also can\'t be manufactured by humans. Some people think it was created by ancient dragons."/*16*/, "Point is, no one knows where to find it and I sure as shit don\'t have any."/*17*/,
    "You somehow manage to find me some o\' that and I'll do whatever the fuck you want to your sword"/*18*/, "No homo."/*19*/, "hmmm."/*20*/, "uh-huh."/*21*/, "No shit."/*22*/,
    "This is actual fuckin skysteel. Where the fuck did you find this?"/*23*/, "Well excuse the fuck outta me. Do you want me to wipe your ass for you too?"/*24*/,
    "Skysteel ain\'t the kinda shit you just find laying around, so either tell me where the fuck you found this"/*25*/, "or I\'m just gonna assume you fucking stole it."/*26*/,
    "Where in the fu- you know what? I\'m not gonna question it."/*27*/, "Looks like you brought a decent amount of it too. I can upgrade your sword with this."/*28*/,
    "\'Course, I gotta bills I gotta pay though. I ain\'t in the business of workin for free."/*29*/, "Great. I\'ll haver \'er done in a few hours. You can just hang around \'till then."/*30*/,
    "Looks like this ain\'t enough to do much with though."/*31*/, "The amount o\' skysteel you got in that sword this\'d just be a drop in the bucket."/*32*/,
    "I don\'t know where the hell you keep finding these things, but if you want that sword to get any better"/*33*/, "You\'d best take your ass back there and grab some more of \'em"/*34*/, "No."/*35*/};
    public List<Vector3> playerIndex;
    //in playerindex, vector3.x is the state the response will be loaded at, y is the index in playerresponses, and z is the next state that that response leads to
    public List<Vector3> smithIndex;
    //in smithindex, vector3.x is the state this response will be loaded at, y is the index in smithResponses, and z is the response number, counting down towards 0, in that list of dialogues
    Boolean doneAdding = false;
    public Text playerText1;
    public Text playerText2;
    int dialogueState;
    string[] playerRespond() {
        string[] playerResponses = {"Are you a blacksmith?", "I need some work done on my sword", "Goodbye", "Uh. Could like... upgrade it or something?", 
    "I found this magic ingot and i was hoping you could forge it into my sword or something", "I found that metal you told me to get", "I found some more of that skysteel", "*show ingot*",
    "In some hidden cave", "It was just lying on the ground outside", "I killed a dragon for it", "Listen, I\'ll worry about where I find things, why don\'t you just tell me what you can do with it",
    "Fair enough [give " + upgradeCost + " gold, " + numIngotsRequired + " skysteel ingots]", "Wait, skysteel? What\'s that?", "Do you mean something like this *show ingot*?",
    "Ok. Do you have a better sword I can buy"};
        return playerResponses;
    }

    void Start() {
        if(PlayerPrefs.GetInt("talkedToBlacksmith") == 0) {
            playerIndex.Add(new Vector3(1, 0, 2));
        }
        playerIndex.Add(new Vector3(1, 1, 3));
        playerIndex.Add(new Vector3(1, 2, 14));
        playerIndex.Add(new Vector3(2, 2, 13));
        playerIndex.Add(new Vector3(3, 2, 14));
        playerIndex.Add(new Vector3(4, 2, 14));
        playerIndex.Add(new Vector3(5, 2, 14));
        playerIndex.Add(new Vector3(6, 2, 14));
        playerIndex.Add(new Vector3(7, 2, 14));
        playerIndex.Add(new Vector3(8, 2, 14));
        playerIndex.Add(new Vector3(9, 2, 14));
        playerIndex.Add(new Vector3(10, 2, 14));
        playerIndex.Add(new Vector3(2, 1, 3));
        if(PlayerPrefs.GetInt("bSmithState3Done") == 0) {
            playerIndex.Add(new Vector3(3, 3, 4));
        }
        playerIndex.Add(new Vector3(3, 5, 6));
        playerIndex.Add(new Vector3(3, 4, 7));
        playerIndex.Add(new Vector3(4, 13, 5));
        playerIndex.Add(new Vector3(4, 15, 15));
        playerIndex.Add(new Vector3(15, 2, 14));
        playerIndex.Add(new Vector3(5, 15, 15));
        playerIndex.Add(new Vector3(6, 7, 10));
        playerIndex.Add(new Vector3(7, 7, 10));
        playerIndex.Add(new Vector3(3, 6, 8));
        playerIndex.Add(new Vector3(3, 6, 9));
        playerIndex.Add(new Vector3(9, 12, 12));
        playerIndex.Add(new Vector3(10, 8, 9));
        playerIndex.Add(new Vector3(10, 9, 9));
        playerIndex.Add(new Vector3(10, 10, 9));
        playerIndex.Add(new Vector3(10, 11, 11));
        playerIndex.Add(new Vector3(11, 10, 9));
        playerIndex.Add(new Vector3(11, 9, 9));
        playerIndex.Add(new Vector3(11, 8, 9));




        smithIndex.Add(new Vector3(2, 1, 0));
        smithIndex.Add(new Vector3(3, 0, 0));
        smithIndex.Add(new Vector3(4, 2, 5));
        smithIndex.Add(new Vector3(4, 3, 4));
        smithIndex.Add(new Vector3(4, 4, 3));
        smithIndex.Add(new Vector3(4, 5, 2));
        smithIndex.Add(new Vector3(4, 6, 1));
        smithIndex.Add(new Vector3(4, 7, 0));
        smithIndex.Add(new Vector3(5, 15, 4));
        smithIndex.Add(new Vector3(5, 16, 3));
        smithIndex.Add(new Vector3(5, 17, 2));
        smithIndex.Add(new Vector3(5, 18, 1));
        smithIndex.Add(new Vector3(5, 19, 0));
        smithIndex.Add(new Vector3(6, 8, 2));
        smithIndex.Add(new Vector3(6, 9, 1));
        smithIndex.Add(new Vector3(6, 10, 0));
        smithIndex.Add(new Vector3(7, 11, 1));
        smithIndex.Add(new Vector3(7, 12, 0));
        smithIndex.Add(new Vector3(8, 27, 4));
        smithIndex.Add(new Vector3(8, 31, 3));
        smithIndex.Add(new Vector3(8, 32, 2));
        smithIndex.Add(new Vector3(8, 33, 1));
        smithIndex.Add(new Vector3(8, 34, 0));
        smithIndex.Add(new Vector3(9, 27, 3));
        smithIndex.Add(new Vector3(9, 28, 2));
        smithIndex.Add(new Vector3(9, 29, 1));
        smithIndex.Add(new Vector3(9, 30, 0));
        smithIndex.Add(new Vector3(10, 20, 3));
        smithIndex.Add(new Vector3(10, 21, 2));
        smithIndex.Add(new Vector3(10, 22, 1));
        smithIndex.Add(new Vector3(10, 23, 0));
        smithIndex.Add(new Vector3(11, 24, 2));
        smithIndex.Add(new Vector3(11, 25, 1));
        smithIndex.Add(new Vector3(11, 26, 0));
        smithIndex.Add(new Vector3(12, 30, 0));
        smithIndex.Add(new Vector3(13, 14, 0));
        smithIndex.Add(new Vector3(14, 13, 0));
        smithIndex.Add(new Vector3(15, 35, 0));
    }
    void Update()
    {
        if(Vector3.Distance(player1.transform.position, this.transform.position) <= 2.5) {
            timer = 0;
            moveTextAway = true;
            if(dialogueState == 0) {
                eToTalk.transform.position = this.transform.position + new Vector3(0, (float)1.5, 0);
            }
            else if(blacksmithTalking == false) {
                /*if(dialogueState == 1 && doneAdding == false) {
                    if(PlayerPrefs.GetInt("talkedToBlacksmith") == 0) {
                        curResponses.Add("Are you a smith?");
                    }
                    else {
                        curResponses.Add("I need some more work done on my sword");
                    }
                    curResponses.Add("Nothing, sorry");
                    doneAdding = true;
                    if(Input.GetKeyDown("e")) {
                        
                    }*/
                foreach(Vector3 i in playerIndex) {
                    if((int)i.x == dialogueState) {
                        curResponses.Add(playerRespond()[(int)i.y]);
                    }
                }
                playerText1.text = curResponses[0];
                if(curResponses.Count > 1) {
                    playerText2.text = curResponses[1];
                }
                selector.transform.localPosition = sPosition1;
            }
            else if(smithTextIndex < 0) {
                for(int i = 0; i < smithIndex.Count; i++) {
                    if((int)smithIndex[i].x == dialogueState && (int)smithIndex[i].z > smithTextIndex) {
                        smithTextIndex = (int)smithIndex[i].z;
                        smithIndexIndex = i;
                    }
                }
                smithText.text = smithResponses[(int)smithIndex[smithIndexIndex].y];
            }
            else {
                if(Input.GetKeyDown("e")) {
                    if(smithTextIndex > 0) {
                        smithIndexIndex += 1;
                        smithText.text = smithResponses[(int)smithIndex[smithIndexIndex].y];
                    }
                    else {
                        blacksmithTalking = false;
                    }
                    smithTextIndex--;
                }
            }
            //remember to clear out curresponses at the end of selecting a playerresponse



            player1.GetComponent<attack>().swordPresent = true;
            if(curResponses.Count > 0) {
                if(Input.GetKeyDown(KeyCode.UpArrow) && selected > 0) {
                    selected--;
                    if(selector.transform.localPosition == sPosition2) {
                        selector.transform.localPosition = sPosition1;
                    }
                    else {
                        playerText1.text = curResponses[selected];
                        playerText2.text = curResponses[selected + 1];
                    }
                }
                else if(Input.GetKeyDown(KeyCode.DownArrow) && selected < curResponses.Count - 1) {
                    selected++;
                    if(selector.transform.localPosition == sPosition1) {
                        selector.transform.localPosition = sPosition2;
                    }
                    else {
                        playerText1.text = curResponses[selected - 1];
                        playerText2.text = curResponses[selected];
                    }
                }
                if(Input.GetKeyDown("e")) {
                    foreach(Vector3 i in playerIndex) {
                        if(playerRespond()[(int)i.y].Equals(curResponses[selected])) {
                            if(PlayerPrefs.GetInt("bSmithState3Done") == 0 && dialogueState == 3 && i.y != 2) {
                                playerIndex.Remove(new Vector3(3, 3, 4));
                                PlayerPrefs.SetInt("bSmithState3Done", 1);
                            }
                            dialogueState = (int)i.z;
                            blacksmithTalking = true;
                            smithTextIndex = -1;
                            curResponses.Clear();
                            playerText1.text = "";
                            playerText2.text = "";
                            if(PlayerPrefs.GetInt("talkedToBlacksmith") == 0 && i.y != 2) {
                                playerIndex.RemoveAt(0);
                                PlayerPrefs.SetInt("talkedToBlacksmith", 1);
                            }
                            break;
                        }
                    }
                }
            }
            if(Input.GetKeyDown("e") && dialogueState == 0) {

                smithText.text = "Yeah? The fuck do you want?";
                dialogueState = 1;
                selector.transform.localPosition = sPosition1;
                selected = 0;
                curResponses.Clear();
            }
        }
        else if(moveTextAway == true) {
            eToTalk.transform.position = new Vector3(8500, 8500, 0);
            smithText.text = "Hey what the fuck man you just gonna leave in the middle of a fuckin conversation?";
            playerText1.text = "";
            playerText2.text = "";
            curResponses.Clear();
            blacksmithTalking = false;
            smithTextIndex = -1;
            dialogueState = 0;
            timer += Time.deltaTime;
            if(timer >= 0.15) {
                smithText.text = "";
                moveTextAway = false;
            }
        }
    }
}
