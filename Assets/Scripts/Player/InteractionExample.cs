using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionExample : IEInteractable
{
    public string msg;
    public override void Interaction()
    {
        Debug.Log(msg);
    }
}
