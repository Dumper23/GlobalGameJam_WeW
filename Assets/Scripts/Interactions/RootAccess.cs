using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAccess : IEInteractable
{
    public override void EndInteraction()
    {
        GameManager.Instance.setRootView(false);
    }

    public override void Interaction(string action = "")
    {
        GameManager.Instance.setRootView(true);
    }
}