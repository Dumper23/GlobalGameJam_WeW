using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraFollow : MonoBehaviour
{
    private FloorManager floors;

    public float smoothFactor;
    public float yOffset = 10;
    public float xOffset = 0;

    private Vector3 target;
    private bool isRootView = false;
    private bool wasRootView = false;
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
        GameManager.Instance.setVisibilityInventoryUI(!isGeneralView);
        SkillTree.Instance.GeneralMapUpdateAll(isGeneralView);
    }

    public void setRootView(bool isRootView)
    {
        this.isRootView = isRootView;
        wasRootView = !isRootView;
        GameManager.Instance.setVisibilityInventoryUI(!isRootView);
    }

    public void setGeneralView(bool isGeneralView)
    {
        this.isGeneralView = isGeneralView;
    }

    private void Update()
    {
        if (!isRootView)
        {
            if (!isGeneralView)
            {
                GameManager.Instance.updateFloorVisuals();
                Vector3 floorPosition = floors.liftDoors[GameManager.Instance.getCurrentFloor()].transform.position;
                target = new Vector3(floorPosition.x + xOffset, floorPosition.y + yOffset, transform.position.z);

                if (!wasGeneralView && !wasRootView)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(target.x, target.y, -10), smoothFactor * Time.deltaTime);
                }
                else
                {
                    transform.position = target;
                    wasGeneralView = false;
                    wasRootView = false;
                }
                cam.orthographicSize = 3f;
            }
            else
            {
                GameManager.Instance.globalMapVisionUpdate();
                transform.position = new Vector3(0, 10f, transform.position.z);
                cam.orthographicSize = 18f;
            }
        }
        else
        {
            transform.position = new Vector3(0f, -16f, transform.position.z);
            cam.orthographicSize = 16f;
        }
    }

    public void blurCamera()
    {
        if (gameObject.GetComponent<PostProcessVolume>().profile.TryGetSettings(out DepthOfField dof))
        {
            dof.enabled.value = true;

            dof.focusDistance.value = Mathf.Lerp(10, 1, 1);
        }
    }

    public void focusCamera()
    {
        if (gameObject.GetComponent<PostProcessVolume>().profile.TryGetSettings(out DepthOfField dof))
        {
            dof.focusDistance.value = Mathf.Lerp(1, 10, 1);

            dof.enabled.value = false;
        }
    }
}