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
    private bool isGeneralView;
    private bool wasGeneralView = false;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        floors = FindObjectOfType<FloorManager>();
    }

    public void toggleGeneralView()
    {
        isGeneralView = !isGeneralView;
        wasGeneralView = !isGeneralView;
    }

    public void setGeneralView(bool isGeneralView)
    {
        this.isGeneralView = isGeneralView;
    }


    void Update()
    {
        if (!isGeneralView)
        {
            Vector3 floorPosition = floors.liftDoors[GameManager.Instance.getCurrentFloor()].transform.position;
            target = new Vector3(floorPosition.x + xOffset, floorPosition.y + yOffset, transform.position.z);
            if (!wasGeneralView)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(target.x, target.y, -10), smoothFactor * Time.deltaTime);

            }
            else
            {
                transform.position = target;
            }
            wasGeneralView = false;
        }
        else
        {
            transform.position = new Vector3(-1.52f, 7.72f, transform.position.z);
        }

        if (isGeneralView)
        {
            cam.orthographicSize = 11f;
        }
        else
        {
            cam.orthographicSize = 3f;
        }
    }
}
