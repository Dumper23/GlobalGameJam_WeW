using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject cmenu;

    public void playGame()
    {
        menu.SetActive(false);
    }

    public void creditsMenuOn()
    {
        cmenu.SetActive(true);
    }

    public void creditsMenuOff()
    {
        cmenu.SetActive(false);
        menu.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
