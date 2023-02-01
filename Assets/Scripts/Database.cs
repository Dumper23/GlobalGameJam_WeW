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
    public static int[] MACHINE_SEED_DAMAGE = { 35, 40, 50 };
    public static float[] MACHINE_SEED_SPEED = { 0.7f, 0.5f, 0.3f };

    public static int MACHINE_SEED_LEVEL = 0;
    public static int[] MACHINE_SEED_CAPACITY = { 75, 100, 200 };
    public static int[] MACHINE_SEED_CHEST = { 50, 75, 100 };
    #endregion

    #region RESIN_SPIT
    public static int[] RESIN_SPIT_DAMAGE = { 5 };
    public static float[] RESIN_SPIT_SPEED = { 6 };
    public static float[] RESIN_SPIT_DURATION = { 3, 4 };
    public static int[] RESIN_SPIT_STICKNESS = { 0.6f };
    public static float[] RESIN_SPIT_LONG = { 1.6f };

    public static int RESIN_SPIT_LEVEL = 0;
    public static int[] RESIN_SPIT_CAPACITY = { 50, 75, 100 };
    public static int[] RESIN_SPIT_CHEST = { 30, 50, 75 };
    #endregion

    #region S_SEEDNIPER
    public static int[] S_SEEDNIPER_DAMAGE = { 90, 110 };
    public static float[] S_SEEDNIPER_SPEED = { 1.3f, 1, 0.8f };
    public static int[] S_SEEDNIPER_RICOCHET = { 1 };

    public static int S_SEEDNIPER_LEVEL = 0;
    public static int[] S_SEEDNIPER_CAPACITY = { 35, 45, 90 };
    public static int[] S_SEEDNIPER_CHEST = { 20, 35, 45 };
    #endregion

    #region PINECONE_LAUNCHER
    public static int[] PINECONE_LAUNCHER_AREA = { 10 };
    public static int[] PINECONE_LAUNCHER_DAMAGE = { 60, 90 };
    public static float[] PINECONE_LAUNCHER_SPEED = { 2 };
    public static float[] PINECONE_LAUNCHER_RANGE = { 10 };
    public static int[] PINECONE_LAUNCHER_DAMAGE_STUN = { 1 };
    public static int[] PINECONE_LAUNCHER_CLUSTER = { 1 };

    public static int PINECONE_LAUNCHER_LEVEL = 0;
    public static int[] PINECONE_LAUNCHER_CAPACITY = { 50, 75, 100 };
    public static int[] PINECONE_LAUNCHER_CHEST = { 30, 50, 75 };
    #endregion

    #region NUT_ROLL
    public static int[] NUT_ROLL_DAMAGE = { 20, 30 };
    public static float[] NUT_ROLL_SPEED = { 10, 8 };
    public static int[] NUT_ROLL_EXTRA = { 1 };
    public static int[] NUT_ROLL_HITS = { 20 };

    public static int NUT_ROLL_LEVEL = 0;
    public static int[] NUT_ROLL_CAPACITY = { 30, 50, 70 };
    public static int[] NUT_ROLL_CHEST = { 20, 30, 50 };
    #endregion

    #region PORCUTHROW
    public static int[] PORCUTHROW_PROJECTILES = { 5, 8, 12 };
    public static float[] PORCUTHROW_SPEED = { 2.75f };
    public static int[] PORCUTHROW_PIERCING = { 1 };

    public static int PORCUTHROW_LEVEL = 0;
    public static int[] PORCUTHROW_CAPACITY = { 75, 100, 200 };
    public static int[] PORCUTHROW_CHEST = { 50, 75, 100 };
    #endregion

    #region ELECTRIC_POTATO
    public static int[] ELECTRIC_POTATO_RAY = { 10, 15 };
    public static int[] ELECTRIC_POTATO_DAMAGE = { 20 };
    public static float[] ELECTRIC_POTATO_SPEED = { 5 };
    public static int[] ELECTRIC_POTATO_STUN = { 2, 2.5f };

    public static int ELECTRIC_POTATO_LEVEL = 0;
    public static int[] ELECTRIC_POTATO_CAPACITY = { 50, 75, 100 };
    public static int[] ELECTRIC_POTATO_CHEST = { 30, 50, 75 };
    #endregion

    #endregion

    #region PLAYER
    public static int[] PLAYER_SPEED = { 10, 20, 30 };
    public static int[] PLAYER_INVENTORY = { 10, 20, 30 };
    public static int[] PLAYER_CAPACITY = { 10, 20, 30 };
    public static int[] PLAYER_LIFT = { 10 };
    #endregion 

}
