using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }
    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        {
            Instance = this; 
        } 
    }
    #endregion

    public Transform[] enemyGroundWaypoints;
    public Transform[] enemyAirWaypoints;
    public int playerHP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform[] getWaypoints(string type)
    {
        Transform[] waypoints = null;
        switch (type)
        {
            case "walk":
                waypoints = enemyGroundWaypoints;
                break;
            case "fly":
                waypoints = enemyAirWaypoints;
                break;
        }
        return waypoints;
    }

    public void removePlayerHP()
    {
        playerHP--;
        if(playerHP <= 0)
        {
            //gameOver
            Debug.Log("game over :(");
        }
    }
}
