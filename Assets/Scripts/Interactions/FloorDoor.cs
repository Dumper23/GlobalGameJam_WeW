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
        if(action == "up") {
            FloorManager.Instance.floorUp();
            GameManager.Instance.playLiftSound();
        }
        else if (action == "down")
        {
            GameManager.Instance.playLiftSound();
            FloorManager.Instance.floorDown();
        }
    }
}
