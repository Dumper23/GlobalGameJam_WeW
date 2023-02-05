using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject credits;

    private bool isPauseMenu = false;

    private void Start()
    {
        GameManager.Instance.mainMenuSound.Play();
        Time.timeScale = 0;
    }

    public void playGame()
    {
        if (isPauseMenu)
        {
            menu.SetActive(false);
            Time.timeScale = 1;
            GameManager.Instance.mainMenuSound.Stop();
        }
        else
        {
            menu.SetActive(false);
            Time.timeScale = 1;
            GameManager.Instance.initialAnim.gameObject.SetActive(true);
            GameManager.Instance.initialAnim.startIntroScene();
        }
    }

    public void pauseMenu()
    {
        isPauseMenu = true;
        menu.SetActive(true);
        Time.timeScale = 0;
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