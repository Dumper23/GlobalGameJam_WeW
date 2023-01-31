using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionExample : IEInteractable
{
    public override void Interaction()
    {
        Debug.Log("Interacted!");
    }
}
