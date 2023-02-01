using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentDay = 1;
    public int currentFloor = 0;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    #region getters & setters
    public int getCurrentDay()
    {
        return currentDay;
    }

    public int getCurrentFloor()
    {
        return currentFloor;

    }

    public void setCurrentFloor(int floor)
    {
        this.currentFloor = floor;
    }

    public void setCurrentDay(int day)
    {
        this.currentDay = day;
    }
    #endregion

    public List<EnemyWave> getCurrentDayWaves()
    {
        switch (currentDay)
        {
            case 1:
                return Database.DAY1_WAVES;
                break;

            case 2:
                return Database.DAY2_WAVES;
                break;

            case 3:
                return Database.DAY3_WAVES;
                break;

            case 4:
                return Database.DAY4_WAVES;
                break;

            case 5:
                return Database.DAY5_WAVES;
                break;

            case 6:
                return Database.DAY6_WAVES;
                break;

            case 7:
                return Database.DAY7_WAVES;
                break;

            case 8:
                return Database.DAY8_WAVES;
                break;

            case 9:
                return Database.DAY9_WAVES;
                break;

            case 10:
                return Database.DAY10_WAVES;
                break;

            case 11:
                return Database.DAY11_WAVES;
                break;

            case 12:
                return Database.DAY12_WAVES;
                break;

            case 13:
                return Database.DAY13_WAVES;
                break;

            case 14:
                return Database.DAY14_WAVES;
                break;

            case 15:
                return Database.DAY15_WAVES;
                break;

            case 16:
                return Database.DAY16_WAVES;
                break;

            case 17:
                return Database.DAY17_WAVES;
                break;

            case 18:
                return Database.DAY18_WAVES;
                break;

            case 19:
                return Database.DAY19_WAVES;
                break;

            case 20:
                return Database.DAY20_WAVES;
                break;

            case 21:
                return Database.DAY21_WAVES;
                break;

            case 22:
                return Database.DAY22_WAVES;
                break;

            case 23:
                return Database.DAY23_WAVES;
                break;

            default:
                return new List<EnemyWave>();
                break;
        }
    }


}
