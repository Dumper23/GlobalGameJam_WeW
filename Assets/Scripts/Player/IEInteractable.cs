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
        if (GetComponent<TurretPlacholder>() && GetComponent<TurretPlacholder>().currentTurretObject)
        {
            TurretsFather tf = GetComponent<TurretPlacholder>().currentTurretObject.GetComponent<TurretsFather>();
            tf.mobile.sprite = tf.outlinedMobile;
            tf.fixedPart.sprite = tf.outlinedFixed;
        }
    }

    public void setOriginal()
    {
        if (original != null) GetComponent<SpriteRenderer>().sprite = original;
        if (GetComponent<TurretPlacholder>() && GetComponent<TurretPlacholder>().currentTurretObject)
        {
            TurretsFather tf = GetComponent<TurretPlacholder>().currentTurretObject.GetComponent<TurretsFather>();
            tf.mobile.sprite = tf.originalMobile;
            tf.fixedPart.sprite = tf.originalFixed;
        }
    }
}