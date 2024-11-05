using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawnPotion : MonoBehaviour
{
    public attack atk;
    void Start() {
        if(PlayerPrefs.GetInt("potionInShopScene") == SceneManager.GetActiveScene().buildIndex) {
            atk.potionInShop.GetComponent<purchase>().pm = atk.pm;
            atk.potionInShop.GetComponent<purchase>().thisMenuObject = atk.pauseHealthPotion;
            Instantiate(atk.potionInShop);
        }
    }
}
