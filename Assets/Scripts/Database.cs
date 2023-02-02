using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{

    #region WAVES FOR EACH DAY
    public static List<EnemyWave> DAY1_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY2_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY3_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY4_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY5_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY6_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY7_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY8_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY9_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY10_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY11_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY12_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY13_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY14_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY15_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY16_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY17_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY18_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY19_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY20_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY21_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY22_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    public static List<EnemyWave> DAY23_WAVES = new List<EnemyWave>{
        new EnemyWave(5, "ant", 1, 0, 1, "walk"),
        new EnemyWave(5, "ant", 1, 0.5f, 1,  "walk")
    };
    #endregion

    #region TURRET ATTRIBUTES

    #region MACHINE_SEED
    public static int MACHINE_SEED_DAMAGE_LVL = 0;
    public static string MACHINE_SEED_DAMAGE_DESCRIPTION = "Increases Turret Damage";
    public static string MACHINE_SEED_DAMAGE_NAME = "More Seeds!";
    public static int[] MACHINE_SEED_DAMAGE_COST = { 10 , 20, 30 };
    public static int[] MACHINE_SEED_DAMAGE = { 35, 40, 50 };

    public static int MACHINE_SEED_SPEED_LVL = 0;
    public static string MACHINE_SEED_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    public static string MACHINE_SEED_SPEED_NAME = "Faster!";
    public static int[] MACHINE_SEED_SPEED_COST = { 10, 20, 30 };
    public static float[] MACHINE_SEED_SPEED = { 0.7f, 0.5f, 0.3f };

    public static int MACHINE_SEED_CAPACITY_LVL = 0;
    public static string MACHINE_SEED_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    public static string MACHINE_SEED_CAPACITY_NAME = "More Magazine!";
    public static int[] MACHINE_SEED_CAPACITY_COST = { 10, 20, 30 };
    public static int[] MACHINE_SEED_CAPACITY = { 75, 100, 200 };

    public static int MACHINE_SEED_CHEST_LVL = 0;
    public static string MACHINE_SEED_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    public static string MACHINE_SEED_CHEST_NAME_UNO = "Create Chest!";
    public static string MACHINE_SEED_CHEST_DESCRIPTION = "Increases chest capacity";
    public static string MACHINE_SEED_CHEST_NAME = "More Chest!";
    public static int[] MACHINE_SEED_CHEST_COST = { 10, 20, 30 };
    public static int[] MACHINE_SEED_CHEST = { 50, 75, 100 };


    #endregion

    #region RESIN_SPIT


    public static int RESIN_SPIT_DAMAGE_LVL = 0;
    public static string RESIN_SPIT_DAMAGE_DESCRIPTION = "Now the resin does a little damage per second";
    public static string RESIN_SPIT_DAMAGE_NAME = "Corrosive Resin";
    public static int[] RESIN_SPITD_DAMAGE_COST = { 10 };
    public static int[] RESIN_SPIT_DAMAGE = { 5 };

    public static int RESIN_SPIT_SPEED_LVL = 0;
    public static string RESIN_SPIT_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    public static string RESIN_SPIT_SPEED_NAME = "Faster!";
    public static int[] RESIN_SPIT_SPEED_COST = { 10 };
    public static float[] RESIN_SPIT_SPEED = { 6 };

    public static int RESIN_SPIT_DURATION_LVL = 0;
    public static string RESIN_SPIT_DURATION_DESCRIPTION = "Increases the duration of the resin in the tree";
    public static string RESIN_SPIT_DURATION_NAME = "More Resin!";
    public static int[] MACHINE_SEED_DURATION_COST = { 10, 20 };
    public static float[] RESIN_SPIT_DURATION = { 3, 4 };

    public static int RESIN_SPIT_STICKNESS_LVL = 0;
    public static string RESIN_SPIT_STICKNESS_DESCRIPTION = "Increases resin slow";
    public static string RESIN_SPIT_STICKNESS_NAME = "Sticky Resin";
    public static int[] RESIN_SPIT_STICKNESS_COST = { 10 };
    public static float[] RESIN_SPIT_STICKNESS = { 0.6f };

    public static int RESIN_SPIT_LONG_LVL = 0;
    public static string RESIN_SPIT_LONG_DESCRIPTION = "Increases the length of the Puddle";
    public static string RESIN_SPIT_LONG_NAME = "Size does matter";
    public static int[] RESIN_SPIT_LONG_COST = { 10 };
    public static float[] RESIN_SPIT_LONG = { 1.6f };

    public static int RESIN_SPIT_CAPACITY_LVL = 0;
    public static string RESIN_SPIT_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    public static string RESIN_SPIT_CAPACITY_NAME = "More Magazine!";
    public static int[] RESIN_SPIT_CAPACITY_COST = { 10, 20, 30 };
    public static int[] RESIN_SPIT_CAPACITY = { 50, 75, 100 };

    public static int RESIN_SPIT_CHEST_LVL = 0;
    public static string RESIN_SPIT_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    public static string RESIN_SPIT_CHEST_NAME_UNO = "Create Chest!";
    public static string RESIN_SPIT_CHEST_DESCRIPTION = "Increases chest capacity";
    public static string RESIN_SPIT_CHEST_NAME = "More Chest!";
    public static int[] RESIN_SPIT_CHEST_COST = { 10, 20, 30 };
    public static int[] RESIN_SPIT_CHEST = { 30, 50, 75 };
    #endregion

    #region S_SEEDNIPER
    public static int S_SEEDNIPER_DAMAGE_LVL = 0;
    public static string S_SEEDNIPER_DAMAGE_DESCRIPTION = "Increases Turret Damage";
    public static string S_SEEDNIPER_DAMAGE_NAME = "More Damage!";
    public static int[] S_SEEDNIPER_DAMAGE_COST = { 10, 20 };
    public static int[] S_SEEDNIPER_DAMAGE = { 90, 110 };

    public static int S_SEEDNIPER_SPEED_LVL = 0;
    public static string S_SEEDNIPER_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    public static string S_SEEDNIPER_SPEED_NAME = "Faster!";
    public static int[] S_SEEDNIPER_SPEED_COST = { 10, 20, 30 };
    public static float[] S_SEEDNIPER_SPEED = { 1.3f, 1, 0.8f };

    public static int S_SEEDNIPER_RICOCHET_LVL = 0;
    public static string S_SEEDNIPER_RICOCHET_DESCRIPTION = "Bullets now ricochet off enemies";
    public static string S_SEEDNIPER_RICOCHET_NAME = "Ricochet";
    public static int[] S_SEEDNIPER_RICOCHET_COST = { 10 };
    public static int[] S_SEEDNIPER_RICOCHET = { 1 };

    public static int S_SEEDNIPER_CAPACITY_LVL = 0;
    public static string S_SEEDNIPER_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    public static string S_SEEDNIPER_CAPACITY_NAME = "More Magazine!";
    public static int[] S_SEEDNIPER_CAPACITY_COST = { 10, 20, 30 };
    public static int[] S_SEEDNIPER_CAPACITY = { 35, 45, 90 };

    public static int S_SEEDNIPER_CHEST_LVL = 0;
    public static string S_SEEDNIPER_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    public static string S_SEEDNIPER_CHEST_NAME_UNO = "Create Chest!";
    public static string S_SEEDNIPER_CHEST_DESCRIPTION = "Increases chest capacity";
    public static string S_SEEDNIPER_CHEST_NAME = "More Chest!";
    public static int[] S_SEEDNIPER_CHEST = { 20, 35, 45 };
    #endregion

    #region PINECONE_LAUNCHER
    public static int PINECONE_LAUNCHER_AREA_LVL = 0;
    public static string PINECONE_LAUNCHER_AREA_DESCRIPTION = "Increases the area of the explosion";
    public static string PINECONE_LAUNCHER_AREA_NAME = "More Boom!";
    public static int[] PINECONE_LAUNCHER_AREA_COST = { 10 };
    public static int[] PINECONE_LAUNCHER_AREA = { 10 };

    public static int PINECONE_LAUNCHER_DAMAGE_LVL = 0;
    public static string PINECONE_LAUNCHER_DAMAGE_DESCRIPTION = "Increases Turret Damage";
    public static string PINECONE_LAUNCHER_DAMAGE_NAME = "More Pinecones!";
    public static int[] PINECONE_LAUNCHER_DAMAGE_COST = { 10, 20 };
    public static int[] PINECONE_LAUNCHER_DAMAGE = { 60, 90 };

    public static int PINECONE_LAUNCHER_SPEED_LVL = 0;
    public static string PINECONE_LAUNCHER_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    public static string PINECONE_LAUNCHER_SPEED_NAME = "Faster!";
    public static int[] PINECONE_LAUNCHER_SPEED_COST = { 10 }; 
    public static float[] PINECONE_LAUNCHER_SPEED = { 2 };

    public static int PINECONE_LAUNCHER_RANGE_LVL = 0;
    public static string PINECONE_LAUNCHER_RANGE_DESCRIPTION = "Increases Turret Range";
    public static string PINECONE_LAUNCHER_RANGE_NAME = "More Range!";
    public static int[] PINECONE_LAUNCHER_RANGE_COST = { 10 };
    public static float[] PINECONE_LAUNCHER_RANGE = { 10 };

    public static int PINECONE_LAUNCHER_DAMAGE_STUN_LVL = 0;
    public static string PINECONE_LAUNCHER_DAMAGE_STUN_DESCRIPTION = "Now the Turret does more Damage and it stuns the enemies";
    public static string PINECONE_LAUNCHER_DAMAGE_STUN_NAME = "More Boom Boom!";
    public static int[] PINECONE_LAUNCHER_DAMAGE_STUN_COST = { 10 };
    public static int[] PINECONE_LAUNCHER_DAMAGE_STUN = { 1 };

    public static int PINECONE_LAUNCHER_CLUSTER_LVL = 0;
    public static string PINECONE_LAUNCHER_CLUSTER_DESCRIPTION = "Now the explosion releases small parts of the pinecone that explode later.";
    public static string PINECONE_LAUNCHER_CLUSTER_NAME = "Cluster!";
    public static int[] PINECONE_LAUNCHER_CLUSTER_COST = { 10 };
    public static int[] PINECONE_LAUNCHER_CLUSTER = { 1 };

    public static int PINECONE_LAUNCHER_CAPACITY_LVL = 0;
    public static string PINECONE_LAUNCHER_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    public static string PINECONE_LAUNCHER_CAPACITY_NAME = "More Magazine!";
    public static int[] PINECONE_LAUNCHER_CAPACITY_COST = { 10, 20, 30 };
    public static int[] PINECONE_LAUNCHER_CAPACITY = { 50, 75, 100 };

    public static int PINECONE_LAUNCHER_CHEST_LVL = 0;
    public static string PINECONE_LAUNCHER_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    public static string PINECONE_LAUNCHER_CHEST_NAME_UNO = "Create Chest!";
    public static string PINECONE_LAUNCHER_CHEST_DESCRIPTION = "Increases chest capacity";
    public static string PINECONE_LAUNCHER_CHEST_NAME = "More Chest!";
    public static int[] PINECONE_LAUNCHER_CHEST = { 30, 50, 75 };
    #endregion

    #region NUT_ROLL
    public static int NUT_ROLL_DAMAGE_LVL = 0;
    public static string NUT_ROLL_DAMAGE_DESCRIPTION = "Increases Turret Damage";
    public static string NUT_ROLL_DAMAGE_NAME = "More Nut Damage!";
    public static int[] NUT_ROLL_DAMAGE_COST = { 10, 20 };
    public static int[] NUT_ROLL_DAMAGE = { 20, 30 };

    public static int NUT_ROLL_SPEED_LVL = 0;
    public static string NUT_ROLL_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    public static string NUT_ROLL_SPEED_NAME = "Faster!";
    public static int[] NUT_ROLL_SPEED_COST = { 10, 20 };
    public static float[] NUT_ROLL_SPEED = { 10, 8 };

    public static int NUT_ROLL_EXTRA_LVL = 0;
    public static string NUT_ROLL_EXTRA_DESCRIPTION = "For each shot, fires an extra projectile";
    public static string NUT_ROLL_EXTRA_NAME = "Extra Nut!";
    public static int[] NUT_ROLL_EXTRA_COST = { 10 };
    public static int[] NUT_ROLL_EXTRA = { 1 };

    public static int NUT_ROLL_HITS_LVL = 0;
    public static string NUT_ROLL_HITS_DESCRIPTION = "Increases the number of hits delivered by the projectile ";
    public static string NUT_ROLL_HITS_NAME = "Endurezide Nut!";
    public static int[] NUT_ROLL_HITS_COST = { 10 };
    public static int[] NUT_ROLL_HITS = { 30 };

    public static int NUT_ROLL_CAPACITY_LVL = 0;
    public static string NUT_ROLL_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    public static string NUT_ROLL_CAPACITY_NAME = "More Magazine!";
    public static int[] NUT_ROLL_CAPACITY_COST = { 10, 20, 30 };
    public static int[] NUT_ROLL_CAPACITY = { 30, 50, 70 };

    public static int NUT_ROLL_CHEST_LVL = 0;
    public static string NUT_ROLL_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    public static string NUT_ROLL_CHEST_NAME_UNO = "Create Chest!";
    public static string NUT_ROLL_CHEST_DESCRIPTION = "Increases chest capacity";
    public static string NUT_ROLL_CHEST_NAME = "More Chest!";
    public static int[] NUT_ROLL_CHEST_COST = { 10, 20, 30 };
    public static int[] NUT_ROLL_CHEST = { 20, 30, 50 };
    #endregion

    #region PORCUTHROW
    public static int PORCUTHROW_PROJECTILES_LVL = 0;
    public static string PORCUTHROW_PROJECTILES_DESCRIPTION = "Increases Turret fired projectiles";
    public static string PORCUTHROW_PROJECTILES_NAME = "More Projectiles!";
    public static int[] PORCUTHROW_PROJECTILES_COST = { 10, 20, 30 };
    public static int[] PORCUTHROW_PROJECTILES = { 5, 8, 12 };

    public static int PORCUTHROW_SPEED_LVL = 0;
    public static string PORCUTHROW_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    public static string PORCUTHROW_SPEED_NAME = "Faster!";
    public static int[] PORCUTHROW_SPEED_COST = { 10 };
    public static float[] PORCUTHROW_SPEED = { 2.75f };

    public static int PORCUTHROW_PIERCING_LVL = 0;
    public static string PORCUTHROW_PIERCING_DESCRIPTION = "Now the shots are piercing";
    public static string PORCUTHROW_PIERCING_NAME = "Hardened spikes!";
    public static int[] PORCUTHROW_PIERCING_COST = { 10 };
    public static int[] PORCUTHROW_PIERCING = { 1 };

    public static int PORCUTHROW_CAPACITY_LVL = 0;
    public static string PORCUTHROW_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    public static string PORCUTHROW_CAPACITY_NAME = "More Magazine!";
    public static int[] PORCUTHROW_CAPACITY_COST = { 10, 20, 30 };
    public static int[] PORCUTHROW_CAPACITY = { 75, 100, 200 };

    public static int PORCUTHROW_CHEST_LVL = 0;
    public static string PORCUTHROW_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    public static string PORCUTHROW_CHEST_NAME_UNO = "Create Chest!";
    public static string PORCUTHROW_CHEST_DESCRIPTION = "Increases chest capacity";
    public static string PORCUTHROW_CHEST_NAME = "More Chest!";
    public static int[] PORCUTHROW_CHEST_COST = { 10, 20, 30 };
    public static int[] PORCUTHROW_CHEST = { 50, 75, 100 };
    #endregion

    #region ELECTRIC_POTATO
    public static int ELECTRIC_POTATO_RAY_LVL = 0;
    public static string ELECTRIC_POTATO_RAY_DESCRIPTION = "Increases the number of enemies hit by the lightning bolt";
    public static string ELECTRIC_POTATO_RAY_NAME = "Lightning Upgrade!";
    public static int[] ELECTRIC_POTATO_RAY_COST = { 10, 20 };
    public static int[] ELECTRIC_POTATO_RAY = { 10, 15 };

    public static int ELECTRIC_POTATO_DAMAGE_LVL = 0;
    public static string ELECTRIC_POTATO_DAMAGE_DESCRIPTION = "Now the Turret does damage";
    public static string ELECTRIC_POTATO_DAMAGE_NAME = "More Seeds!";
    public static int[] ELECTRIC_POTATO_DAMAGE_COST = { 10 };
    public static int[] ELECTRIC_POTATO_DAMAGE = { 20 };

    public static int ELECTRIC_POTATO_SPEED_LVL = 0;
    public static string ELECTRIC_POTATO_SPEED_DESCRIPTION = "Increases Turret Attack Speed";
    public static string ELECTRIC_POTATO_SPEED_NAME = "Faster!";
    public static int[] ELECTRIC_POTATO_SPEED_COST = { 10 };
    public static float[] ELECTRIC_POTATO_SPEED = { 5 };

    public static int ELECTRIC_POTATO_STUN_LVL = 0;
    public static string ELECTRIC_POTATO_STUN_DESCRIPTION = "Increases the time that enemies are stunned";
    public static string ELECTRIC_POTATO_STUN_NAME = "It was not a Lie";
    public static int[] ELECTRIC_POTATO_STUN_COST = { 10, 20 };
    public static float[] ELECTRIC_POTATO_STUN = { 2, 2.5f };

    public static int ELECTRIC_POTATO_CAPACITY_LVL = 0;
    public static string ELECTRIC_POTATO_CAPACITY_DESCRIPTION = "Increases turret magazine capacity";
    public static string ELECTRIC_POTATO_CAPACITY_NAME = "More Magazine!";
    public static int[] ELECTRIC_POTATO_CAPACITY_COST = { 10, 20, 30 };
    public static int[] ELECTRIC_POTATO_CAPACITY = { 50, 75, 100 };

    public static int ELECTRIC_POTATO_CHEST_LVL = 0;
    public static string ELECTRIC_POTATO_CHEST_DESCRIPTION_UNO = "Creates a chest next to the turret where you can store ammunition";
    public static string ELECTRIC_POTATO_CHEST_NAME_UNO = "Create Chest!";
    public static string ELECTRIC_POTATO_CHEST_DESCRIPTION = "Increases chest capacity";
    public static string ELECTRIC_POTATO_CHEST_NAME = "More Chest!";
    public static int[] ELECTRIC_POTATO_CHEST_COST = { 10, 20, 30 };
    public static int[] ELECTRIC_POTATO_CHEST = { 30, 50, 75 };
    #endregion

    #endregion

    #region PLAYER
    public static int PLAYER_SPEED_LVL = 0;
    public static int PLAYER_INVENTORY_LVL = 0;
    public static int PLAYER_CAPACITY_LVL = 0;
    public static int PLAYER_LIFT_LVL = 0;

    public static int[] PLAYER_SPEED = { 10, 20, 30 };
    public static int[] PLAYER_INVENTORY = { 10, 20, 30 };
    public static int[] PLAYER_CAPACITY = { 10, 20, 30 };
    public static int[] PLAYER_LIFT = { 10 };
    #endregion 

}
