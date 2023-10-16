using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IAP : MonoBehaviour
{
    public Text CherryText;
    public void cherry100()
    {
        Manager.Number_cherry += 100;
        PlayerPrefs.SetInt("Number_cherry", Manager.Number_cherry);
        PlayerPrefs.Save();
    }
    public void cherry1000()
    {
        Manager.Number_cherry += 1000;
        PlayerPrefs.SetInt("Number_cherry", Manager.Number_cherry);
        PlayerPrefs.Save();
    }
    void Update()
    {
        CherryText.text = "Cheries: " + Manager.Number_cherry.ToString();
    }
}
