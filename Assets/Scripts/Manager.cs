using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class Manager : MonoBehaviour
{
    public Text CherryText;
    public static int Number_cherry;

    public GameObject[] Player_prf;
    int Index;
    public CinemachineVirtualCamera Cam;
    private void Awake()
    {
        Index = PlayerPrefs.GetInt("Player_select", 0);
        GameObject Player = Instantiate(Player_prf[Index], transform.position, Quaternion.identity);
        Cam.m_Follow = Player.transform;
    
        Number_cherry = PlayerPrefs.GetInt("Number_cherry", 50);
    }


    void Update()
    {
        CherryText.text = "Cheries: " + Number_cherry.ToString();
        PlayerPrefs.SetInt("Number_cherry", Number_cherry);
        PlayerPrefs.Save();
    }
}
