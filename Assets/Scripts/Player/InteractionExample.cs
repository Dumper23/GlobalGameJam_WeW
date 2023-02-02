using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionExample : IEInteractable
{
    public string msg;

    public override void EndInteraction()
    {
        //not used
    }

    public override void Interaction(string action)
    {
        if (action.Equals(""))
        {
            Debug.Log(msg);
        }
    }
}
