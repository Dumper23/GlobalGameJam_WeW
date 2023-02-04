using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorItem : MonoBehaviour
{
    public GameObject frontground;
    
    public void showFloor()
    {
        frontground.SetActive(false);
    }

    public void hideFloor()
    {
        frontground.SetActive(true);
    }
}
