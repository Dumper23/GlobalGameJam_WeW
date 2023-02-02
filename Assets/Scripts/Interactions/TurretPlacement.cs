using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : IEInteractable
{
    public bool hasTurret = false;

    public override void EndInteraction()
    {
        GameManager.Instance.hidePlacementMenuUI();
        GameManager.Instance.hideRemoveMenuUI();
    }

    public override void Interaction(string action = "")
    {
        if (action == "")
        {
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
