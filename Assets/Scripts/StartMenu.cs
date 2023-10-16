using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
   public void StarScene()
    {
        SceneManager.LoadScene("Level1");
    }
    public void MenuScene()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1;
    }
}
