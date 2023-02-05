using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject credits;

    public void playGame()
    {
        menu.SetActive(false);
    }

    public void creditsMenuOn()
    {
        credits.SetActive(true);
    }

    public void creditsMenuOff()
    {
        credits.SetActive(false);
        menu.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
