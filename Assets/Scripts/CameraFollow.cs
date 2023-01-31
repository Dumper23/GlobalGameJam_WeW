using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothFactor;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, -10), smoothFactor*Time.deltaTime);
    }
}
