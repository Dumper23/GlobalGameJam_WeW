using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC
{
    public int day;
    public string npcId;
    public string ammoId;
    public string floor;

    public NPC(int day, string npcId, string ammoId, string floor)
    {
        this.day = day;
        this.npcId = npcId;
        this.ammoId = ammoId;
        this.floor = floor;
    }
}

[DefaultExecutionOrder(0)]
public class Database : MonoBehaviour
{
    #region Singleton

    public static Database Instance { get; private set; }

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

    #region WAVES FOR EACH DAY

    [HideInInspector]
    public List<EnemyWave> DAY1_WAVES = new List<EnemyWave>{
        new EnemyWave(12, "ant", 3, 2, 1, "walk"),
        //new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };

    [HideInInspector]
    public List<EnemyWave> DAY2_WAVES = new List<EnemyWave>{
        new EnemyWave(15, "ant", 3, 2, 1, "walk")

     
    };

    [HideInInspector]
    public List<EnemyWave> DAY3_WAVES = new List<EnemyWave>{
        new EnemyWave(20, "ant", 3, 2, 1, "walk"),
        new EnemyWave(5, "flea", 3, 2, 1, "walk"),
        //new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };

    [HideInInspector]
    public List<EnemyWave> DAY4_WAVES = new List<EnemyWave>{
        new EnemyWave(10, "ant", 1, 0, 1, "walk"),
        new EnemyWave(15, "flea", 3, 2, 1, "walk")
        //new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };

    [HideInInspector]
    public List<EnemyWave> DAY5_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(13, "flea", 1.5f, 1, 1, "walk")
        //new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };

    [HideInInspector]
    public List<EnemyWave> DAY6_WAVES = new List<EnemyWave>{
        new EnemyWave(18, "ant", 1, 1, 1, "walk"),
        new EnemyWave(10, "flea", 0.7f, 0, 1, "walk")
        //new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };

    [HideInInspector]
    public List<EnemyWave> DAY7_WAVES = new List<EnemyWave>{
        new EnemyWave(14, "ant", 2, 0, 1, "walk"),
        new EnemyWave(13, "flea", 1.5f, 0.5f, 1, "walk"),
        new EnemyWave(5, "fly", 2, 0, 1, "fly")
        //new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };

    [HideInInspector]
    public List<EnemyWave> DAY8_WAVES = new List<EnemyWave>{
        new EnemyWave(10, "ant", 1.5f, 0, 1, "walk"),
        new EnemyWave(17, "flea", 1, 4, 1, "walk"),
        new EnemyWave(8, "fly", 1, 0, 1, "fly")
        //new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };

    [HideInInspector]
    public List<EnemyWave> DAY9_WAVES = new List<EnemyWave>{
        new EnemyWave(20, "ant", 1.5f, 10, 1, "walk"),
        //new EnemyWave(20, "flea", 1, 0.5f, 1, "walk"),
        new EnemyWave(22, "fly", 1, 0, 1, "fly"),
    };

    [HideInInspector]
    public List<EnemyWave> DAY10_WAVES = new List<EnemyWave>{
        new EnemyWave(7, "ant", 1, 0, 1, "walk"),
        new EnemyWave(7, "flea", 0.5f, 12, 1, "walk"),
        new EnemyWave(25, "fly", 0.5f, 0, 1, "fly"),
    };

    [HideInInspector]
    public List<EnemyWave> DAY11_WAVES = new List<EnemyWave>{
        new EnemyWave(10, "ant", 1, 0, 1, "walk"),
        new EnemyWave(10, "flea", 1, 0.5f, 1, "walk"),
        new EnemyWave(10, "fly", 1, 0, 1, "fly"),
        new EnemyWave(1, "beetle", 1, 40, 1, "walk")
    };

    [HideInInspector]
    public List<EnemyWave> DAY12_WAVES = new List<EnemyWave>{
        new EnemyWave(12, "ant", 1, 0, 1, "walk"),
        new EnemyWave(13, "flea", 1, 0.5f, 1, "walk"),
        new EnemyWave(20, "fly", 1, 0, 1, "fly"),
    };

    [HideInInspector]
    public List<EnemyWave> DAY13_WAVES = new List<EnemyWave>{
        new EnemyWave(20, "ant", 1, 10, 1, "walk"),
        new EnemyWave(15, "flea", 1, 0.5f, 1, "walk"),
        new EnemyWave(25, "fly", 1, 20, 1, "fly"),
        new EnemyWave(1, "beetle", 1, 50, 1, "walk"),
    };

    [HideInInspector]
    public List<EnemyWave> DAY14_WAVES = new List<EnemyWave>{
        new EnemyWave(35, "fly", 1.5f, 20, 1, "fly"),
        new EnemyWave(3, "beetle", 20, 0, 1, "walk"),
    };

    [HideInInspector]
    public List<EnemyWave> DAY15_WAVES = new List<EnemyWave>{
        new EnemyWave(160, "ant", 1, 0, 1, "walk"),
        new EnemyWave(50, "flea", 1, 0.5f, 1, "walk"),
        new EnemyWave(40, "fly", 1, 0, 1, "fly"),
        new EnemyWave(6, "beetle", 1, 0, 1, "walk"),
        new EnemyWave(8, "beetle", 1, 20, 1, "walk"),
    };

    [HideInInspector]
    public List<EnemyWave> DAY16_WAVES = new List<EnemyWave>{
        new EnemyWave(165, "ant", 1, 0, 1, "walk"),
        new EnemyWave(65, "flea", 1, 0.5f, 1, "walk"),
        new EnemyWave(55, "fly", 1, 0, 1, "fly"),
        new EnemyWave(8, "beetle", 1, 0, 1, "walk"),
        new EnemyWave(12, "beetle", 1, 20, 1, "walk"),
    };

    [HideInInspector]
    public List<EnemyWave> DAY17_WAVES = new List<EnemyWave>{
        new EnemyWave(180, "ant", 1, 0, 1, "walk"),
        new EnemyWave(76, "flea", 1, 0.5f, 1, "walk"),
        new EnemyWave(80, "fly", 1, 0, 1, "fly"),
        new EnemyWave(10, "beetle", 1, 0, 1, "walk"),
        new EnemyWave(14, "beetle", 1, 20, 1, "walk"),
    };

    [HideInInspector]
    public List<EnemyWave> DAY18_WAVES = new List<EnemyWave>{
        new EnemyWave(200, "ant", 1, 0, 1, "walk"),
        new EnemyWave(90, "flea", 1, 0.5f, 1, "walk"),
        new EnemyWave(100, "fly", 1, 0, 1, "fly"),
        new EnemyWave(12, "beetle", 1, 0, 1, "walk"),
        new EnemyWave(14, "beetle", 1, 20, 1, "walk"),
    };

    [HideInInspector]
    public List<EnemyWave> DAY19_WAVES = new List<EnemyWave>{
        new EnemyWave(215, "ant", 1, 0, 1, "walk"),
        new EnemyWave(100, "flea", 1, 0.5f, 1, "walk"),
        new EnemyWave(120, "fly", 1, 0, 1, "fly"),
        new EnemyWave(12, "beetle", 1, 0, 1, "walk"),
        new EnemyWave(16, "beetle", 1, 20, 1, "walk"),
    };

    [HideInInspector]
    public List<EnemyWave> DAY20_WAVES = new List<EnemyWave>{
        new EnemyWave(235, "ant", 1, 0, 1, "walk"),
        new EnemyWave(115, "flea", 1, 0.5f, 1, "walk"),
        new EnemyWave(140, "fly", 1, 0, 1, "fly"),
        new EnemyWave(14, "beetle", 1, 0, 1, "walk"),
        new EnemyWave(16, "beetle", 1, 20, 1, "walk"),
    };

    [HideInInspector]
    public List<EnemyWave> DAY21_WAVES = new List<EnemyWave>{
        new EnemyWave(255, "ant", 1, 0, 1, "walk"),
        new EnemyWave(135, "flea", 1, 0.5f, 1, "walk"),
        new EnemyWave(160, "fly", 1, 0, 1, "fly"),
        new EnemyWave(16, "beetle", 1, 0, 1, "walk"),
        new EnemyWave(20, "beetle", 1, 20, 1, "walk"),
    };

    [HideInInspector]
    public List<EnemyWave> DAY22_WAVES = new List<EnemyWave>{
        new EnemyWave(275, "ant", 1, 0, 1, "walk"),
        new EnemyWave(145, "flea", 1, 0.5f, 1, "walk"),
        new EnemyWave(175, "fly", 1, 0, 1, "fly"),
        new EnemyWave(18, "beetle", 1, 0, 1, "walk"),
        new EnemyWave(20, "beetle", 1, 20, 1, "walk"),
    };

    [HideInInspector]
    public List<EnemyWave> DAY23_WAVES = new List<EnemyWave>{
        new EnemyWave(295, "ant", 1, 0, 1, "walk"),
        new EnemyWave(155, "flea", 1, 0.5f, 1, "walk"),
        new EnemyWave(185, "fly", 1, 0, 1, "fly"),
        new EnemyWave(18, "beetle", 1, 0, 1, "walk"),
        new EnemyWave(22, "beetle", 1, 20, 1, "walk"),
    };

    #endregion WAVES FOR EACH DAY

    #region TURRET ATTRIBUTES

    #region MACHINE_SEED

    [HideInInspector] public string MACHINE_SEED_DESCRIPTION = "Shoot a single enemy until it is eliminated";

    [HideInInspector] public int MACHINE_SEED_DAMAGE_LVL = 0;
    [HideInInspector] public string MACHINE_SEED_DAMAGE_DESCRIPTION = "Increases Turret Damage";
    [HideInInspector] public string MACHINE_SEED_DAMAGE_NAME = "More Seeds!";
    [HideInInspector] public int[] MACHINE_SEED_DAMAGE_COST = { 100, 1000, 3000 };
    [HideInInspector] public int[] MACHINE_SEED_DAMAGE = { 35, 45, 55 };

    [HideInInspector] public int MACHINE_SEED_SPEED_LVL = 0;
    [HideInInspector] public string MACHINE_SEED_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    [HideInInspector] public string MACHINE_SEED_SPEED_NAME = "Faster!";
    [HideInInspector] public int[] MACHINE_SEED_SPEED_COST = { 100, 1000, 3000 };
    [HideInInspector] public float[] MACHINE_SEED_SPEED = { 0.7f, 0.5f, 0.3f };

    [HideInInspector] public int MACHINE_SEED_CAPACITY_LVL = 0;
    [HideInInspector] public string MACHINE_SEED_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    [HideInInspector] public string MACHINE_SEED_CAPACITY_NAME = "More Magazine!";
    [HideInInspector] public int[] MACHINE_SEED_CAPACITY_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] MACHINE_SEED_CAPACITY = { 30, 40, 60 };

    [HideInInspector] public int MACHINE_SEED_CHEST_LVL = 0;
    [HideInInspector] public string MACHINE_SEED_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    [HideInInspector] public string MACHINE_SEED_CHEST_NAME_UNO = "Create Chest!";
    [HideInInspector] public string MACHINE_SEED_CHEST_DESCRIPTION = "Increases chest capacity";
    [HideInInspector] public string MACHINE_SEED_CHEST_NAME = "More Chest!";
    [HideInInspector] public int[] MACHINE_SEED_CHEST_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] MACHINE_SEED_CHEST = { 1, 2, 3 };

    #endregion MACHINE_SEED

    #region RESIN_SPIT

    [HideInInspector] public string RESIN_SPIT_DESCRIPTION = "Shoots a resin puddle that slows down the enemy as it passes through it";

    [HideInInspector] public int RESIN_SPIT_DAMAGE_LVL = 0;
    [HideInInspector] public string RESIN_SPIT_DAMAGE_DESCRIPTION = "Now the resin does a little damage per second";
    [HideInInspector] public string RESIN_SPIT_DAMAGE_NAME = "Corrosive Resin";
    [HideInInspector] public int[] RESIN_SPIT_DAMAGE_COST = { 100 };
    [HideInInspector] public int[] RESIN_SPIT_DAMAGE = { 5 };

    [HideInInspector] public int RESIN_SPIT_SPEED_LVL = 0;
    [HideInInspector] public string RESIN_SPIT_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    [HideInInspector] public string RESIN_SPIT_SPEED_NAME = "Faster!";
    [HideInInspector] public int[] RESIN_SPIT_SPEED_COST = { 100 };
    [HideInInspector] public float[] RESIN_SPIT_SPEED = { 6 };

    [HideInInspector] public int RESIN_SPIT_DURATION_LVL = 0;
    [HideInInspector] public string RESIN_SPIT_DURATION_DESCRIPTION = "Increases the duration of the resin in the tree";
    [HideInInspector] public string RESIN_SPIT_DURATION_NAME = "More Resin!";
    [HideInInspector] public int[] RESIN_SPIT_DURATION_COST = { 1000, 3000 };
    [HideInInspector] public float[] RESIN_SPIT_DURATION = { 3, 4 };

    [HideInInspector] public int RESIN_SPIT_STICKNESS_LVL = 0;
    [HideInInspector] public string RESIN_SPIT_STICKNESS_DESCRIPTION = "Increases resin slow";
    [HideInInspector] public string RESIN_SPIT_STICKNESS_NAME = "Sticky Resin";
    [HideInInspector] public int[] RESIN_SPIT_STICKNESS_COST = { 1000 };
    [HideInInspector] public float[] RESIN_SPIT_STICKNESS = { 0.6f };

    [HideInInspector] public int RESIN_SPIT_LONG_LVL = 0;
    [HideInInspector] public string RESIN_SPIT_LONG_DESCRIPTION = "Increases the length of the Puddle";
    [HideInInspector] public string RESIN_SPIT_LONG_NAME = "Size does matter";
    [HideInInspector] public int[] RESIN_SPIT_LONG_COST = { 3000 };
    [HideInInspector] public float[] RESIN_SPIT_LONG = { 1.6f };

    [HideInInspector] public int RESIN_SPIT_CAPACITY_LVL = 0;
    [HideInInspector] public string RESIN_SPIT_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    [HideInInspector] public string RESIN_SPIT_CAPACITY_NAME = "More Magazine!";
    [HideInInspector] public int[] RESIN_SPIT_CAPACITY_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] RESIN_SPIT_CAPACITY = { 15, 20, 25 };

    [HideInInspector] public int RESIN_SPIT_CHEST_LVL = 0;
    [HideInInspector] public string RESIN_SPIT_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    [HideInInspector] public string RESIN_SPIT_CHEST_NAME_UNO = "Create Chest!";
    [HideInInspector] public string RESIN_SPIT_CHEST_DESCRIPTION = "Increases chest capacity";
    [HideInInspector] public string RESIN_SPIT_CHEST_NAME = "More Chest!";
    [HideInInspector] public int[] RESIN_SPIT_CHEST_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] RESIN_SPIT_CHEST = { 1, 2, 3 };

    #endregion RESIN_SPIT

    #region S_SEEDNIPER

    [HideInInspector] public string S_SEEDNIPER_DESCRIPTION = "Fires a projectile that does a lot of damage, but has slow firerate.";

    [HideInInspector] public int S_SEEDNIPER_DAMAGE_LVL = 0;
    [HideInInspector] public string S_SEEDNIPER_DAMAGE_DESCRIPTION = "Increases Turret Damage";
    [HideInInspector] public string S_SEEDNIPER_DAMAGE_NAME = "More Damage!";
    [HideInInspector] public int[] S_SEEDNIPER_DAMAGE_COST = { 100, 1000 };
    [HideInInspector] public int[] S_SEEDNIPER_DAMAGE = { 100, 135 };

    [HideInInspector] public int S_SEEDNIPER_SPEED_LVL = 0;
    [HideInInspector] public string S_SEEDNIPER_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    [HideInInspector] public string S_SEEDNIPER_SPEED_NAME = "Faster!";
    [HideInInspector] public int[] S_SEEDNIPER_SPEED_COST = { 100, 1000, 3000 };
    [HideInInspector] public float[] S_SEEDNIPER_SPEED = { 3, 2.5f, 2 };

    [HideInInspector] public int S_SEEDNIPER_RICOCHET_LVL = 0;
    [HideInInspector] public string S_SEEDNIPER_RICOCHET_DESCRIPTION = "Bullets now ricochet off enemies";
    [HideInInspector] public string S_SEEDNIPER_RICOCHET_NAME = "Ricochet";
    [HideInInspector] public int[] S_SEEDNIPER_RICOCHET_COST = { 3000 };
    [HideInInspector] public int[] S_SEEDNIPER_RICOCHET = { 1 };

    [HideInInspector] public int S_SEEDNIPER_CAPACITY_LVL = 0;
    [HideInInspector] public string S_SEEDNIPER_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    [HideInInspector] public string S_SEEDNIPER_CAPACITY_NAME = "More Magazine!";
    [HideInInspector] public int[] S_SEEDNIPER_CAPACITY_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] S_SEEDNIPER_CAPACITY = { 20, 25, 40 };

    [HideInInspector] public int S_SEEDNIPER_CHEST_LVL = 0;
    [HideInInspector] public string S_SEEDNIPER_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    [HideInInspector] public string S_SEEDNIPER_CHEST_NAME_UNO = "Create Chest!";
    [HideInInspector] public string S_SEEDNIPER_CHEST_DESCRIPTION = "Increases chest capacity";
    [HideInInspector] public string S_SEEDNIPER_CHEST_NAME = "More Chest!";
    [HideInInspector] public int[] S_SEEDNIPER_CHEST_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] S_SEEDNIPER_CHEST = { 1, 2, 3 };

    #endregion S_SEEDNIPER

    #region PINECONE_LAUNCHER

    [HideInInspector] public string PINECONE_LAUNCHER_DESCRIPTION = "Fires a projectile that does area damage, but has slow firerate.";

    [HideInInspector] public int PINECONE_LAUNCHER_AREA_LVL = 0;
    [HideInInspector] public string PINECONE_LAUNCHER_AREA_DESCRIPTION = "Increases the area of the explosion";
    [HideInInspector] public string PINECONE_LAUNCHER_AREA_NAME = "More Boom!";
    [HideInInspector] public int[] PINECONE_LAUNCHER_AREA_COST = { 100 };
    [HideInInspector] public int[] PINECONE_LAUNCHER_AREA = { 10 };

    [HideInInspector] public int PINECONE_LAUNCHER_DAMAGE_LVL = 0;
    [HideInInspector] public string PINECONE_LAUNCHER_DAMAGE_DESCRIPTION = "Increases Turret Damage";
    [HideInInspector] public string PINECONE_LAUNCHER_DAMAGE_NAME = "More Pinecones!";
    [HideInInspector] public int[] PINECONE_LAUNCHER_DAMAGE_COST = { 1000 };
    [HideInInspector] public int[] PINECONE_LAUNCHER_DAMAGE = { 60 };

    [HideInInspector] public int PINECONE_LAUNCHER_SPEED_LVL = 0;
    [HideInInspector] public string PINECONE_LAUNCHER_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    [HideInInspector] public string PINECONE_LAUNCHER_SPEED_NAME = "Faster!";
    [HideInInspector] public int[] PINECONE_LAUNCHER_SPEED_COST = { 100 };
    [HideInInspector] public float[] PINECONE_LAUNCHER_SPEED = { 2 };

    [HideInInspector] public int PINECONE_LAUNCHER_RANGE_LVL = 0;
    [HideInInspector] public string PINECONE_LAUNCHER_RANGE_DESCRIPTION = "Increases Turret Range";
    [HideInInspector] public string PINECONE_LAUNCHER_RANGE_NAME = "More Range!";
    [HideInInspector] public int[] PINECONE_LAUNCHER_RANGE_COST = { 1000 };
    [HideInInspector] public float[] PINECONE_LAUNCHER_RANGE = { 2 };

    [HideInInspector] public int PINECONE_LAUNCHER_DAMAGE_STUN_LVL = 0;
    [HideInInspector] public string PINECONE_LAUNCHER_DAMAGE_STUN_DESCRIPTION = "Now the Turret does more Damage and it stuns the enemies";
    [HideInInspector] public string PINECONE_LAUNCHER_DAMAGE_STUN_NAME = "More Boom Boom!";
    [HideInInspector] public int[] PINECONE_LAUNCHER_DAMAGE_STUN_COST = { 3000 };
    [HideInInspector] public int[] PINECONE_LAUNCHER_DAMAGE_STUN = { 1 };

    [HideInInspector] public int PINECONE_LAUNCHER_CLUSTER_LVL = 0;
    [HideInInspector] public string PINECONE_LAUNCHER_CLUSTER_DESCRIPTION = "Now the explosion releases small parts of the pinecone that explode later.";
    [HideInInspector] public string PINECONE_LAUNCHER_CLUSTER_NAME = "Cluster!";
    [HideInInspector] public int[] PINECONE_LAUNCHER_CLUSTER_COST = { 3000 };
    [HideInInspector] public int[] PINECONE_LAUNCHER_CLUSTER = { 1 };

    [HideInInspector] public int PINECONE_LAUNCHER_CAPACITY_LVL = 0;
    [HideInInspector] public string PINECONE_LAUNCHER_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    [HideInInspector] public string PINECONE_LAUNCHER_CAPACITY_NAME = "More Magazine!";
    [HideInInspector] public int[] PINECONE_LAUNCHER_CAPACITY_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] PINECONE_LAUNCHER_CAPACITY = { 15, 20, 35 };

    [HideInInspector] public int PINECONE_LAUNCHER_CHEST_LVL = 0;
    [HideInInspector] public string PINECONE_LAUNCHER_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    [HideInInspector] public string PINECONE_LAUNCHER_CHEST_NAME_UNO = "Create Chest!";
    [HideInInspector] public string PINECONE_LAUNCHER_CHEST_DESCRIPTION = "Increases chest capacity";
    [HideInInspector] public string PINECONE_LAUNCHER_CHEST_NAME = "More Chest!";
    [HideInInspector] public int[] PINECONE_LAUNCHER_CHEST_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] PINECONE_LAUNCHER_CHEST = { 1, 2, 3 };

    #endregion PINECONE_LAUNCHER

    #region NUT_ROLL

    [HideInInspector] public string NUT_ROLL_DESCRIPTION = "Fires a projectile that rolls around the outside of the tree and damages up to 20 enemies where it passes through.";

    [HideInInspector] public int NUT_ROLL_DAMAGE_LVL = 0;
    [HideInInspector] public string NUT_ROLL_DAMAGE_DESCRIPTION = "Increases Turret Damage";
    [HideInInspector] public string NUT_ROLL_DAMAGE_NAME = "More Nut Damage!";
    [HideInInspector] public int[] NUT_ROLL_DAMAGE_COST = { 100, 1000 };
    [HideInInspector] public int[] NUT_ROLL_DAMAGE = { 40, 60 };

    [HideInInspector] public int NUT_ROLL_SPEED_LVL = 0;
    [HideInInspector] public string NUT_ROLL_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    [HideInInspector] public string NUT_ROLL_SPEED_NAME = "Faster!";
    [HideInInspector] public int[] NUT_ROLL_SPEED_COST = { 100, 1000 };
    [HideInInspector] public float[] NUT_ROLL_SPEED = { 10, 8 };

    [HideInInspector] public int NUT_ROLL_EXTRA_LVL = 0;
    [HideInInspector] public string NUT_ROLL_EXTRA_DESCRIPTION = "For each shot, fires an extra projectile";
    [HideInInspector] public string NUT_ROLL_EXTRA_NAME = "Extra Nut!";
    [HideInInspector] public int[] NUT_ROLL_EXTRA_COST = { 3000 };
    [HideInInspector] public int[] NUT_ROLL_EXTRA = { 1 };

    [HideInInspector] public int NUT_ROLL_HITS_LVL = 0;
    [HideInInspector] public string NUT_ROLL_HITS_DESCRIPTION = "Increases the number of hits delivered by the projectile ";
    [HideInInspector] public string NUT_ROLL_HITS_NAME = "Endurezide Nut!";
    [HideInInspector] public int[] NUT_ROLL_HITS_COST = { 3000 };
    [HideInInspector] public int[] NUT_ROLL_HITS = { 30 };

    [HideInInspector] public int NUT_ROLL_CAPACITY_LVL = 0;
    [HideInInspector] public string NUT_ROLL_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    [HideInInspector] public string NUT_ROLL_CAPACITY_NAME = "More Magazine!";
    [HideInInspector] public int[] NUT_ROLL_CAPACITY_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] NUT_ROLL_CAPACITY = { 10, 12, 14 };

    [HideInInspector] public int NUT_ROLL_CHEST_LVL = 0;
    [HideInInspector] public string NUT_ROLL_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    [HideInInspector] public string NUT_ROLL_CHEST_NAME_UNO = "Create Chest!";
    [HideInInspector] public string NUT_ROLL_CHEST_DESCRIPTION = "Increases chest capacity";
    [HideInInspector] public string NUT_ROLL_CHEST_NAME = "More Chest!";
    [HideInInspector] public int[] NUT_ROLL_CHEST_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] NUT_ROLL_CHEST = { 1, 2, 3 };

    #endregion NUT_ROLL

    #region PORCUTHROW

    [HideInInspector] public string PORCUTHROW_DESCRIPTION = "Fires three projectiles that do a lot of damage at close range";

    [HideInInspector] public int PORCUTHROW_PROJECTILES_LVL = 0;
    [HideInInspector] public string PORCUTHROW_PROJECTILES_DESCRIPTION = "Increases Turret fired projectiles";
    [HideInInspector] public string PORCUTHROW_PROJECTILES_NAME = "More Projectiles!";
    [HideInInspector] public int[] PORCUTHROW_PROJECTILES_COST = { 100, 1000, 3000 };
    [HideInInspector] public int[] PORCUTHROW_PROJECTILES = { 5, 8, 12 };

    [HideInInspector] public int PORCUTHROW_SPEED_LVL = 0;
    [HideInInspector] public string PORCUTHROW_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    [HideInInspector] public string PORCUTHROW_SPEED_NAME = "Faster!";
    [HideInInspector] public int[] PORCUTHROW_SPEED_COST = { 100, 1000 };
    [HideInInspector] public float[] PORCUTHROW_SPEED = { 3.25f, 2.75f };

    [HideInInspector] public int PORCUTHROW_PIERCING_LVL = 0;
    [HideInInspector] public string PORCUTHROW_PIERCING_DESCRIPTION = "Now the shots are piercing";
    [HideInInspector] public string PORCUTHROW_PIERCING_NAME = "Hardened spikes!";
    [HideInInspector] public int[] PORCUTHROW_PIERCING_COST = { 3000 };
    [HideInInspector] public int[] PORCUTHROW_PIERCING = { 1 };

    [HideInInspector] public int PORCUTHROW_CAPACITY_LVL = 0;
    [HideInInspector] public string PORCUTHROW_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    [HideInInspector] public string PORCUTHROW_CAPACITY_NAME = "More Magazine!";
    [HideInInspector] public int[] PORCUTHROW_CAPACITY_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] PORCUTHROW_CAPACITY = { 35, 40, 55 };

    [HideInInspector] public int PORCUTHROW_CHEST_LVL = 0;
    [HideInInspector] public string PORCUTHROW_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    [HideInInspector] public string PORCUTHROW_CHEST_NAME_UNO = "Create Chest!";
    [HideInInspector] public string PORCUTHROW_CHEST_DESCRIPTION = "Increases chest capacity";
    [HideInInspector] public string PORCUTHROW_CHEST_NAME = "More Chest!";
    [HideInInspector] public int[] PORCUTHROW_CHEST_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] PORCUTHROW_CHEST = { 1, 2, 3 };

    #endregion PORCUTHROW

    #region ELECTRIC_POTATO

    [HideInInspector] public string ELECTRIC_POTATO_DESCRIPTION = "Fires electricity that bounces off some enemies, stunning them";

    [HideInInspector] public int ELECTRIC_POTATO_RAY_LVL = 0;
    [HideInInspector] public string ELECTRIC_POTATO_RAY_DESCRIPTION = "Increases the number of enemies hit by the lightning bolt";
    [HideInInspector] public string ELECTRIC_POTATO_RAY_NAME = "Lightning Upgrade!";
    [HideInInspector] public int[] ELECTRIC_POTATO_RAY_COST = { 100, 1000 };
    [HideInInspector] public int[] ELECTRIC_POTATO_RAY = { 10, 15 };

    [HideInInspector] public int ELECTRIC_POTATO_DAMAGE_LVL = 0;
    [HideInInspector] public string ELECTRIC_POTATO_DAMAGE_DESCRIPTION = "Now the Turret does damage";
    [HideInInspector] public string ELECTRIC_POTATO_DAMAGE_NAME = "Taser!";
    [HideInInspector] public int[] ELECTRIC_POTATO_DAMAGE_COST = { 3000 };
    [HideInInspector] public int[] ELECTRIC_POTATO_DAMAGE = { 20 };

    [HideInInspector] public int ELECTRIC_POTATO_SPEED_LVL = 0;
    [HideInInspector] public string ELECTRIC_POTATO_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    [HideInInspector] public string ELECTRIC_POTATO_SPEED_NAME = "Faster!";
    [HideInInspector] public int[] ELECTRIC_POTATO_SPEED_COST = { 100 };
    [HideInInspector] public float[] ELECTRIC_POTATO_SPEED = { 5 };

    [HideInInspector] public int ELECTRIC_POTATO_STUN_LVL = 0;
    [HideInInspector] public string ELECTRIC_POTATO_STUN_DESCRIPTION = "Increases the time that enemies are stunned";
    [HideInInspector] public string ELECTRIC_POTATO_STUN_NAME = "It was not a Lie";
    [HideInInspector] public int[] ELECTRIC_POTATO_STUN_COST = { 1000, 3000 };
    [HideInInspector] public float[] ELECTRIC_POTATO_STUN = { 2, 2.5f };

    [HideInInspector] public int ELECTRIC_POTATO_CAPACITY_LVL = 0;
    [HideInInspector] public string ELECTRIC_POTATO_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    [HideInInspector] public string ELECTRIC_POTATO_CAPACITY_NAME = "More Magazine!";
    [HideInInspector] public int[] ELECTRIC_POTATO_CAPACITY_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] ELECTRIC_POTATO_CAPACITY = { 20, 25, 35 };

    [HideInInspector] public int ELECTRIC_POTATO_CHEST_LVL = 0;
    [HideInInspector] public string ELECTRIC_POTATO_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    [HideInInspector] public string ELECTRIC_POTATO_CHEST_NAME_UNO = "Create Chest!";
    [HideInInspector] public string ELECTRIC_POTATO_CHEST_DESCRIPTION = "Increases chest capacity";
    [HideInInspector] public string ELECTRIC_POTATO_CHEST_NAME = "More Chest!";
    [HideInInspector] public int[] ELECTRIC_POTATO_CHEST_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] ELECTRIC_POTATO_CHEST = { 1, 2, 3 };

    #endregion ELECTRIC_POTATO

    #endregion TURRET ATTRIBUTES

    #region PLAYER

    [HideInInspector] public int PLAYER_SPEED_LVL = 0;
    [HideInInspector] public string PLAYER_SPEED_DESCRIPTION = "Increases the Player Movement Speed";
    [HideInInspector] public string PLAYER_SPEED_NAME = "Gotta Go Fast!";
    [HideInInspector] public int[] PLAYER_SPEED_COST = { 100, 500, 3000 };
    [HideInInspector] public float[] PLAYER_SPEEDY = { 3, 3.5f, 4 };

    [HideInInspector] public int PLAYER_INVENTORY_LVL = 0;
    [HideInInspector] public string PLAYER_INVENTORY_DESCRIPTION = "Increases the inventory slots of the player";
    [HideInInspector] public string PLAYER_INVENTORY_NAME = "Holding Bag!";
    [HideInInspector] public int[] PLAYER_INVENTORY_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] PLAYER_INVENTORY = { 2, 3, 4 };

    [HideInInspector] public int PLAYER_CAPACITY_LVL = 0;
    [HideInInspector] public string PLAYER_CAPACITY_DESCRIPTION = "Increases the inventory capacity per slot";
    [HideInInspector] public string PLAYER_CAPACITY_NAME = "Steve!";
    [HideInInspector] public int[] PLAYER_CAPACITY_COST = { 100, 500, 3000 };
    [HideInInspector] public int[] PLAYER_CAPACITY = { 75, 100, 200 };

    [HideInInspector] public int PLAYER_LIFT_LVL = 0;
    [HideInInspector] public string PLAYER_LIFT_DESCRIPTION = "Now you can change between floors as you want";
    [HideInInspector] public string PLAYER_LIFT_NAME = "Elevator!";
    [HideInInspector] public int[] PLAYER_LIFT_COST = { 100 };
    [HideInInspector] public float[] PLAYER_LIFT_VALUE = { 0.4f };

    #endregion PLAYER

    #region UNLOCK FLOOR DAYS

    [HideInInspector] public int[] unlockFloorDays = { 2, 5, 8, 11, 14, 17, 19, 20, 21 };

    #endregion UNLOCK FLOOR DAYS

    #region UNLOCK NPC DAYS

    [HideInInspector]
    public List<NPC> unlockNpcDays = new List<NPC>{
        new NPC(3, "perrito", "sunflower", "top"),
        new NPC(6, "chinchilla", "pinecone", "bottom"),
        new NPC(9, "castor", "resin", "top"),
        new NPC(12, "puercoespin", "spike", "top"),
        new NPC(15, "capybara", "nut", "bottom"),
        new NPC(18, "rata", "potato", "top"),
    };

    #endregion UNLOCK NPC DAYS
}