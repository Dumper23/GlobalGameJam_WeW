using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(0)]
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

    private int currentDay = 0;
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

    public void toogleRootView()
    {
        mainCam.GetComponent<CameraFollow>().toggleRootView();
    }

    public void setRootView(bool isRootView)
    {
        mainCam.GetComponent<CameraFollow>().setRootView(isRootView);
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
            player.resourcesInventory[ammoType] = Database.Instance.PLAYER_CAPACITY[Database.Instance.PLAYER_CAPACITY_LVL];
        }
        else
        {
            if (player.resourcesInventory.Count < Database.Instance.PLAYER_INVENTORY[Database.Instance.PLAYER_INVENTORY_LVL]) //Ha de ser del nivell de la millora de la database.player_inventory_level
            {
                player.resourcesInventory.Add(ammoType, Database.Instance.PLAYER_CAPACITY[Database.Instance.PLAYER_CAPACITY_LVL]); //Ha de ser del nivell de la millora de database.player_capacity
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
                return Database.Instance.DAY1_WAVES;
                
            case 2:
                return Database.Instance.DAY2_WAVES;

            case 3:
                return Database.Instance.DAY3_WAVES;

            case 4:
                return Database.Instance.DAY4_WAVES;

            case 5:
                return Database.Instance.DAY5_WAVES;

            case 6:
                return Database.Instance.DAY6_WAVES;

            case 7:
                return Database.Instance.DAY7_WAVES;

            case 8:
                return Database.Instance.DAY8_WAVES;

            case 9:
                return Database.Instance.DAY9_WAVES;

            case 10:
                return Database.Instance.DAY10_WAVES;

            case 11:
                return Database.Instance.DAY11_WAVES;

            case 12:
                return Database.Instance.DAY12_WAVES;

            case 13:
                return Database.Instance.DAY13_WAVES;

            case 14:
                return Database.Instance.DAY14_WAVES;

            case 15:
                return Database.Instance.DAY15_WAVES;

            case 16:
                return Database.Instance.DAY16_WAVES;

            case 17:
                return Database.Instance.DAY17_WAVES;

            case 18:
                return Database.Instance.DAY18_WAVES;

            case 19:
                return Database.Instance.DAY19_WAVES;

            case 20:
                return Database.Instance.DAY20_WAVES;

            case 21:
                return Database.Instance.DAY21_WAVES;

            case 22:
                return Database.Instance.DAY22_WAVES;

            case 23:
                return Database.Instance.DAY23_WAVES;

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
                chestLevel = Database.Instance.MACHINE_SEED_CHEST_LVL;
                capacityLevel = Database.Instance.MACHINE_SEED_CAPACITY_LVL;
                damageLevel = Database.Instance.MACHINE_SEED_DAMAGE_LVL;
                speedLevel = Database.Instance.MACHINE_SEED_SPEED_LVL;

                turretInfo.Add("capacity", Database.Instance.MACHINE_SEED_CAPACITY[capacityLevel]);
                turretInfo.Add("chest", Database.Instance.MACHINE_SEED_CHEST[chestLevel]);
                turretInfo.Add("damage", (int)Database.Instance.MACHINE_SEED_DAMAGE[damageLevel]);
                turretInfo.Add("speed", Database.Instance.MACHINE_SEED_SPEED[speedLevel]);
                turretInfo.Add("damageLevel", damageLevel);
                turretInfo.Add("speedLevel", speedLevel);
                turretInfo.Add("chestLevel", chestLevel);
                turretInfo.Add("capacityLevel", capacityLevel);

                return turretInfo;
            case "RESIN_SPIT":
                chestLevel = Database.Instance.RESIN_SPIT_CHEST_LVL;
                capacityLevel = Database.Instance.RESIN_SPIT_CAPACITY_LVL;
                damageLevel = Database.Instance.RESIN_SPIT_DAMAGE_LVL;
                speedLevel = Database.Instance.RESIN_SPIT_SPEED_LVL;
                sticknessLevel = Database.Instance.RESIN_SPIT_STICKNESS_LVL;


                turretInfo.Add("capacity", Database.Instance.RESIN_SPIT_CAPACITY[capacityLevel]);
                turretInfo.Add("chest", Database.Instance.RESIN_SPIT_CHEST[chestLevel]);
                turretInfo.Add("damage", Database.Instance.RESIN_SPIT_DAMAGE[damageLevel]);
                turretInfo.Add("speed", Database.Instance.RESIN_SPIT_SPEED[speedLevel]);
                turretInfo.Add("stick", Database.Instance.RESIN_SPIT_STICKNESS[sticknessLevel]);
                turretInfo.Add("chestLevel", chestLevel);
                turretInfo.Add("capacityLevel", capacityLevel);
                turretInfo.Add("damageLevel", damageLevel);
                turretInfo.Add("speedLevel", speedLevel);
                turretInfo.Add("sticknessLevel", sticknessLevel);
                return turretInfo;
            case "S_SEEDNIPER":
                chestLevel = Database.Instance.S_SEEDNIPER_CHEST_LVL;
                capacityLevel = Database.Instance.S_SEEDNIPER_CAPACITY_LVL;
                damageLevel = Database.Instance.S_SEEDNIPER_DAMAGE_LVL;
                ricochetLevel = Database.Instance.S_SEEDNIPER_RICOCHET_LVL;
                speedLevel = Database.Instance.S_SEEDNIPER_SPEED_LVL;

                turretInfo.Add("capacity", Database.Instance.S_SEEDNIPER_CAPACITY[capacityLevel]);
                turretInfo.Add("chest", Database.Instance.S_SEEDNIPER_CHEST[chestLevel]);
                turretInfo.Add("damage", Database.Instance.S_SEEDNIPER_DAMAGE[damageLevel]);
                turretInfo.Add("ricochet", Database.Instance.S_SEEDNIPER_RICOCHET[ricochetLevel]);
                turretInfo.Add("speed", Database.Instance.S_SEEDNIPER_SPEED[speedLevel]);

                turretInfo.Add("chestLevel", chestLevel);
                turretInfo.Add("capacityLevel", capacityLevel);
                turretInfo.Add("damageLevel", damageLevel);
                turretInfo.Add("ricochetLevel", ricochetLevel);
                turretInfo.Add("speedLevel", speedLevel);
                return turretInfo;
            case "PINECONE_LAUNCHER":
                chestLevel = Database.Instance.PINECONE_LAUNCHER_CHEST_LVL;
                capacityLevel = Database.Instance.PINECONE_LAUNCHER_CAPACITY_LVL;
                areaLevel = Database.Instance.PINECONE_LAUNCHER_AREA_LVL;
                clusterLevel = Database.Instance.PINECONE_LAUNCHER_CLUSTER_LVL;
                damageStunLevel = Database.Instance.PINECONE_LAUNCHER_DAMAGE_STUN_LVL;
                damageLevel = Database.Instance.PINECONE_LAUNCHER_DAMAGE_LVL;
                rangeLevel = Database.Instance.PINECONE_LAUNCHER_RANGE_LVL;
                speedLevel = Database.Instance.PINECONE_LAUNCHER_SPEED_LVL;

                turretInfo.Add("capacity", Database.Instance.PINECONE_LAUNCHER_CAPACITY[capacityLevel]);
                turretInfo.Add("chest", Database.Instance.PINECONE_LAUNCHER_CHEST[chestLevel]);
                turretInfo.Add("area", Database.Instance.PINECONE_LAUNCHER_AREA[areaLevel]);
                turretInfo.Add("cluster", Database.Instance.PINECONE_LAUNCHER_CLUSTER[clusterLevel]);
                turretInfo.Add("damage", Database.Instance.PINECONE_LAUNCHER_DAMAGE[damageLevel]);
                turretInfo.Add("stun", Database.Instance.PINECONE_LAUNCHER_DAMAGE_STUN[damageStunLevel]);
                turretInfo.Add("range", Database.Instance.PINECONE_LAUNCHER_RANGE[rangeLevel]); 
                turretInfo.Add("speed", Database.Instance.PINECONE_LAUNCHER_SPEED[speedLevel]);

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
                chestLevel = Database.Instance.NUT_ROLL_CHEST_LVL;
                capacityLevel = Database.Instance.NUT_ROLL_CAPACITY_LVL;
                damageLevel = Database.Instance.NUT_ROLL_DAMAGE_LVL;
                extraLevel = Database.Instance.NUT_ROLL_EXTRA_LVL;
                hitsLevel = Database.Instance.NUT_ROLL_HITS_LVL;
                speedLevel = Database.Instance.NUT_ROLL_SPEED_LVL;

                turretInfo.Add("capacity", Database.Instance.NUT_ROLL_CAPACITY[capacityLevel]);
                turretInfo.Add("chest", Database.Instance.NUT_ROLL_CHEST[chestLevel]);
                turretInfo.Add("damage", Database.Instance.NUT_ROLL_DAMAGE[damageLevel]);
                turretInfo.Add("extra", Database.Instance.NUT_ROLL_EXTRA[extraLevel]);
                turretInfo.Add("hits", Database.Instance.NUT_ROLL_HITS[hitsLevel]);
                turretInfo.Add("speed", Database.Instance.NUT_ROLL_SPEED[speedLevel]);

                turretInfo.Add("chestLevel", chestLevel);
                turretInfo.Add("capacityLevel", capacityLevel);
                turretInfo.Add("damageLevel", damageLevel);
                turretInfo.Add("extraLevel", extraLevel);
                turretInfo.Add("hitsLevel", hitsLevel);
                turretInfo.Add("speedLevel", speedLevel);
                return turretInfo;
            case "PORCUTHROW":
                chestLevel = Database.Instance.PORCUTHROW_CHEST_LVL;
                capacityLevel = Database.Instance.PORCUTHROW_CAPACITY_LVL;
                piercingLevel = Database.Instance.PORCUTHROW_PIERCING_LVL;
                projectilesLevel = Database.Instance.PORCUTHROW_PROJECTILES_LVL;
                speedLevel = Database.Instance.PORCUTHROW_SPEED_LVL;

                turretInfo.Add("capacity", Database.Instance.PORCUTHROW_CAPACITY[capacityLevel]);
                turretInfo.Add("chest", Database.Instance.PORCUTHROW_CHEST[chestLevel]);
                turretInfo.Add("piercing", Database.Instance.PORCUTHROW_PIERCING[piercingLevel]);
                turretInfo.Add("projectiles", Database.Instance.PORCUTHROW_PROJECTILES[projectilesLevel]);
                turretInfo.Add("speed", Database.Instance.PORCUTHROW_SPEED[speedLevel]);

                turretInfo.Add("chestLevel", chestLevel);
                turretInfo.Add("capacityLevel", capacityLevel);
                turretInfo.Add("piercingLevel", piercingLevel);
                turretInfo.Add("projectilesLevel", projectilesLevel);
                turretInfo.Add("speedLevel", speedLevel);
                return turretInfo;
            case "ELECTRIC_POTATO":
                chestLevel = Database.Instance.ELECTRIC_POTATO_CHEST_LVL;
                capacityLevel = Database.Instance.ELECTRIC_POTATO_CAPACITY_LVL;
                damageLevel = Database.Instance.ELECTRIC_POTATO_DAMAGE_LVL;
                rayLevel = Database.Instance.ELECTRIC_POTATO_RAY_LVL;
                speedLevel = Database.Instance.ELECTRIC_POTATO_SPEED_LVL;
                stunLevel = Database.Instance.ELECTRIC_POTATO_STUN_LVL;

                turretInfo.Add("capacity", Database.Instance.ELECTRIC_POTATO_CAPACITY[capacityLevel]);
                turretInfo.Add("chest", Database.Instance.ELECTRIC_POTATO_CHEST[chestLevel]);
                turretInfo.Add("damage", Database.Instance.ELECTRIC_POTATO_DAMAGE[damageLevel]);
                turretInfo.Add("ray", Database.Instance.ELECTRIC_POTATO_RAY[rayLevel]);
                turretInfo.Add("speed", Database.Instance.ELECTRIC_POTATO_SPEED[speedLevel]);
                turretInfo.Add("stun", Database.Instance.ELECTRIC_POTATO_STUN[stunLevel]);

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
            currentDay++;

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

            //change background

            //change music

            //create new floor if its day X
            

            //Start day after 60s
            Invoke("changeDayState", 60);
        }
    }

    private void createNewFloor()
    {

    }
}
