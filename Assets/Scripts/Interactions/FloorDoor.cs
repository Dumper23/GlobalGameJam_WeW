using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDoor : IEInteractable
{
    public override void EndInteraction()
    {
        //NotUsed
    }

    public override void Interaction(string action)
    {
        if (action == "up")
        {
            FloorManager.Instance.floorUp();
        }
        else if (action == "down")
        {
            FloorManager.Instance.floorDown();
        }
    }
}