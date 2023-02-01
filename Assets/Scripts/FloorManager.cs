using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [Header("Set the floors in ascendent order (0 = 1st floor, 1  = 2nd floor, 2 = 3rd floor, ...)")]
    public List<GameObject> liftDoors = new List<GameObject>();

    private PlayerController player;

    public static FloorManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void floorUp()
    {
        if(GameManager.Instance.getCurrentFloor() < GameManager.Instance.getUnlockedFloors() - 1)
        {
            //TP player to the upper level after an animation
            GameManager.Instance.setCurrentFloor(GameManager.Instance.getCurrentFloor() + 1);
            player.transform.position = liftDoors[GameManager.Instance.getCurrentFloor()].transform.position;
        }
    }

    public void floorDown()
    {
        if (GameManager.Instance.getCurrentFloor() > 0)
        {
            //TP player to the lower level after an animation
            GameManager.Instance.setCurrentFloor(GameManager.Instance.getCurrentFloor() - 1);
            player.transform.position = liftDoors[GameManager.Instance.getCurrentFloor()].transform.position;
        }
    }
}
