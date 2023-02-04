using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInTime : MonoBehaviour
{
    public float timeToDestroy = 2f;

    private void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }
}