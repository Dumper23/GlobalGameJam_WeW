using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBalcony : MonoBehaviour
{
    [SerializeField]
    private float offsettAmmount = 8;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            Camera.main.GetComponent<CameraFollow>().xOffset -= offsettAmmount;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            Camera.main.GetComponent<CameraFollow>().xOffset += offsettAmmount;
        }
    }
}
