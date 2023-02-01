using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
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

    //Agafem els pisos que hi ha desbloquejats a la BBDD
    private int unlockedFloors = 4; //Mock
    private int currentPlayerFloor = 1; //Mock, hauria d'estar en el game manager
    [Header("Set the floors in ascendent order (0 = 1st floor, 1  = 2nd floor, 2 = 3rd floor, ...)")]
    public List<GameObject> liftDoors = new List<GameObject>();
    private PlayerController player;

    private void Start()
    {
        //Set the parameters "pisos" and "current"
        player = FindObjectOfType<PlayerController>();
    }

    public void floorUp()
    {
        if(currentPlayerFloor < unlockedFloors - 1)
        {
            //TP player to the upper level after an animation
            currentPlayerFloor++;
            player.transform.position = liftDoors[currentPlayerFloor].transform.position;
        }
    }

    public void floorDown()
    {
        if (currentPlayerFloor > 0)
        {
            //TP player to the lower level after an animation
            currentPlayerFloor--;
            player.transform.position = liftDoors[currentPlayerFloor].transform.position;
        }
    }
}
