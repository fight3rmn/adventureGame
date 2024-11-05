using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetHp : MonoBehaviour
{
    // Start is called before the first frame update
    public void onClick() {
        PlayerPrefs.SetInt("playerHp", 10);
        PlayerPrefs.SetInt("playerMaxHp", 10);
        PlayerPrefs.SetInt("playerMoney", 0);
        PlayerPrefs.SetInt("pauseUI", 1);
        PlayerPrefs.SetInt("hasBow", 0);
        PlayerPrefs.SetInt("hasTeleportCrystal", 0);
        PlayerPrefs.SetInt("hasHealthPotion", 0);
        PlayerPrefs.SetInt("hasBomb", 0);
        PlayerPrefs.SetInt("hasHeelies", 0);
        PlayerPrefs.SetInt("itemSelected", 0);
        PlayerPrefs.SetFloat("teleportXCoord", -425);
        PlayerPrefs.SetFloat("teleportYCoord", -168);
        PlayerPrefs.SetInt("teleportScene", 0);
        PlayerPrefs.SetInt("teleportCrystalSet", 0);
        PlayerPrefs.SetInt("potionInShopScene", 1);
        PlayerPrefs.SetInt("usedTeleport", 0);
        PlayerPrefs.SetInt("playerWeaponDamage", 1);
        for(int i = 1; i <= 1; i++) {
            PlayerPrefs.SetInt("todo" + i + "Destroyed", 0);
        }
        for(int i = 1; i <= 2; i++) {
            PlayerPrefs.SetInt("healthUpgrade" + i + "Found", 0);
        }
        PlayerPrefs.SetInt("dariaDestroyed", 0);
        PlayerPrefs.SetInt("dustinDestroyed", 0);
        PlayerPrefs.SetInt("ingots", 0);
        //PlayerPrefs.SetInt("talkedToBlacksmith", 0);
        PlayerPrefs.SetInt("wormHeartObtained", 0);
        //PlayerPrefs.SetInt("bSmithState3Done", 0);
        PlayerPrefs.SetInt("wormHP", 180);
    }
}
