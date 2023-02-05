using UnityEngine;

public class RootAccess : IEInteractable
{
    public override void EndInteraction()
    {
        GameManager.Instance.setRootView(false);
    }

    public override void Interaction(string action = "")
    {
        bool canAccesTable = true;
        if (GameManager.Instance.getCurrentDay() == 0)
        {
            canAccesTable = false;
            GameManager.Instance.cancelSound();
        }
        else if (GameManager.Instance.getCurrentDay() == 1 && GameManager.Instance.isDay)
        {
            canAccesTable = false;
            GameManager.Instance.cancelSound();
        }

        if (action.Equals("E") && !GameManager.Instance.getPlayerInMenu() && canAccesTable)
        {
            GameManager.Instance.setRootView(true);
            GameManager.Instance.setMenuState(true);
            GameManager.Instance.interactSound();
        }
        else if (GameManager.Instance.getCurrentDay() == 0 || !canAccesTable)
        {
            GameManager.Instance.bottomFloor.gameObject.transform.Find("Bunny").transform.GetChild(0).gameObject.SetActive(true);
            GameManager.Instance.bottomFloor.gameObject.transform.Find("Bunny").transform.GetChild(0).GetComponent<Animator>().Play("BfadeIn");
            GameManager.Instance.bottomFloor.gameObject.transform.Find("Bunny").transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>().Play("BfadeIn");
            Invoke("deactivateSprite", 3);
        }
    }

    private void deactivateSprite()
    {
        GameManager.Instance.bottomFloor.gameObject.transform.Find("Bunny").transform.GetChild(0).gameObject.SetActive(false);
    }
}