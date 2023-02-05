using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]
public class TurretEditor
{
    public string turretId;
    public GameObject turretPrefab;
}

[System.SerializableAttribute]
public class AmmoImage
{
    public Sprite image;
    public string ammoType;
}

[DefaultExecutionOrder(0)]
public class GameManager : MonoBehaviour
{
    public Camera mainCam;
    public int unlockedFloors = 3;
    public int fertilizer = 0;
    public bool alreadyInteracted = false;
    public float interactionCooldown = 0;

    private PlayerController player;
    public InfoUpdater infoUpdater;
    public List<Transform> enemyGroundWaypoints;
    public List<Transform> enemyAirWaypoints;
    public int playerHP;
    public List<EnemySpawn> enemySpawns;
    public List<AmmoImage> ammoImages;
    public List<GameObject> floors;
    public GameObject topFloor;
    public GameObject bottomFloor;
    public GameObject treetopForeground;
    public GameObject rootHidder;
    public GameObject hud;
    public Narrative narrative;
    public Narrative unlockFloorNarrative;
    public Narrative initialAnim;

    public AudioSource introDay;
    public AudioSource loopDay;
    public AudioSource loopNight;
    public AudioSource backgroundSoundsNight;
    public AudioSource mainMenuSound;

    public AudioSource backgroundSoundsDay;
    public AudioSource changeSound;

    [SerializeField]
    public List<TurretEditor> turrets;

    private List<GameObject> floorList = new List<GameObject>();

    private Dictionary<string, GameObject> placedTurrets = new Dictionary<string, GameObject>();
    public bool isDay = true;
    public List<GameObject> allEnemies = new List<GameObject>();
    public NPC npcToAppear = new NPC(0, "", "", "");
    public int floorColorIndex = 0;

    private int currentDay = 0;
    private int currentFloor = 0;
    private bool playerInMenu = false;
    private bool dayNightAnimationPlaying = false;
    private int turretAutoincremental = 0;
    private bool isFirstTime = true;

    private bool gamePaused = false;

    #region Constants

    public static string ANT_ID = "ant";
    public static string FLEA_ID = "flea";
    public static string BEETLE_ID = "beetle";
    public static string FLY_ID = "fly";
    public static string WASP_ID = "wasp";

    #endregion Constants

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

    #endregion Singleton

    private void Start()
    {
        //Play intro and when finished play loopDay
        player = FindObjectOfType<PlayerController>();
        player.updateTurretInventoryNumberUI();
        player.updateInventorySlots();

        // List
        floorList.Add(GameObject.Find("BOTTOM"));
        floorList.Add(GameObject.Find("Blue_Floor"));
        floorList.Add(GameObject.Find("TOP"));
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

    public bool getDayNightAnimationPlaying()
    {
        return dayNightAnimationPlaying;
    }

    public void setDayNightAnimationPlaying(bool state)
    {
        dayNightAnimationPlaying = state;
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

    #endregion getters & setters

    public void toggleMapView()
    {
        mainCam.GetComponent<CameraFollow>().toggleGeneralView();
    }

    public void setVisibilityInventoryUI(bool visible)
    {
        player.inventoryContainer.SetActive(visible);
        player.UI.SetActive(visible);
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
        setMenuState(false);
        player.interactionSymbolE.SetActive(false);
    }

    public void hidePlacementMenuUI()
    {
        player.placementMenu.SetActive(false);
        setMenuState(false);
    }

    public void cancelSound()
    {
        player.audioSources[player.AUDIO_CANCEL].clip = player.audios[player.AUDIO_CANCEL];
        player.audioSources[player.AUDIO_CANCEL].Play();
    }

    public void interactSound()
    {
        player.audioSources[player.AUDIO_INTERACT].clip = player.audios[player.AUDIO_INTERACT];
        player.audioSources[player.AUDIO_INTERACT].Play();
    }

    private void Update()
    {
        if (!alreadyInteracted)
        {
            player.liftDelayCircle.gameObject.SetActive(false);
        }
        else
        {
            player.liftDelayCircle.gameObject.SetActive(true);
            player.liftDelayCircle.fillAmount -= Time.deltaTime;
        }
    }

    public bool pickUpAmmo(string ammoType)
    {
        switch (Database.Instance.PLAYER_INVENTORY_LVL)
        {
            case 0:
                //Only first slot avaliable
                if (player.ammoSlot1.hasAmmo)
                {
                    //Cant add more ammo
                    player.updateInventorySlots();
                    return false;
                }
                else
                {
                    player.ammoSlot1.hasAmmo = true;
                    player.ammoSlot1.currentAmmoType = ammoType;
                    player.ammoSlot1.currentAmount = Database.Instance.PLAYER_CAPACITY_LVL + 1;
                    player.ammoSlot1.ammoImage = getAmmoImage(ammoType);
                    player.updateInventorySlots();
                    return true;
                }

            case 1:
                if (player.ammoSlot1.hasAmmo)
                {
                    if (player.ammoSlot2.hasAmmo)
                    {
                        //Cant add more ammo
                        player.updateInventorySlots();
                        return false;
                    }
                    else
                    {
                        player.ammoSlot2.hasAmmo = true;
                        player.ammoSlot2.currentAmmoType = ammoType;
                        player.ammoSlot2.currentAmount = Database.Instance.PLAYER_CAPACITY_LVL + 1;
                        player.ammoSlot2.ammoImage = getAmmoImage(ammoType);
                        player.updateInventorySlots();
                        return true;
                    }
                }
                else
                {
                    player.ammoSlot1.hasAmmo = true;
                    player.ammoSlot1.currentAmmoType = ammoType;
                    player.ammoSlot1.currentAmount = Database.Instance.PLAYER_CAPACITY_LVL + 1;
                    player.ammoSlot1.ammoImage = getAmmoImage(ammoType);
                    player.updateInventorySlots();
                    return true;
                }

            case 2:
                if (player.ammoSlot1.hasAmmo)
                {
                    if (player.ammoSlot2.hasAmmo)
                    {
                        if (player.ammoSlot3.hasAmmo)
                        {
                            //Cant add more ammo
                            player.updateInventorySlots();
                            return false;
                        }
                        else
                        {
                            player.ammoSlot3.hasAmmo = true;
                            player.ammoSlot3.currentAmmoType = ammoType;
                            player.ammoSlot3.currentAmount = Database.Instance.PLAYER_CAPACITY_LVL + 1;
                            player.ammoSlot3.ammoImage = getAmmoImage(ammoType);
                            player.updateInventorySlots();
                            return true;
                        }
                    }
                    else
                    {
                        player.ammoSlot2.hasAmmo = true;
                        player.ammoSlot2.currentAmmoType = ammoType;
                        player.ammoSlot2.currentAmount = Database.Instance.PLAYER_CAPACITY_LVL + 1;
                        player.ammoSlot2.ammoImage = getAmmoImage(ammoType);
                        player.updateInventorySlots();
                        return true;
                    }
                }
                else
                {
                    player.ammoSlot1.hasAmmo = true;
                    player.ammoSlot1.currentAmmoType = ammoType;
                    player.ammoSlot1.currentAmount = Database.Instance.PLAYER_CAPACITY_LVL + 1;
                    player.ammoSlot1.ammoImage = getAmmoImage(ammoType);
                    player.updateInventorySlots();
                    return true;
                }

            case 3:
                if (player.ammoSlot1.hasAmmo)
                {
                    if (player.ammoSlot2.hasAmmo)
                    {
                        if (player.ammoSlot3.hasAmmo)
                        {
                            if (player.ammoSlot4.hasAmmo)
                            {
                                //Cant add more ammo
                                player.updateInventorySlots();
                                return false;
                            }
                            else
                            {
                                player.ammoSlot4.hasAmmo = true;
                                player.ammoSlot4.currentAmmoType = ammoType;
                                player.ammoSlot4.currentAmount = Database.Instance.PLAYER_CAPACITY_LVL + 1;
                                player.ammoSlot4.ammoImage = getAmmoImage(ammoType);
                                player.updateInventorySlots();
                                return true;
                            }
                        }
                        else
                        {
                            player.ammoSlot3.hasAmmo = true;
                            player.ammoSlot3.currentAmmoType = ammoType;
                            player.ammoSlot3.currentAmount = Database.Instance.PLAYER_CAPACITY_LVL + 1;
                            player.ammoSlot3.ammoImage = getAmmoImage(ammoType);
                            player.updateInventorySlots();
                            return true;
                        }
                    }
                    else
                    {
                        player.ammoSlot2.hasAmmo = true;
                        player.ammoSlot2.currentAmmoType = ammoType;
                        player.ammoSlot2.currentAmount = Database.Instance.PLAYER_CAPACITY_LVL + 1;
                        player.ammoSlot2.ammoImage = getAmmoImage(ammoType);
                        player.updateInventorySlots();
                        return true;
                    }
                }
                else
                {
                    player.ammoSlot1.hasAmmo = true;
                    player.ammoSlot1.currentAmmoType = ammoType;
                    player.ammoSlot1.currentAmount = Database.Instance.PLAYER_CAPACITY_LVL + 1;
                    player.ammoSlot1.ammoImage = getAmmoImage(ammoType);
                    player.updateInventorySlots();
                    return true;
                }
            default:
                return false;
        }
    }

    public void deleteAmmo()
    {
        switch (player.currentSlot)
        {
            case 1:
                if (player.ammoSlot1.hasAmmo)
                {
                    interactSound();
                }
                else
                {
                    cancelSound();
                }

                player.ammoSlot1.currentAmount -= 1;

                if (player.ammoSlot1.currentAmount <= 0)
                {
                    player.ammoSlot1.hasAmmo = false;
                    player.ammoSlot1.currentAmmoType = "";
                    player.ammoSlot1.ammoImage = null;
                }
                break;

            case 2:
                if (player.ammoSlot2.hasAmmo)
                {
                    interactSound();
                }
                else
                {
                    cancelSound();
                }

                player.ammoSlot2.currentAmount -= 1;
                if (player.ammoSlot2.currentAmount <= 0)
                {
                    player.ammoSlot2.hasAmmo = false;
                    player.ammoSlot2.currentAmmoType = "";
                    player.ammoSlot2.ammoImage = null;
                }
                break;

            case 3:
                if (player.ammoSlot3.hasAmmo)
                {
                    interactSound();
                }
                else
                {
                    cancelSound();
                }
                player.ammoSlot3.currentAmount -= 1;
                if (player.ammoSlot3.currentAmount <= 0)
                {
                    player.ammoSlot3.hasAmmo = false;
                    player.ammoSlot3.currentAmmoType = "";
                    player.ammoSlot3.ammoImage = null;
                }
                break;

            case 4:
                if (player.ammoSlot4.hasAmmo)
                {
                    interactSound();
                }
                else
                {
                    cancelSound();
                }
                player.ammoSlot4.currentAmount -= 1;

                if (player.ammoSlot1.currentAmount <= 0)
                {
                    player.ammoSlot4.hasAmmo = false;
                    player.ammoSlot4.currentAmmoType = "";
                    player.ammoSlot4.ammoImage = null;
                }
                break;

            default:
                break;
        }

        player.updateInventorySlots();
    }

    public void deleteAmmoAmount(int amount, string ammoType)
    {
        if (player.ammoSlot1.currentAmmoType.Equals(ammoType) && player.ammoSlot1.currentAmount - 1 >= 0)
        {
            player.ammoSlot1.currentAmount -= 1;
        }

        if (player.ammoSlot2.currentAmmoType.Equals(ammoType) && player.ammoSlot2.currentAmount - 1 >= 0)
        {
            player.ammoSlot2.currentAmount -= 1;
        }
        else if (player.ammoSlot3.currentAmmoType.Equals(ammoType) && player.ammoSlot3.currentAmount - 1 >= 0)
        {
            player.ammoSlot3.currentAmount -= 1;
        }
        else if (player.ammoSlot4.currentAmmoType.Equals(ammoType) && player.ammoSlot4.currentAmount - 1 >= 0)
        {
            player.ammoSlot4.currentAmount -= 1;
        }

        player.updateInventorySlots();
    }

    public void playLiftSound()
    {
        player.audioSources[player.AUDIO_FLOOR_CHANGE].clip = player.audios[player.AUDIO_FLOOR_CHANGE];
        player.audioSources[player.AUDIO_FLOOR_CHANGE].Play();
    }

    public Sprite getAmmoImage(string ammoType)
    {
        AmmoImage ai = null;
        foreach (var ammoImage in ammoImages)
        {
            if (ammoImage.ammoType.Equals(ammoType))
            {
                ai = ammoImage;
                break;
            }
        }
        return ai.image;
    }

    public void placeAmmo(TurretsFather turret)
    {
        //Somehow we need to add the ammotype to the turret if the player has it
        string ammoTypeCurrentSlot = "";
        switch (player.currentSlot)
        {
            case 1:
                ammoTypeCurrentSlot = player.ammoSlot1.currentAmmoType;
                break;

            case 2:
                ammoTypeCurrentSlot = player.ammoSlot2.currentAmmoType;
                break;

            case 3:
                ammoTypeCurrentSlot = player.ammoSlot3.currentAmmoType;
                break;

            case 4:
                ammoTypeCurrentSlot = player.ammoSlot4.currentAmmoType;
                break;
        }

        if (turret.ammoType.Equals(ammoTypeCurrentSlot))
        {
            if (turret.GiveAmmo())
            {
                player.audioSources[player.AUDIO_TURRET_PLACE].clip = player.audios[player.AUDIO_TURRET_PLACE];
                player.audioSources[player.AUDIO_TURRET_PLACE].Play();
                deleteAmmo();
            }
            else
            {
                player.audioSources[player.AUDIO_CANCEL].clip = player.audios[player.AUDIO_CANCEL];
                player.audioSources[player.AUDIO_CANCEL].Play();
            }
        }
        else
        {
            player.audioSources[player.AUDIO_CANCEL].clip = player.audios[player.AUDIO_CANCEL];
            player.audioSources[player.AUDIO_CANCEL].Play();
        }
    }

    public List<Transform> getWaypoints(string type)
    {
        List<Transform> waypoints = null;
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
        int durationResinLevel;
        int lengthResinLevel;

        Dictionary<string, float> turretInfo = new Dictionary<string, float>();
        switch (turretId)
        {
            case "MACHINE_SEED":
                chestLevel = Database.Instance.MACHINE_SEED_CHEST_LVL;
                capacityLevel = Database.Instance.MACHINE_SEED_CAPACITY_LVL;
                damageLevel = Database.Instance.MACHINE_SEED_DAMAGE_LVL;
                speedLevel = Database.Instance.MACHINE_SEED_SPEED_LVL;

                if (capacityLevel != 0) turretInfo.Add("capacity", Database.Instance.MACHINE_SEED_CAPACITY[capacityLevel - 1]);
                if (chestLevel != 0) turretInfo.Add("chest", Database.Instance.MACHINE_SEED_CHEST[chestLevel - 1]);
                if (damageLevel != 0) turretInfo.Add("damage", (int)Database.Instance.MACHINE_SEED_DAMAGE[damageLevel - 1]);
                if (speedLevel != 0) turretInfo.Add("speed", Database.Instance.MACHINE_SEED_SPEED[speedLevel - 1]);

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
                durationResinLevel = Database.Instance.RESIN_SPIT_DURATION_LVL;
                lengthResinLevel = Database.Instance.RESIN_SPIT_LONG_LVL;

                if (capacityLevel != 0) turretInfo.Add("capacity", Database.Instance.RESIN_SPIT_CAPACITY[capacityLevel - 1]);
                if (chestLevel != 0) turretInfo.Add("chest", Database.Instance.RESIN_SPIT_CHEST[chestLevel - 1]);
                if (damageLevel != 0) turretInfo.Add("damage", Database.Instance.RESIN_SPIT_DAMAGE[damageLevel - 1]);
                if (speedLevel != 0) turretInfo.Add("speed", Database.Instance.RESIN_SPIT_SPEED[speedLevel - 1]);
                if (sticknessLevel != 0) turretInfo.Add("stick", Database.Instance.RESIN_SPIT_STICKNESS[sticknessLevel - 1]);
                if (durationResinLevel != 0) turretInfo.Add("duration", Database.Instance.RESIN_SPIT_DURATION[durationResinLevel - 1]);
                if (lengthResinLevel != 0) turretInfo.Add("length", Database.Instance.RESIN_SPIT_LONG[lengthResinLevel - 1]);

                turretInfo.Add("chestLevel", chestLevel);
                turretInfo.Add("capacityLevel", capacityLevel);
                turretInfo.Add("damageLevel", damageLevel);
                turretInfo.Add("speedLevel", speedLevel);
                turretInfo.Add("sticknessLevel", sticknessLevel);
                turretInfo.Add("durationResinLevel", durationResinLevel);
                turretInfo.Add("lengthResinLevel", lengthResinLevel);
                return turretInfo;

            case "S_SEEDNIPER":
                chestLevel = Database.Instance.S_SEEDNIPER_CHEST_LVL;
                capacityLevel = Database.Instance.S_SEEDNIPER_CAPACITY_LVL;
                damageLevel = Database.Instance.S_SEEDNIPER_DAMAGE_LVL;
                ricochetLevel = Database.Instance.S_SEEDNIPER_RICOCHET_LVL;
                speedLevel = Database.Instance.S_SEEDNIPER_SPEED_LVL;

                if (capacityLevel != 0) turretInfo.Add("capacity", Database.Instance.S_SEEDNIPER_CAPACITY[capacityLevel - 1]);
                if (chestLevel != 0) turretInfo.Add("chest", Database.Instance.S_SEEDNIPER_CHEST[chestLevel - 1]);
                if (damageLevel != 0) turretInfo.Add("damage", Database.Instance.S_SEEDNIPER_DAMAGE[damageLevel - 1]);
                if (ricochetLevel != 0) turretInfo.Add("ricochet", Database.Instance.S_SEEDNIPER_RICOCHET[ricochetLevel - 1]);
                if (speedLevel != 0) turretInfo.Add("speed", Database.Instance.S_SEEDNIPER_SPEED[speedLevel - 1]);

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

                if (capacityLevel != 0) turretInfo.Add("capacity", Database.Instance.PINECONE_LAUNCHER_CAPACITY[capacityLevel - 1]);
                if (chestLevel != 0) turretInfo.Add("chest", Database.Instance.PINECONE_LAUNCHER_CHEST[chestLevel - 1]);
                if (areaLevel != 0) turretInfo.Add("area", Database.Instance.PINECONE_LAUNCHER_AREA[areaLevel - 1]);
                if (clusterLevel != 0) turretInfo.Add("cluster", Database.Instance.PINECONE_LAUNCHER_CLUSTER[clusterLevel - 1]);
                if (damageLevel != 0) turretInfo.Add("damage", Database.Instance.PINECONE_LAUNCHER_DAMAGE[damageLevel - 1]);
                if (damageStunLevel != 0) turretInfo.Add("stun", Database.Instance.PINECONE_LAUNCHER_DAMAGE_STUN[damageStunLevel - 1]);
                if (rangeLevel != 0) turretInfo.Add("range", Database.Instance.PINECONE_LAUNCHER_RANGE[rangeLevel - 1]);
                if (speedLevel != 0) turretInfo.Add("speed", Database.Instance.PINECONE_LAUNCHER_SPEED[speedLevel - 1]);

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

                if (capacityLevel != 0) turretInfo.Add("capacity", Database.Instance.NUT_ROLL_CAPACITY[capacityLevel - 1]);
                if (chestLevel != 0) turretInfo.Add("chest", Database.Instance.NUT_ROLL_CHEST[chestLevel - 1]);
                if (damageLevel != 0) turretInfo.Add("damage", Database.Instance.NUT_ROLL_DAMAGE[damageLevel - 1]);
                if (extraLevel != 0) turretInfo.Add("extra", Database.Instance.NUT_ROLL_EXTRA[extraLevel - 1]);
                if (hitsLevel != 0) turretInfo.Add("hits", Database.Instance.NUT_ROLL_HITS[hitsLevel - 1]);
                if (speedLevel != 0) turretInfo.Add("speed", Database.Instance.NUT_ROLL_SPEED[speedLevel - 1]);

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

                if (capacityLevel != 0) turretInfo.Add("capacity", Database.Instance.PORCUTHROW_CAPACITY[capacityLevel - 1]);
                if (chestLevel != 0) turretInfo.Add("chest", Database.Instance.PORCUTHROW_CHEST[chestLevel - 1]);
                if (piercingLevel != 0) turretInfo.Add("piercing", Database.Instance.PORCUTHROW_PIERCING[piercingLevel - 1]);
                if (projectilesLevel != 0) turretInfo.Add("projectiles", Database.Instance.PORCUTHROW_PROJECTILES[projectilesLevel - 1]);
                if (speedLevel != 0) turretInfo.Add("speed", Database.Instance.PORCUTHROW_SPEED[speedLevel - 1]);

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

                if (capacityLevel != 0) turretInfo.Add("capacity", Database.Instance.ELECTRIC_POTATO_CAPACITY[capacityLevel - 1]);
                if (chestLevel != 0) turretInfo.Add("chest", Database.Instance.ELECTRIC_POTATO_CHEST[chestLevel - 1]);
                if (damageLevel != 0) turretInfo.Add("damage", Database.Instance.ELECTRIC_POTATO_DAMAGE[damageLevel - 1]);
                if (rayLevel != 0) turretInfo.Add("ray", Database.Instance.ELECTRIC_POTATO_RAY[rayLevel - 1]);
                if (speedLevel != 0) turretInfo.Add("speed", Database.Instance.ELECTRIC_POTATO_SPEED[speedLevel - 1]);
                if (stunLevel != 0) turretInfo.Add("stun", Database.Instance.ELECTRIC_POTATO_STUN[stunLevel - 1]);

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
        //pause player movement
        setDayNightAnimationPlaying(true);
        infoUpdater.ChangeDay();
        player.updateTurretPlacementMenu();
        isDay = !isDay;
        if (isDay)
        {
            //show animation
            mainCam.GetComponent<CameraFollow>().blurCamera();
            this.hud.transform.Find("Background").gameObject.SetActive(true);
            this.hud.transform.Find("Background").GetComponent<Animator>().Play("backgroundFadeIn");
            Invoke("playDayNightAnimation", 0.75f);
            Invoke("removeDayNightAnimation", 5);

            currentDay++;

            Invoke("activateEnemySpawns", 6);
        }
        else
        {
            //show animation
            mainCam.GetComponent<CameraFollow>().blurCamera();
            this.hud.transform.Find("Background").gameObject.SetActive(true);
            this.hud.transform.Find("Background").GetComponent<Animator>().Play("backgroundFadeIn");
            Invoke("playDayNightAnimation", 0.75f);
            Invoke("removeDayNightAnimation", 5);

            //deactivate spawns
            foreach (EnemySpawn spawn in enemySpawns)
            {
                spawn.deactivateSpawn();
            }

            //change background

            //create new floor if its day X
            bool hasUnlockedFloor = false;
            for (int i = 0; i < Database.Instance.unlockFloorDays.Length; i++)
            {
                if (currentDay == Database.Instance.unlockFloorDays[i])
                {
                    hasUnlockedFloor = true;
                    Invoke("createNewFloor", 4.5f);
                }
            }

            bool hasUnlockedNpc = false;
            //unloc NPC & ammo if its day X
            foreach (NPC npc in Database.Instance.unlockNpcDays)
            {
                if (npc.day == this.currentDay)
                {
                    hasUnlockedNpc = true;
                    this.npcToAppear = npc;
                    Invoke("unlockNPC", 4.5f);
                }
            }

            //Music
            fadeOutDay();
            if (!isFirstTime)
            {
                Invoke("playChangeSound", 1.5f);
            }
            else
            {
                isFirstTime = false;
            }

            Invoke("fadeInNight", 1f);
            Invoke("fadeOutNight", 61.5f);
            Invoke("playChangeSound", 63);
            Invoke("playIntroDay", 65);

            loopNight.Play();

            if (!hasUnlockedNpc && !hasUnlockedFloor && this.currentDay != 1)
            {
                //Start day after 60s
                Invoke("changeDayState", 15);//60
            }

            if (this.currentDay == 1) Invoke("callStartIntroScene3", 5);
        }
    }

    private void callStartIntroScene3()
    {
        this.initialAnim.startIntroScene3();
    }

    public void activateEnemySpawns()
    {
        //activate spawns
        foreach (EnemySpawn spawn in enemySpawns)
        {
            spawn.activateSpawn();
        }
    }

    public void handleChangeState()
    {
        Invoke("changeDayState", 60);
    }

    public void playDayNightAnimation()
    {
        if (this.isDay)
        {
            this.hud.transform.Find("dayNightImage").gameObject.SetActive(true);
            this.hud.transform.Find("dayNightImage").GetComponent<Animator>().Play("goToDay");
        }
        else
        {
            this.hud.transform.Find("dayNightImage").gameObject.SetActive(true);
            this.hud.transform.Find("dayNightImage").GetComponent<Animator>().Play("goToNight");
        }
    }

    public void removeDayNightAnimation()
    {
        mainCam.GetComponent<CameraFollow>().focusCamera();
        this.hud.transform.Find("Background").GetComponent<Animator>().Play("backgroundFadeOut");
        Invoke("hideBackgroundUI", 1);
    }

    public void hideBackgroundUI()
    {
        this.hud.transform.Find("Background").gameObject.SetActive(false);
        this.hud.transform.Find("dayNightImage").gameObject.SetActive(false);
        //upause player movement
        setDayNightAnimationPlaying(false);
    }

    private void unlockNPC()
    {
        //show animation
        this.narrative.startNpcScene(this.npcToAppear);

        GameObject floor;
        if (this.npcToAppear.floor == "bottom") floor = this.bottomFloor;
        else floor = this.topFloor;

        for (int i = 0; i < floor.transform.Find("chests").childCount; i++)
        {
            if (floor.transform.Find("chests").GetChild(i).GetComponent<AmmoPicking>().ammoType == this.npcToAppear.ammoId)
            {
                floor.transform.Find("chests").GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public void placeTurret(Vector3 position, string turretId, TurretPlacholder placeHolder)
    {
        if (!placeHolder.hasTurret)
        {
            if (player.turretsInventory.TryGetValue(turretId, out int amount))
            {
                if (amount > 0)
                {
                    foreach (TurretEditor t in turrets)
                    {
                        if (t.turretId.Equals(turretId))
                        {
                            GameObject go = Instantiate(t.turretPrefab, position, Quaternion.identity);
                            go.SetActive(true);
                            //go.GetComponent<TurretsFather>().PlaceTurret();
                            placeHolder.turretPlacementId = turretAutoincremental;
                            placeHolder.hasTurret = true;
                            placeHolder.turretId = turretId;
                            placeHolder.currentTurretObject = go;
                            placedTurrets.Add(turretAutoincremental.ToString(), go);
                            player.turretsInventory[turretId] -= 1;
                            player.audioSources[player.AUDIO_TURRET_PLACE].clip = player.audios[player.AUDIO_TURRET_PLACE];
                            player.audioSources[player.AUDIO_TURRET_PLACE].Play();
                            break;
                        }
                    }
                }
                else
                {
                    if (spendFertilizer(getTurretPrice(turretId)))
                    {
                        foreach (TurretEditor t in turrets)
                        {
                            if (t.turretId.Equals(turretId))
                            {
                                GameObject go = Instantiate(t.turretPrefab, position, Quaternion.identity);
                                go.SetActive(true);
                                //go.GetComponent<TurretsFather>().PlaceTurret();
                                placeHolder.turretPlacementId = turretAutoincremental;
                                placeHolder.hasTurret = true;
                                placeHolder.turretId = turretId;
                                placeHolder.currentTurretObject = go;
                                placedTurrets.Add(turretAutoincremental.ToString(), go);
                                player.audioSources[player.AUDIO_BUY].clip = player.audios[player.AUDIO_BUY];
                                player.audioSources[player.AUDIO_BUY].Play();
                                break;
                            }
                        }
                        turretAutoincremental++;
                    }
                }
                turretAutoincremental++;
            }
            else
            {
                if (spendFertilizer(getTurretPrice(turretId)))
                {
                    foreach (TurretEditor t in turrets)
                    {
                        if (t.turretId.Equals(turretId))
                        {
                            GameObject go = Instantiate(t.turretPrefab, position, Quaternion.identity);
                            go.SetActive(true);
                            //go.GetComponent<TurretsFather>().PlaceTurret();
                            placeHolder.turretPlacementId = turretAutoincremental;
                            placeHolder.hasTurret = true;
                            placeHolder.turretId = turretId;
                            placeHolder.currentTurretObject = go;
                            placedTurrets.Add(turretAutoincremental.ToString(), go);
                            player.turretsInventory.Add(turretId, 0);
                            player.audioSources[player.AUDIO_BUY].clip = player.audios[player.AUDIO_BUY];
                            player.audioSources[player.AUDIO_BUY].Play();
                            break;
                        }
                    }
                    turretAutoincremental++;
                }
            }
        }
        player.updateTurretInventoryNumberUI();
    }

    public void pickupTurret(TurretPlacholder placeHolder)
    {
        if (placedTurrets.TryGetValue(placeHolder.turretPlacementId.ToString(), out GameObject turretGameObject))
        {
            Destroy(turretGameObject);
            placeHolder.hasTurret = false;
            placeHolder.turretPlacementId = -1;
            if (player.turretsInventory.TryGetValue(placeHolder.turretId, out int amount))
            {
                player.turretsInventory.Remove(placeHolder.turretId);
                player.turretsInventory.Add(placeHolder.turretId, amount + 1);
            }
            else
            {
                player.turretsInventory.Add(placeHolder.turretId, 1);
            }
            player.audioSources[player.AUDIO_PICK_TURRET].clip = player.audios[player.AUDIO_PICK_TURRET];
            player.audioSources[player.AUDIO_PICK_TURRET].Play();
        }
        player.updateTurretInventoryNumberUI();
    }

    public int getTurretPrice(string turretId)
    {
        switch (turretId)
        {
            case "MACHINE_SEED":
                //Database.Instance.MACHINE_SEED_PRICE
                return 250;

            case "S_SEEDNIPER":

                return 350;

            case "RESIN_SPIT":

                return 3;

            case "PINECONE_LAUNCHER":

                return 4;

            case "NUT_ROLL":

                return 5;

            case "PORCUTHROW":

                return 6;

            case "ELECTRIC_POTATO":

                return 7;

            default:

                return 0;
        }
    }

    public bool spendFertilizer(int fertilizerAmount)
    {
        if (fertilizer - fertilizerAmount >= 0)
        {
            fertilizer -= fertilizerAmount;
            return true;
        }
        else
        {
            player.audioSources[player.AUDIO_CANCEL].clip = player.audios[player.AUDIO_CANCEL];
            player.audioSources[player.AUDIO_CANCEL].Play();
            return false;
        }
    }

    public void startGame()
    {
        changeDayState();
    }

    private void createNewFloor()
    {
        floorColorIndex++;
        unlockedFloors++;
        //show animation
        this.unlockFloorNarrative.startFloorScene();

        GameObject aux = Instantiate(floors[floorColorIndex], topFloor.transform.position, Quaternion.identity);
        aux.transform.parent = GameObject.Find("Floors").transform;
        topFloor.transform.position += new Vector3(0, 2, 0);
        FloorManager floorManager = FindObjectOfType<FloorManager>();
        floorList.Insert(floorList.Count - 1, aux);

        //add ground floor waypoint
        Transform topWaypoint = enemyGroundWaypoints[enemyGroundWaypoints.Count - 1];
        enemyGroundWaypoints.RemoveAt(enemyGroundWaypoints.Count - 1);
        enemyGroundWaypoints.Add(aux.transform.Find("waypoint"));
        enemyGroundWaypoints.Add(topWaypoint);

        //add fly floor waypoint
        Transform topWaypointAir = enemyAirWaypoints[enemyAirWaypoints.Count - 1];
        enemyAirWaypoints.RemoveAt(enemyAirWaypoints.Count - 1);
        enemyAirWaypoints.Add(aux.transform.Find("waypointAir"));
        enemyAirWaypoints.Add(topWaypointAir);

        if (floorManager)
        {
            floorManager.updateDoors();
        }
        if (floorColorIndex == 4)
        {
            floorColorIndex = -1;
        }
    }

    public void playIntroDay()
    {
        introDay.Play();
        Invoke("playLoopDay", 21);
        backgroundSoundsDay.Play();
        backgroundSoundsNight.Stop();
    }

    public void playChangeSound()
    {
        changeSound.Play();
    }

    public void playLoopDay()
    {
        loopDay.Play();
        loopDay.GetComponent<Animator>().Play("SoundDay");
    }

    public void fadeOutDay()
    {
        loopDay.GetComponent<Animator>().Play("FadeOutDay");
    }

    public void fadeInDay()
    {
        loopDay.GetComponent<Animator>().Play("FadeInDay");
    }

    public void fadeOutNight()
    {
        loopNight.GetComponent<Animator>().Play("FadeOutNight");
    }

    public void fadeInNight()
    {
        backgroundSoundsDay.Stop();
        backgroundSoundsNight.Play();
        loopNight.GetComponent<Animator>().Play("FadeInNight");
    }

    public void playMenuSong()
    {
        mainMenuSound.Play();
    }

    public void UpdateTurrets()
    {
        foreach (GameObject turret in placedTurrets.Values) turret.GetComponent<TurretsFather>().UpdateDatabase();
    }

    public void UpdateDoors()
    {
        foreach (FloorDoor door in FindObjectsOfType<FloorDoor>()) door.updateCooldown();
    }

    public void UpdatePlayer()
    {
        player.UpdateDatabase();
        player.updateInventorySlots();
    }

    public List<GameObject> getAllEnemies()
    {
        return this.allEnemies;
    }

    public void playLiftAnimation()
    {
        player.liftDelayCircle.fillAmount = interactionCooldown;
    }

    public void updateFloorVisuals()
    {
        if (currentFloor != 0) floorList[currentFloor - 1].GetComponent<FloorItem>().hideFloor();
        if (currentFloor != floorList.Count - 1) floorList[currentFloor + 1].GetComponent<FloorItem>().hideFloor();
        floorList[currentFloor].GetComponent<FloorItem>().showFloor();
        if (currentFloor == floorList.Count - 1) treetopForeground.SetActive(false); else treetopForeground.SetActive(true);
        rootHidder.SetActive(false);
    }

    public void globalMapVisionUpdate()
    {
        floorList[currentFloor].GetComponent<FloorItem>().hideFloor();
        treetopForeground.SetActive(true);
        rootHidder.SetActive(true);
    }

    public void checkRoundEnded()
    {
        foreach (EnemySpawn spawn in enemySpawns)
        {
            if (!spawn.checkAllWavesCompleted() || !spawn.checkAllEnemiesDeactivated()) return;
        }
        this.changeDayState();
    }

    public int getRemainingNumEnemies()
    {
        int numTotal = 0;
        foreach (EnemySpawn spawn in this.enemySpawns)
        {
            numTotal += spawn.getNumEnemiesToFinish();
        }
        return numTotal;
    }
}