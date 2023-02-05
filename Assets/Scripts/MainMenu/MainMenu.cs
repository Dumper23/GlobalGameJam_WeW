using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject credits;

    private void Start()
    {
        GameManager.Instance.mainMenuSound.Play();
        Time.timeScale = 0;
    }

    public void playGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
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