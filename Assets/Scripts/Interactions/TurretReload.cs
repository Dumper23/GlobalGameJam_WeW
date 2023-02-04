using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretReload : IEInteractable
{
    public override void EndInteraction()
    {
    }

    public override void Interaction(string action = "")
    {
        GameManager.Instance.placeAmmo(GetComponent<TurretsFather>());
    }
}