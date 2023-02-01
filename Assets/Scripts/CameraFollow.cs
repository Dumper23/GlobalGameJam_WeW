using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private FloorManager floors;
    
    public float smoothFactor;
    public float yOffset = 10;
    public float xOffset = 0;

    private Vector3 target;

    private void Start()
    {
        floors = FindObjectOfType<FloorManager>();
    }

    void Update()
    {
        Vector3 floorPosition = floors.liftDoors[GameManager.Instance.getCurrentFloor()].transform.position;
        target = new Vector3(floorPosition.x + xOffset, floorPosition.y + yOffset, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.x, target.y, -10), smoothFactor*Time.deltaTime);
    }
}
