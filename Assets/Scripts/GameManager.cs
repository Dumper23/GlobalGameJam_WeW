using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera mainCam;
    public int unlockedFloors = 10;
    public int fertilizer = 0;

    private PlayerController player;
    public Transform[] enemyGroundWaypoints;
    public Transform[] enemyAirWaypoints;
    public int playerHP; 
    public List<EnemySpawn> enemySpawns;
    public bool isDay = false;

    private int currentDay = 1;
    private int currentFloor = 0;
    private bool playerInMenu = false;

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

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        changeDayState();
    }

    #region getters & setters
    public bool getPlayerInMenu()
    {
        return playerInMenu;
    }

    public void setMenuState(bool state)
    {
        playerInMenu = state;
    }

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

    public void toggleMapView()
    {
        mainCam.GetComponent<CameraFollow>().toggleGeneralView();
    }

    public bool isGamePaused()
    {
        return gamePaused;
    }

    public void showPlacementMenuUI()
    {
        player.placementMenu.SetActive(true);
    }
    
    public void showRemoveMenuUI()
    {
        player.removeMenu.SetActive(true);
    }

    public void hideRemoveMenuUI()
    {
        player.removeMenu.SetActive(false);
        GameManager.Instance.setMenuState(false);
        player.interactionSymbolE.SetActive(false);
    }

    public void hidePlacementMenuUI()
    {
        player.placementMenu.SetActive(false);
        GameManager.Instance.setMenuState(false);
    }

    public bool pickUpAmmo(string ammoType)
    {
        //If player has no space return false
        if (player.resourcesInventory.TryGetValue(ammoType, out int ammoAmount))
        {
            //Update player.resourcesInventory (ammo in the slot should be up to the maximum of the inventory)
            player.resourcesInventory[ammoType] = Database.PLAYER_CAPACITY[Database.PLAYER_CAPACITY_LVL];
        }
        else
        {
            if (player.resourcesInventory.Count < Database.PLAYER_INVENTORY[Database.PLAYER_INVENTORY_LVL]) //Ha de ser del nivell de la millora de la database.player_inventory_level
            {
                player.resourcesInventory.Add(ammoType, Database.PLAYER_CAPACITY[Database.PLAYER_CAPACITY_LVL]); //Ha de ser del nivell de la millora de database.player_capacity
            }
        }
        return true;
    }

    public void placeAmmo()
    {
        //Somehow we need to add the ammotype to the turret if the player has it
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
                
            case 2:
                return Database.DAY2_WAVES;

            case 3:
                return Database.DAY3_WAVES;

            case 4:
                return Database.DAY4_WAVES;

            case 5:
                return Database.DAY5_WAVES;

            case 6:
                return Database.DAY6_WAVES;

            case 7:
                return Database.DAY7_WAVES;

            case 8:
                return Database.DAY8_WAVES;

            case 9:
                return Database.DAY9_WAVES;

            case 10:
                return Database.DAY10_WAVES;

            case 11:
                return Database.DAY11_WAVES;

            case 12:
                return Database.DAY12_WAVES;

            case 13:
                return Database.DAY13_WAVES;

            case 14:
                return Database.DAY14_WAVES;

            case 15:
                return Database.DAY15_WAVES;

            case 16:
                return Database.DAY16_WAVES;

            case 17:
                return Database.DAY17_WAVES;

            case 18:
                return Database.DAY18_WAVES;

            case 19:
                return Database.DAY19_WAVES;

            case 20:
                return Database.DAY20_WAVES;

            case 21:
                return Database.DAY21_WAVES;

            case 22:
                return Database.DAY22_WAVES;

            case 23:
                return Database.DAY23_WAVES;

            default:
                return new List<EnemyWave>();
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
        int damageLevel;
        int speedLevel;
        int chestLevel;
        int capacityLevel;
        int sticknessLevel;
        int ricochetLevel;
        int areaLevel;
        int clusterLevel;
        int rangeLevel;
        int extraLevel;
        int hitsLevel;
        int piercingLevel;
        int projectilesLevel;
        int rayLevel;
        int stunLevel;
        int damageStunLevel;

        Dictionary<string, float> turretInfo = new Dictionary<string, float>();
        switch (turretId)
        {
            case "MACHINE_SEED":
                chestLevel = Database.MACHINE_SEED_CHEST_LVL;
                capacityLevel = Database.MACHINE_SEED_CAPACITY_LVL;
                damageLevel = Database.MACHINE_SEED_DAMAGE_LVL;
                speedLevel = Database.MACHINE_SEED_SPEED_LVL;

                turretInfo.Add("capacity", Database.MACHINE_SEED_CAPACITY[capacityLevel]);
                turretInfo.Add("chest", Database.MACHINE_SEED_CHEST[chestLevel]);
                turretInfo.Add("damage", (int)Database.MACHINE_SEED_DAMAGE[damageLevel]);
                turretInfo.Add("speed", Database.MACHINE_SEED_SPEED[speedLevel]);
                turretInfo.Add("damageLevel", damageLevel);
                turretInfo.Add("speedLevel", speedLevel);
                turretInfo.Add("chestLevel", chestLevel);
                turretInfo.Add("capacityLevel", capacityLevel);

                return turretInfo;
            case "RESIN_SPIT":
                chestLevel = Database.RESIN_SPIT_CHEST_LVL;
                capacityLevel = Database.RESIN_SPIT_CAPACITY_LVL;
                damageLevel = Database.RESIN_SPIT_DAMAGE_LVL;
                speedLevel = Database.RESIN_SPIT_SPEED_LVL;
                sticknessLevel = Database.RESIN_SPIT_STICKNESS_LVL;


                turretInfo.Add("capacity", Database.RESIN_SPIT_CAPACITY[capacityLevel]);
                turretInfo.Add("chest", Database.RESIN_SPIT_CHEST[chestLevel]);
                turretInfo.Add("damage", Database.RESIN_SPIT_DAMAGE[damageLevel]);
                turretInfo.Add("speed", Database.RESIN_SPIT_SPEED[speedLevel]);
                turretInfo.Add("stick", Database.RESIN_SPIT_STICKNESS[sticknessLevel]);
                turretInfo.Add("chestLevel", chestLevel);
                turretInfo.Add("capacityLevel", capacityLevel);
                turretInfo.Add("damageLevel", damageLevel);
                turretInfo.Add("speedLevel", speedLevel);
                turretInfo.Add("sticknessLevel", sticknessLevel);
                return turretInfo;
            case "S_SEEDNIPER":
                chestLevel = Database.S_SEEDNIPER_CHEST_LVL;
                capacityLevel = Database.S_SEEDNIPER_CAPACITY_LVL;
                damageLevel = Database.S_SEEDNIPER_DAMAGE_LVL;
                ricochetLevel = Database.S_SEEDNIPER_RICOCHET_LVL;
                speedLevel = Database.S_SEEDNIPER_SPEED_LVL;

                turretInfo.Add("capacity", Database.S_SEEDNIPER_CAPACITY[capacityLevel]);
                turretInfo.Add("chest", Database.S_SEEDNIPER_CHEST[chestLevel]);
                turretInfo.Add("damage", Database.S_SEEDNIPER_DAMAGE[damageLevel]);
                turretInfo.Add("ricochet", Database.S_SEEDNIPER_RICOCHET[ricochetLevel]);
                turretInfo.Add("speed", Database.S_SEEDNIPER_SPEED[speedLevel]);

                turretInfo.Add("chestLevel", chestLevel);
                turretInfo.Add("capacityLevel", capacityLevel);
                turretInfo.Add("damageLevel", damageLevel);
                turretInfo.Add("ricochetLevel", ricochetLevel);
                turretInfo.Add("speedLevel", speedLevel);
                return turretInfo;
            case "PINECONE_LAUNCHER":
                chestLevel = Database.PINECONE_LAUNCHER_CHEST_LVL;
                capacityLevel = Database.PINECONE_LAUNCHER_CAPACITY_LVL;
                areaLevel = Database.PINECONE_LAUNCHER_AREA_LVL;
                clusterLevel = Database.PINECONE_LAUNCHER_CLUSTER_LVL;
                damageStunLevel = Database.PINECONE_LAUNCHER_DAMAGE_STUN_LVL;
                damageLevel = Database.PINECONE_LAUNCHER_DAMAGE_LVL;
                rangeLevel = Database.PINECONE_LAUNCHER_RANGE_LVL;
                speedLevel = Database.PINECONE_LAUNCHER_SPEED_LVL;

                turretInfo.Add("capacity", Database.PINECONE_LAUNCHER_CAPACITY[capacityLevel]);
                turretInfo.Add("chest", Database.PINECONE_LAUNCHER_CHEST[chestLevel]);
                turretInfo.Add("area", Database.PINECONE_LAUNCHER_AREA[areaLevel]);
                turretInfo.Add("cluster", Database.PINECONE_LAUNCHER_CLUSTER[clusterLevel]);
                turretInfo.Add("damage", Database.PINECONE_LAUNCHER_DAMAGE[damageLevel]);
                turretInfo.Add("stun", Database.PINECONE_LAUNCHER_DAMAGE_STUN[damageStunLevel]);
                turretInfo.Add("range", Database.PINECONE_LAUNCHER_RANGE[rangeLevel]); 
                turretInfo.Add("speed", Database.PINECONE_LAUNCHER_SPEED[speedLevel]);

                turretInfo.Add("capacityLevel", capacityLevel);
                turretInfo.Add("chestLevel", chestLevel);
                turretInfo.Add("areaLevel", areaLevel);
                turretInfo.Add("clusterLevel", clusterLevel);
                turretInfo.Add("damageStunLevel", damageStunLevel);
                turretInfo.Add("damageLevel", damageLevel);
                turretInfo.Add("rangeLevel", rangeLevel);
                turretInfo.Add("speedLevel", speedLevel);
                return turretInfo;
            case "NUT_ROLL":
                chestLevel = Database.NUT_ROLL_CHEST_LVL;
                capacityLevel = Database.NUT_ROLL_CAPACITY_LVL;
                damageLevel = Database.NUT_ROLL_DAMAGE_LVL;
                extraLevel = Database.NUT_ROLL_EXTRA_LVL;
                hitsLevel = Database.NUT_ROLL_HITS_LVL;
                speedLevel = Database.NUT_ROLL_SPEED_LVL;

                turretInfo.Add("capacity", Database.NUT_ROLL_CAPACITY[capacityLevel]);
                turretInfo.Add("chest", Database.NUT_ROLL_CHEST[chestLevel]);
                turretInfo.Add("damage", Database.NUT_ROLL_DAMAGE[damageLevel]);
                turretInfo.Add("extra", Database.NUT_ROLL_EXTRA[extraLevel]);
                turretInfo.Add("hits", Database.NUT_ROLL_HITS[hitsLevel]);
                turretInfo.Add("speed", Database.NUT_ROLL_SPEED[speedLevel]);

                turretInfo.Add("chestLevel", chestLevel);
                turretInfo.Add("capacityLevel", capacityLevel);
                turretInfo.Add("damageLevel", damageLevel);
                turretInfo.Add("extraLevel", extraLevel);
                turretInfo.Add("hitsLevel", hitsLevel);
                turretInfo.Add("speedLevel", speedLevel);
                return turretInfo;
            case "PORCUTHROW":
                chestLevel = Database.PORCUTHROW_CHEST_LVL;
                capacityLevel = Database.PORCUTHROW_CAPACITY_LVL;
                piercingLevel = Database.PORCUTHROW_PIERCING_LVL;
                projectilesLevel = Database.PORCUTHROW_PROJECTILES_LVL;
                speedLevel = Database.PORCUTHROW_SPEED_LVL;

                turretInfo.Add("capacity", Database.PORCUTHROW_CAPACITY[capacityLevel]);
                turretInfo.Add("chest", Database.PORCUTHROW_CHEST[chestLevel]);
                turretInfo.Add("piercing", Database.PORCUTHROW_PIERCING[piercingLevel]);
                turretInfo.Add("projectiles", Database.PORCUTHROW_PROJECTILES[projectilesLevel]);
                turretInfo.Add("speed", Database.PORCUTHROW_SPEED[speedLevel]);

                turretInfo.Add("chestLevel", chestLevel);
                turretInfo.Add("capacityLevel", capacityLevel);
                turretInfo.Add("piercingLevel", piercingLevel);
                turretInfo.Add("projectilesLevel", projectilesLevel);
                turretInfo.Add("speedLevel", speedLevel);
                return turretInfo;
            case "ELECTRIC_POTATO":
                chestLevel = Database.ELECTRIC_POTATO_CHEST_LVL;
                capacityLevel = Database.ELECTRIC_POTATO_CAPACITY_LVL;
                damageLevel = Database.ELECTRIC_POTATO_DAMAGE_LVL;
                rayLevel = Database.ELECTRIC_POTATO_RAY_LVL;
                speedLevel = Database.ELECTRIC_POTATO_SPEED_LVL;
                stunLevel = Database.ELECTRIC_POTATO_STUN_LVL;

                turretInfo.Add("capacity", Database.ELECTRIC_POTATO_CAPACITY[capacityLevel]);
                turretInfo.Add("chest", Database.ELECTRIC_POTATO_CHEST[chestLevel]);
                turretInfo.Add("damage", Database.ELECTRIC_POTATO_DAMAGE[damageLevel]);
                turretInfo.Add("ray", Database.ELECTRIC_POTATO_RAY[rayLevel]);
                turretInfo.Add("speed", Database.ELECTRIC_POTATO_SPEED[speedLevel]);
                turretInfo.Add("stun", Database.ELECTRIC_POTATO_STUN[stunLevel]);

                turretInfo.Add("chestLevel", chestLevel);
                turretInfo.Add("capacityLevel", capacityLevel);
                turretInfo.Add("damageLevel", damageLevel);
                turretInfo.Add("rayLevel", rayLevel);
                turretInfo.Add("speedLevel", speedLevel);
                turretInfo.Add("stunLevel", stunLevel);
                return turretInfo;
            default:

                return null;
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
