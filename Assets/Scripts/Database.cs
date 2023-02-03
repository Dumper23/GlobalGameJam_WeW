using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(0)]
public class Database : MonoBehaviour
{
    public static Database Instance;

    private void Awake() => Instance = this;

    #region WAVES FOR EACH DAY
    public List<EnemyWave> DAY1_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        //new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY2_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        //new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY3_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY4_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY5_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY6_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY7_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY8_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY9_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY10_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY11_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY12_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY13_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY14_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY15_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY16_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY17_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY18_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY19_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY20_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY21_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY22_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public List<EnemyWave> DAY23_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    #endregion

    #region TURRET ATTRIBUTES

    #region MACHINE_SEED

    public string MACHINE_SEED_DESCRIPTION = "Shoot a single enemy until it is eliminated";

    public int MACHINE_SEED_DAMAGE_LVL = 0;
    public string MACHINE_SEED_DAMAGE_DESCRIPTION = "Increases Turret Damage";
    public string MACHINE_SEED_DAMAGE_NAME = "More Seeds!";
    public int[] MACHINE_SEED_DAMAGE_COST = { 10 , 20, 30 };
    public int[] MACHINE_SEED_DAMAGE = { 35, 40, 50 };

    public int MACHINE_SEED_SPEED_LVL = 0;
    public string MACHINE_SEED_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    public string MACHINE_SEED_SPEED_NAME = "Faster!";
    public int[] MACHINE_SEED_SPEED_COST = { 10, 20, 30 };
    public float[] MACHINE_SEED_SPEED = { 0.7f, 0.5f, 0.3f };

    public int MACHINE_SEED_CAPACITY_LVL = 0;
    public string MACHINE_SEED_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    public string MACHINE_SEED_CAPACITY_NAME = "More Magazine!";
    public int[] MACHINE_SEED_CAPACITY_COST = { 10, 20, 30 };
    public int[] MACHINE_SEED_CAPACITY = { 75, 100, 200 };

    public int MACHINE_SEED_CHEST_LVL = 0;
    public string MACHINE_SEED_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    public string MACHINE_SEED_CHEST_NAME_UNO = "Create Chest!";
    public string MACHINE_SEED_CHEST_DESCRIPTION = "Increases chest capacity";
    public string MACHINE_SEED_CHEST_NAME = "More Chest!";
    public int[] MACHINE_SEED_CHEST_COST = { 10, 20, 30 };
    public int[] MACHINE_SEED_CHEST = { 50, 75, 100 };


    #endregion

    #region RESIN_SPIT

    public string RESIN_SPIT_DESCRIPTION = "Shoots a resin puddle that slows down the enemy as it passes through it";

    public int RESIN_SPIT_DAMAGE_LVL = 0;
    public string RESIN_SPIT_DAMAGE_DESCRIPTION = "Now the resin does a little damage per second";
    public string RESIN_SPIT_DAMAGE_NAME = "Corrosive Resin";
    public int[] RESIN_SPIT_DAMAGE_COST = { 10 };
    public int[] RESIN_SPIT_DAMAGE = { 5 };

    public int RESIN_SPIT_SPEED_LVL = 0;
    public string RESIN_SPIT_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    public string RESIN_SPIT_SPEED_NAME = "Faster!";
    public int[] RESIN_SPIT_SPEED_COST = { 10 };
    public float[] RESIN_SPIT_SPEED = { 6 };

    public int RESIN_SPIT_DURATION_LVL = 0;
    public string RESIN_SPIT_DURATION_DESCRIPTION = "Increases the duration of the resin in the tree";
    public string RESIN_SPIT_DURATION_NAME = "More Resin!";
    public int[] MACHINE_SEED_DURATION_COST = { 10, 20 };
    public float[] RESIN_SPIT_DURATION = { 3, 4 };

    public int RESIN_SPIT_STICKNESS_LVL = 0;
    public string RESIN_SPIT_STICKNESS_DESCRIPTION = "Increases resin slow";
    public string RESIN_SPIT_STICKNESS_NAME = "Sticky Resin";
    public int[] RESIN_SPIT_STICKNESS_COST = { 10 };
    public float[] RESIN_SPIT_STICKNESS = { 0.6f };

    public int RESIN_SPIT_LONG_LVL = 0;
    public string RESIN_SPIT_LONG_DESCRIPTION = "Increases the length of the Puddle";
    public string RESIN_SPIT_LONG_NAME = "Size does matter";
    public int[] RESIN_SPIT_LONG_COST = { 10 };
    public float[] RESIN_SPIT_LONG = { 1.6f };

    public int RESIN_SPIT_CAPACITY_LVL = 0;
    public string RESIN_SPIT_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    public string RESIN_SPIT_CAPACITY_NAME = "More Magazine!";
    public int[] RESIN_SPIT_CAPACITY_COST = { 10, 20, 30 };
    public int[] RESIN_SPIT_CAPACITY = { 50, 75, 100 };

    public int RESIN_SPIT_CHEST_LVL = 0;
    public string RESIN_SPIT_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    public string RESIN_SPIT_CHEST_NAME_UNO = "Create Chest!";
    public string RESIN_SPIT_CHEST_DESCRIPTION = "Increases chest capacity";
    public string RESIN_SPIT_CHEST_NAME = "More Chest!";
    public int[] RESIN_SPIT_CHEST_COST = { 10, 20, 30 };
    public int[] RESIN_SPIT_CHEST = { 30, 50, 75 };
    #endregion

    #region S_SEEDNIPER

    public string S_SEEDNIPER_DESCRIPTION = "Fires a projectile that does a lot of damage, but has slow firerate.";

    public int S_SEEDNIPER_DAMAGE_LVL = 0;
    public string S_SEEDNIPER_DAMAGE_DESCRIPTION = "Increases Turret Damage";
    public string S_SEEDNIPER_DAMAGE_NAME = "More Damage!";
    public int[] S_SEEDNIPER_DAMAGE_COST = { 10, 20 };
    public int[] S_SEEDNIPER_DAMAGE = { 90, 110 };

    public int S_SEEDNIPER_SPEED_LVL = 0;
    public string S_SEEDNIPER_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    public string S_SEEDNIPER_SPEED_NAME = "Faster!";
    public int[] S_SEEDNIPER_SPEED_COST = { 10, 20, 30 };
    public float[] S_SEEDNIPER_SPEED = { 1.3f, 1, 0.8f };

    public int S_SEEDNIPER_RICOCHET_LVL = 0;
    public string S_SEEDNIPER_RICOCHET_DESCRIPTION = "Bullets now ricochet off enemies";
    public string S_SEEDNIPER_RICOCHET_NAME = "Ricochet";
    public int[] S_SEEDNIPER_RICOCHET_COST = { 10 };
    public int[] S_SEEDNIPER_RICOCHET = { 1 };

    public int S_SEEDNIPER_CAPACITY_LVL = 0;
    public string S_SEEDNIPER_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    public string S_SEEDNIPER_CAPACITY_NAME = "More Magazine!";
    public int[] S_SEEDNIPER_CAPACITY_COST = { 10, 20, 30 };
    public int[] S_SEEDNIPER_CAPACITY = { 35, 45, 90 };

    public int S_SEEDNIPER_CHEST_LVL = 0;
    public string S_SEEDNIPER_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    public string S_SEEDNIPER_CHEST_NAME_UNO = "Create Chest!";
    public string S_SEEDNIPER_CHEST_DESCRIPTION = "Increases chest capacity";
    public string S_SEEDNIPER_CHEST_NAME = "More Chest!";
    public int[] S_SEEDNIPER_CHEST = { 20, 35, 45 };
    #endregion

    #region PINECONE_LAUNCHER

    public string PINECONE_LAUNCHER_DESCRIPTION = "Fires a projectile that does area damage, but has slow firerate.";

    public int PINECONE_LAUNCHER_AREA_LVL = 0;
    public string PINECONE_LAUNCHER_AREA_DESCRIPTION = "Increases the area of the explosion";
    public string PINECONE_LAUNCHER_AREA_NAME = "More Boom!";
    public int[] PINECONE_LAUNCHER_AREA_COST = { 10 };
    public int[] PINECONE_LAUNCHER_AREA = { 10 };

    public int PINECONE_LAUNCHER_DAMAGE_LVL = 0;
    public string PINECONE_LAUNCHER_DAMAGE_DESCRIPTION = "Increases Turret Damage";
    public string PINECONE_LAUNCHER_DAMAGE_NAME = "More Pinecones!";
    public int[] PINECONE_LAUNCHER_DAMAGE_COST = { 10, 20 };
    public int[] PINECONE_LAUNCHER_DAMAGE = { 60, 90 };

    public int PINECONE_LAUNCHER_SPEED_LVL = 0;
    public string PINECONE_LAUNCHER_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    public string PINECONE_LAUNCHER_SPEED_NAME = "Faster!";
    public int[] PINECONE_LAUNCHER_SPEED_COST = { 10 }; 
    public float[] PINECONE_LAUNCHER_SPEED = { 2 };

    public int PINECONE_LAUNCHER_RANGE_LVL = 0;
    public string PINECONE_LAUNCHER_RANGE_DESCRIPTION = "Increases Turret Range";
    public string PINECONE_LAUNCHER_RANGE_NAME = "More Range!";
    public int[] PINECONE_LAUNCHER_RANGE_COST = { 10 };
    public float[] PINECONE_LAUNCHER_RANGE = { 10 };

    public int PINECONE_LAUNCHER_DAMAGE_STUN_LVL = 0;
    public string PINECONE_LAUNCHER_DAMAGE_STUN_DESCRIPTION = "Now the Turret does more Damage and it stuns the enemies";
    public string PINECONE_LAUNCHER_DAMAGE_STUN_NAME = "More Boom Boom!";
    public int[] PINECONE_LAUNCHER_DAMAGE_STUN_COST = { 10 };
    public int[] PINECONE_LAUNCHER_DAMAGE_STUN = { 1 };

    public int PINECONE_LAUNCHER_CLUSTER_LVL = 0;
    public string PINECONE_LAUNCHER_CLUSTER_DESCRIPTION = "Now the explosion releases small parts of the pinecone that explode later.";
    public string PINECONE_LAUNCHER_CLUSTER_NAME = "Cluster!";
    public int[] PINECONE_LAUNCHER_CLUSTER_COST = { 10 };
    public int[] PINECONE_LAUNCHER_CLUSTER = { 1 };

    public int PINECONE_LAUNCHER_CAPACITY_LVL = 0;
    public string PINECONE_LAUNCHER_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    public string PINECONE_LAUNCHER_CAPACITY_NAME = "More Magazine!";
    public int[] PINECONE_LAUNCHER_CAPACITY_COST = { 10, 20, 30 };
    public int[] PINECONE_LAUNCHER_CAPACITY = { 50, 75, 100 };

    public int PINECONE_LAUNCHER_CHEST_LVL = 0;
    public string PINECONE_LAUNCHER_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    public string PINECONE_LAUNCHER_CHEST_NAME_UNO = "Create Chest!";
    public string PINECONE_LAUNCHER_CHEST_DESCRIPTION = "Increases chest capacity";
    public string PINECONE_LAUNCHER_CHEST_NAME = "More Chest!";
    public int[] PINECONE_LAUNCHER_CHEST = { 30, 50, 75 };
    #endregion

    #region NUT_ROLL

    public string NUT_ROLL_DESCRIPTION = "Fires a projectile that rolls around the outside of the tree and damages up to 20 enemies where it passes through.";

    public int NUT_ROLL_DAMAGE_LVL = 0;
    public string NUT_ROLL_DAMAGE_DESCRIPTION = "Increases Turret Damage";
    public string NUT_ROLL_DAMAGE_NAME = "More Nut Damage!";
    public int[] NUT_ROLL_DAMAGE_COST = { 10, 20 };
    public int[] NUT_ROLL_DAMAGE = { 20, 30 };

    public int NUT_ROLL_SPEED_LVL = 0;
    public string NUT_ROLL_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    public string NUT_ROLL_SPEED_NAME = "Faster!";
    public int[] NUT_ROLL_SPEED_COST = { 10, 20 };
    public float[] NUT_ROLL_SPEED = { 10, 8 };

    public int NUT_ROLL_EXTRA_LVL = 0;
    public string NUT_ROLL_EXTRA_DESCRIPTION = "For each shot, fires an extra projectile";
    public string NUT_ROLL_EXTRA_NAME = "Extra Nut!";
    public int[] NUT_ROLL_EXTRA_COST = { 10 };
    public int[] NUT_ROLL_EXTRA = { 1 };

    public int NUT_ROLL_HITS_LVL = 0;
    public string NUT_ROLL_HITS_DESCRIPTION = "Increases the number of hits delivered by the projectile ";
    public string NUT_ROLL_HITS_NAME = "Endurezide Nut!";
    public int[] NUT_ROLL_HITS_COST = { 10 };
    public int[] NUT_ROLL_HITS = { 30 };

    public int NUT_ROLL_CAPACITY_LVL = 0;
    public string NUT_ROLL_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    public string NUT_ROLL_CAPACITY_NAME = "More Magazine!";
    public int[] NUT_ROLL_CAPACITY_COST = { 10, 20, 30 };
    public int[] NUT_ROLL_CAPACITY = { 30, 50, 70 };

    public int NUT_ROLL_CHEST_LVL = 0;
    public string NUT_ROLL_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    public string NUT_ROLL_CHEST_NAME_UNO = "Create Chest!";
    public string NUT_ROLL_CHEST_DESCRIPTION = "Increases chest capacity";
    public string NUT_ROLL_CHEST_NAME = "More Chest!";
    public int[] NUT_ROLL_CHEST_COST = { 10, 20, 30 };
    public int[] NUT_ROLL_CHEST = { 20, 30, 50 };
    #endregion

    #region PORCUTHROW

    public string PORCUTHROW_DESCRIPTION = "Fires three projectiles that do a lot of damage at close range";

    public int PORCUTHROW_PROJECTILES_LVL = 0;
    public string PORCUTHROW_PROJECTILES_DESCRIPTION = "Increases Turret fired projectiles";
    public string PORCUTHROW_PROJECTILES_NAME = "More Projectiles!";
    public int[] PORCUTHROW_PROJECTILES_COST = { 10, 20, 30 };
    public int[] PORCUTHROW_PROJECTILES = { 5, 8, 12 };

    public int PORCUTHROW_SPEED_LVL = 0;
    public string PORCUTHROW_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    public string PORCUTHROW_SPEED_NAME = "Faster!";
    public int[] PORCUTHROW_SPEED_COST = { 10 };
    public float[] PORCUTHROW_SPEED = { 2.75f };

    public int PORCUTHROW_PIERCING_LVL = 0;
    public string PORCUTHROW_PIERCING_DESCRIPTION = "Now the shots are piercing";
    public string PORCUTHROW_PIERCING_NAME = "Hardened spikes!";
    public int[] PORCUTHROW_PIERCING_COST = { 10 };
    public int[] PORCUTHROW_PIERCING = { 1 };

    public int PORCUTHROW_CAPACITY_LVL = 0;
    public string PORCUTHROW_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    public string PORCUTHROW_CAPACITY_NAME = "More Magazine!";
    public int[] PORCUTHROW_CAPACITY_COST = { 10, 20, 30 };
    public int[] PORCUTHROW_CAPACITY = { 75, 100, 200 };

    public int PORCUTHROW_CHEST_LVL = 0;
    public string PORCUTHROW_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    public string PORCUTHROW_CHEST_NAME_UNO = "Create Chest!";
    public string PORCUTHROW_CHEST_DESCRIPTION = "Increases chest capacity";
    public string PORCUTHROW_CHEST_NAME = "More Chest!";
    public int[] PORCUTHROW_CHEST_COST = { 10, 20, 30 };
    public int[] PORCUTHROW_CHEST = { 50, 75, 100 };
    #endregion

    #region ELECTRIC_POTATO

    public string ELECTRIC_POTATO_DESCRIPTION = "Fires electricity that bounces off some enemies, stunning them";

    public int ELECTRIC_POTATO_RAY_LVL = 0;
    public string ELECTRIC_POTATO_RAY_DESCRIPTION = "Increases the number of enemies hit by the lightning bolt";
    public string ELECTRIC_POTATO_RAY_NAME = "Lightning Upgrade!";
    public int[] ELECTRIC_POTATO_RAY_COST = { 10, 20 };
    public int[] ELECTRIC_POTATO_RAY = { 10, 15 };

    public int ELECTRIC_POTATO_DAMAGE_LVL = 0;
    public string ELECTRIC_POTATO_DAMAGE_DESCRIPTION = "Now the Turret does damage";
    public string ELECTRIC_POTATO_DAMAGE_NAME = "More Seeds!";
    public int[] ELECTRIC_POTATO_DAMAGE_COST = { 10 };
    public int[] ELECTRIC_POTATO_DAMAGE = { 20 };

    public int ELECTRIC_POTATO_SPEED_LVL = 0;
    public string ELECTRIC_POTATO_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    public string ELECTRIC_POTATO_SPEED_NAME = "Faster!";
    public int[] ELECTRIC_POTATO_SPEED_COST = { 10 };
    public float[] ELECTRIC_POTATO_SPEED = { 5 };

    public int ELECTRIC_POTATO_STUN_LVL = 0;
    public string ELECTRIC_POTATO_STUN_DESCRIPTION = "Increases the time that enemies are stunned";
    public string ELECTRIC_POTATO_STUN_NAME = "It was not a Lie";
    public int[] ELECTRIC_POTATO_STUN_COST = { 10, 20 };
    public float[] ELECTRIC_POTATO_STUN = { 2, 2.5f };

    public int ELECTRIC_POTATO_CAPACITY_LVL = 0;
    public string ELECTRIC_POTATO_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    public string ELECTRIC_POTATO_CAPACITY_NAME = "More Magazine!";
    public int[] ELECTRIC_POTATO_CAPACITY_COST = { 10, 20, 30 };
    public int[] ELECTRIC_POTATO_CAPACITY = { 50, 75, 100 };

    public int ELECTRIC_POTATO_CHEST_LVL = 0;
    public string ELECTRIC_POTATO_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    public string ELECTRIC_POTATO_CHEST_NAME_UNO = "Create Chest!";
    public string ELECTRIC_POTATO_CHEST_DESCRIPTION = "Increases chest capacity";
    public string ELECTRIC_POTATO_CHEST_NAME = "More Chest!";
    public int[] ELECTRIC_POTATO_CHEST_COST = { 10, 20, 30 };
    public int[] ELECTRIC_POTATO_CHEST = { 30, 50, 75 };
    #endregion

    #endregion

    #region PLAYER

    public int PLAYER_SPEED_LVL = 0;
    public string PLAYER_SPEED_DESCRIPTION = "Increases the Player Movement Speed";
    public string PLAYER_SPEED_NAME = "Gotta Go Fast!";
    public int[] PLAYER_SPEED_COST = { 10, 20, 30 };
    public float[] PLAYER_SPEED = { 3, 3.5f, 4 };

    
    public int PLAYER_INVENTORY_LVL = 0;
    public string PLAYER_INVENTORY_DESCRIPTION = "Increases the inventory slots of the player";
    public string PLAYER_INVENTORY_NAME = "Holding Bag!";
    public int[] PLAYER_INVENTORY_COST = { 10, 20, 30 };
    public int[] PLAYER_INVENTORY = { 2, 3, 4 };

    public int PLAYER_CAPACITY_LVL = 0;
    public string PLAYER_CAPACITY_DESCRIPTION = "Increases the inventory capacity per slot";
    public string PLAYER_CAPACITY_NAME = "Steve!";
    public int[] PLAYER_CAPACITY_COST = { 10, 20, 30 };
    public int[] PLAYER_CAPACITY = { 75, 100, 200 };

    public int PLAYER_LIFT_LVL = 0;
    public string PLAYER_LIFT_DESCRIPTION = "Now you can change between floors as you want";
    public string PLAYER_LIFT_NAME = "Elevator!";
    public int[] PLAYER_LIFT_COST = { 10 };
    public int[] PLAYER_LIFT = { 1 };

    #endregion 

    #region UNLOCK FLOOR DAYS
    public int[] unlockFloorDays = { 2, 5, 8, 11, 14, 17, 19, 20, 21 };
    #endregion
}
