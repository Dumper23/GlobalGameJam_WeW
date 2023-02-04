using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEInteractable : MonoBehaviour
{
    protected bool alredyInteracted = false;
    protected float cooldown = 0f;
    public string iconName;
    public Sprite original;
    public Sprite outlined;

    public abstract void Interaction(string action = "");

    public abstract void EndInteraction();

    public void setOutline()
    {
        if (outlined != null) GetComponent<SpriteRenderer>().sprite = outlined;
    }

    public void setOriginal()
    {
        if (original != null) GetComponent<SpriteRenderer>().sprite = original;
    }
}