using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPicking : IEInteractable
{
    public string ammoType;

    public override void EndInteraction()
    {
    }

    public override void Interaction(string action = "")
    {
        if (action.Equals("E"))
        {
            //Player ammo inventory add ammo
            if (GameManager.Instance.pickUpAmmo(ammoType))
            {
                GameManager.Instance.interactSound();
            }
            else
            {
                GameManager.Instance.cancelSound();
            }
        }
    }
}