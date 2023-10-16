using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerSelect : MonoBehaviour
{
    public GameObject[] Skins;
    public int player_select;
    public Player[] player;

    public Button unlockButton;
    public Text cherry_text;


    private void Awake()
    {
        player_select = PlayerPrefs.GetInt("Player_select", 0);
        foreach(GameObject player in Skins)
        {
            player.SetActive(false);
        }
        Skins[player_select].SetActive(true);

        foreach(Player p in player)
        {
            if(p.price == 0 )
            {
                p.isUnlocked = true;
            }
            else
            {
                p.isUnlocked = PlayerPrefs.GetInt(p.name, 0) == 0 ? false : true;
            }
            
        }
        UpdateUI();
    }
    public void Player_next()
    {
        Skins[player_select].SetActive(false);
        player_select++;
        if(player_select == Skins.Length) {
            player_select = 0;
            
        }
        Skins[player_select].SetActive(true);
        if (player[player_select].isUnlocked)
        {
            PlayerPrefs.SetInt("Player_select", player_select);
        }
        UpdateUI();
    }
    public void Player_back()
    {
        Skins[player_select].SetActive(false);
        player_select--;
        if (player_select == -1)
        {
            player_select = Skins.Length - 1;
        }
        Skins[player_select].SetActive(true);
        if (player[player_select].isUnlocked)
        {
            PlayerPrefs.SetInt("Player_select", player_select);
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        cherry_text.text = "Cheries" + PlayerPrefs.GetInt("Number_cherry", 0);
        if (player[player_select].isUnlocked == true) 
        {
            unlockButton.gameObject.SetActive(false);
        }
        else 
        {
            unlockButton.GetComponentInChildren<Text>().text = "Cheries :" + player[player_select].price;
            if (PlayerPrefs.GetInt("Number_cherry", 0) < player[player_select].price)
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
            }
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
        }
    }
    public void Unlock()
    {
        int cherry = PlayerPrefs.GetInt("Number_cherry", 0);
        int price = player[player_select].price;
        if (cherry == 0) { Debug.Log("het tien"); }
        else
        {
            PlayerPrefs.SetInt("Number_cherry", (cherry - price));
            PlayerPrefs.SetInt(player[player_select].name, 1);
            PlayerPrefs.SetInt("Player_select", player_select);
            player[player_select].isUnlocked = true;
        }
        UpdateUI();
    }
}
