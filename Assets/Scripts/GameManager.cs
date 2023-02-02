using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] enemyGroundWaypoints;
    public Transform[] enemyAirWaypoints;
    public int playerHP; 
    public List<EnemySpawn> enemySpawns;
    public bool isDay = false;

    private int currentDay = 1;
    private int currentFloor = 0;
    private int unlockedFloors = 4;

    private bool gamePaused = false;

    #region Constants
    public static string ANT_ID = "ant";
    public static string FLEA_ID = "flea";
    public static string BEETLE_ID = "beetle";
    public static string FLY_ID = "fly";
    public static string WASP_ID = "wasp";
    #endregion

    #region Singleton
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
    #endregion

    #region getters & setters
    public int getCurrentDay()
    {
        return currentDay;
    }

    public int getCurrentFloor()
    {
        return currentFloor;

    }

    public int getUnlockedFloors()
    {
        return unlockedFloors;
    }

    public void setUnlockedFloors(int unlockedFloors)
    {
        this.unlockedFloors = unlockedFloors;
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

    void Start()
    {
        changeDayState();
    }

    public bool isGamePaused()
    {
        return gamePaused;
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

    public List<EnemyWave> getCurrentDayWavesSpawn(string spawnId)
    {
        List<EnemyWave> enemyWaves = getCurrentDayWaves();
        List<EnemyWave> wavesSpawn = new List<EnemyWave>();
        foreach (EnemyWave wave in enemyWaves)
        {
            if (wave.spawnId == spawnId)
            {
                wavesSpawn.Add(wave);
            }
        }
        return wavesSpawn;
    }

    public Dictionary<string, float> getTurretInfo(string turretId)
    {
        int turretLevel;
        Dictionary<string, float> turretInfo = new Dictionary<string, float>();
        switch (turretId)
        {
            case "MACHINE_SEED":
                turretLevel = Database.MACHINE_SEED_LEVEL;
                turretInfo.Add("capacity", Database.MACHINE_SEED_CAPACITY[turretLevel]);
                turretInfo.Add("chest", Database.MACHINE_SEED_CHEST[turretLevel]);
                turretInfo.Add("damage", (int)Database.MACHINE_SEED_DAMAGE[turretLevel]);
                turretInfo.Add("level", turretLevel);
                turretInfo.Add("speed", Database.MACHINE_SEED_SPEED[turretLevel]);
                return turretInfo;
                break;
            case "RESIN_SPIT":
                turretLevel = Database.RESIN_SPIT_LEVEL;
                turretInfo.Add("capacity", Database.RESIN_SPIT_CAPACITY[turretLevel]);
                turretInfo.Add("chest", Database.RESIN_SPIT_CHEST[turretLevel]);
                turretInfo.Add("damage", Database.RESIN_SPIT_DAMAGE[turretLevel]);
                turretInfo.Add("level", Database.RESIN_SPIT_LEVEL);
                turretInfo.Add("speed", Database.RESIN_SPIT_SPEED[turretLevel]);
                turretInfo.Add("stick", Database.RESIN_SPIT_STICKNESS[turretLevel]);
                return turretInfo;
                break;
            case "S_SEEDNIPER":
                turretLevel = Database.S_SEEDNIPER_LEVEL;
                turretInfo.Add("capacity", Database.S_SEEDNIPER_CAPACITY[turretLevel]);
                turretInfo.Add("chest", Database.S_SEEDNIPER_CAPACITY[turretLevel]);
                turretInfo.Add("damage", Database.S_SEEDNIPER_DAMAGE[turretLevel]);
                turretInfo.Add("level", Database.S_SEEDNIPER_LEVEL);
                turretInfo.Add("ricochet", Database.S_SEEDNIPER_RICOCHET[turretLevel]);
                turretInfo.Add("speed", Database.S_SEEDNIPER_SPEED[turretLevel]);
                return turretInfo;
                break;
            case "PINECONE_LAUNCHER":
                turretLevel = Database.PINECONE_LAUNCHER_LEVEL;
                turretInfo.Add("capacity", Database.PINECONE_LAUNCHER_CAPACITY[turretLevel]);
                turretInfo.Add("chest", Database.PINECONE_LAUNCHER_CHEST[turretLevel]);
                turretInfo.Add("area", Database.PINECONE_LAUNCHER_AREA[turretLevel]);
                turretInfo.Add("cluster", Database.PINECONE_LAUNCHER_CLUSTER[turretLevel]);
                turretInfo.Add("damage", Database.PINECONE_LAUNCHER_DAMAGE[turretLevel]);
                if(turretLevel > 1)
                { 
                    turretInfo.Add("stun", Database.PINECONE_LAUNCHER_DAMAGE_STUN[1]);
                }
                turretInfo.Add("level", Database.PINECONE_LAUNCHER_LEVEL); 
                turretInfo.Add("range", Database.PINECONE_LAUNCHER_RANGE[turretLevel]); 
                turretInfo.Add("speed", Database.PINECONE_LAUNCHER_SPEED[turretLevel]); 
                return turretInfo;
                break;
            case "NUT_ROLL":
                turretLevel = Database.NUT_ROLL_LEVEL;
                turretInfo.Add("capacity", Database.NUT_ROLL_CAPACITY[turretLevel]);
                turretInfo.Add("chest", Database.NUT_ROLL_CHEST[turretLevel]);
                turretInfo.Add("damage", Database.NUT_ROLL_DAMAGE[turretLevel]);
                turretInfo.Add("extra", Database.NUT_ROLL_EXTRA[turretLevel]);
                turretInfo.Add("hits", Database.NUT_ROLL_HITS[turretLevel]);
                turretInfo.Add("level", Database.NUT_ROLL_LEVEL);
                turretInfo.Add("speed", Database.NUT_ROLL_SPEED[turretLevel]);
                return turretInfo;
                break;
            case "PORCUTHROW":
                turretLevel = Database.PORCUTHROW_LEVEL;
                turretInfo.Add("capacity", Database.PORCUTHROW_CAPACITY[turretLevel]);
                turretInfo.Add("chest", Database.PORCUTHROW_CHEST[turretLevel]);
                turretInfo.Add("level", Database.PORCUTHROW_LEVEL);
                turretInfo.Add("piercing", Database.PORCUTHROW_PIERCING[turretLevel]);
                turretInfo.Add("projectiles", Database.PORCUTHROW_PROJECTILES[turretLevel]);
                turretInfo.Add("speed", Database.PORCUTHROW_SPEED[turretLevel]);
                return turretInfo;
                break;
            case "ELECTRIC_POTATO":
                turretLevel = Database.ELECTRIC_POTATO_LEVEL;
                turretInfo.Add("capacity", Database.ELECTRIC_POTATO_CAPACITY[turretLevel]);
                turretInfo.Add("chest", Database.ELECTRIC_POTATO_CHEST[turretLevel]);
                turretInfo.Add("damage", Database.ELECTRIC_POTATO_DAMAGE[turretLevel]);
                turretInfo.Add("level", Database.ELECTRIC_POTATO_LEVEL);
                turretInfo.Add("ray", Database.ELECTRIC_POTATO_RAY[turretLevel]);
                turretInfo.Add("speed", Database.ELECTRIC_POTATO_SPEED[turretLevel]);
                turretInfo.Add("stun", Database.ELECTRIC_POTATO_STUN[turretLevel]);
                return turretInfo;
                break;
            default:
                return null;
                break;
        }
    }

    public void removePlayerHP()
    {
        playerHP--;
        if (playerHP <= 0)
        {
            //gameOver
            Debug.Log("game over :(");
        }
    }

    public void changeDayState()
    {
        isDay = !isDay;
        if (isDay)
        {
            //activate spawns
            foreach (EnemySpawn spawn in enemySpawns)
            {
                spawn.activateSpawn();
            }
        }
        else
        {
            //deactivate spawns
            foreach (EnemySpawn spawn in enemySpawns)
            {
                spawn.deactivateSpawn();
            }
        }
    }
}
