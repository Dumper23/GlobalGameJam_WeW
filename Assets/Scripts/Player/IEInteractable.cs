using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEInteractable: MonoBehaviour
{
    protected bool alredyInteracted = false;
    protected float cooldown = 0f;
    public string iconName;
    public abstract void Interaction(string action = "");
  
}
