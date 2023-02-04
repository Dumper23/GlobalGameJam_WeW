using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDoor : IEInteractable
{
    private void Start()
    {
        if (Database.Instance.PLAYER_LIFT_LVL > 0)
        {
            cooldown = Database.Instance.PLAYER_LIFT_VALUE[Database.Instance.PLAYER_LIFT_LVL - 1];
        }
        else
        {
            cooldown = 1;
        }
    }

    public void updateCooldown()
    {
        if (Database.Instance.PLAYER_LIFT_LVL > 0)
        {
            cooldown = Database.Instance.PLAYER_LIFT_VALUE[Database.Instance.PLAYER_LIFT_LVL - 1];
            Debug.Log(cooldown);
        }
        else
        {
            cooldown = 1;
        }
    }

    public override void EndInteraction()
    {
        //NotUsed
    }

    public override void Interaction(string action)
    {
        if (action == "up" && !GameManager.Instance.alreadyInteracted)
        {
            if (FloorManager.Instance.floorUp())
            {
                GameManager.Instance.alreadyInteracted = true;
                GameManager.Instance.interactionCooldown = cooldown;
                GameManager.Instance.playLiftAnimation();
                Invoke("notInteracted", cooldown);
            }
        }
        else if (action == "down" && !GameManager.Instance.alreadyInteracted)
        {
            if (FloorManager.Instance.floorDown())
            {
                GameManager.Instance.alreadyInteracted = true;
                GameManager.Instance.interactionCooldown = cooldown;
                GameManager.Instance.playLiftAnimation();
                Invoke("notInteracted", cooldown);
            }
        }
        else
        {
            GameManager.Instance.cancelSound();
        }
    }

    private void notInteracted()
    {
        GameManager.Instance.alreadyInteracted = false;
    }
}