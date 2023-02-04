using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FloorManager : MonoBehaviour
{
    [HideInInspector]
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
        updateDoors();
    }

    public void floorUp()
    {
        if (GameManager.Instance.getCurrentFloor() < GameManager.Instance.getUnlockedFloors() - 1)
        {
            //TP player to the upper level after an animation
            GameManager.Instance.playLiftSound();
            GameManager.Instance.setCurrentFloor(GameManager.Instance.getCurrentFloor() + 1);
            player.transform.position = liftDoors[GameManager.Instance.getCurrentFloor()].transform.position;
        }
        else
        {
            GameManager.Instance.cancelSound();
        }
    }

    public void floorDown()
    {
        if (GameManager.Instance.getCurrentFloor() > 0)
        {
            //TP player to the lower level after an animation
            GameManager.Instance.playLiftSound();
            GameManager.Instance.setCurrentFloor(GameManager.Instance.getCurrentFloor() - 1);
            player.transform.position = liftDoors[GameManager.Instance.getCurrentFloor()].transform.position;
        }
        else
        {
            GameManager.Instance.cancelSound();
        }
    }

    public void updateDoors()
    {
        liftDoors.Clear();
        FloorDoor[] doors = FindObjectsOfType<FloorDoor>();

        List<GameObject> unsortedList = new List<GameObject>();
        List<GameObject> sortedList = new List<GameObject>();

        foreach (var door in doors)
        {
            unsortedList.Add(door.gameObject);
        }

        sortedList = unsortedList.OrderBy(o => o.transform.position.y).ToList();

        foreach (var door in sortedList)
        {
            liftDoors.Add(door);
        }
    }
}