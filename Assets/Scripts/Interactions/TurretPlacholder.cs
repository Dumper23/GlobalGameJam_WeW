using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacholder : IEInteractable
{
    public bool hasTurret = false;
    public int turretPlacementId;
    public string turretId;
    public GameObject turretPlaceHolder;

    private void Start()
    {
        turretPlaceHolder.SetActive(true);
    }

    public override void EndInteraction()
    {
        GameManager.Instance.hidePlacementMenuUI();
        GameManager.Instance.hideRemoveMenuUI();
    }

    public override void Interaction(string action = "")
    {
        if (action == "E")
        {
            GameManager.Instance.interactSound();
            if (hasTurret)
            {
                GameManager.Instance.showRemoveMenuUI();
            }
            else
            {
                GameManager.Instance.showPlacementMenuUI();
            }
            GameManager.Instance.setMenuState(true);
        }
    }
}