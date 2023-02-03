using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : IEInteractable
{

    public override void EndInteraction()
    {
        
    }

    public override void Interaction(string action)
    {
        if (action.Equals("R"))
        {
            GameManager.Instance.deleteAmmo();
        }
    }
}
