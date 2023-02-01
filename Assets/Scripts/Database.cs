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
    public static int[] MACHINE_SEED_DAMAGE = { 10, 20, 30 };
    public static float[] MACHINE_SEED_SPEED = { 10, 20, 30 };

    public static int MACHINE_SEED_LEVEL = 0;
    public static int MACHINE_SEED_CAPACITY = 0;
    public static int MACHINE_SEED_CHEST = 0;
    #endregion

    #region RESIN_SPIT
    public static int[] RESIN_SPIT_DAMAGE = { 10 };
    public static float[] RESIN_SPIT_SPEED = { 10 };
    public static float[] RESIN_SPIT_DURATION = { 10, 20 };
    public static int[] RESIN_SPIT_STICKNESS = { 10, 20 };

    public static int RESIN_SPIT_LEVEL = 0;
    public static int RESIN_SPIT_CAPACITY = 0;
    public static int RESIN_SPIT_CHEST = 0;
    #endregion

    #region S_SEEDNIPER
    public static int[] S_SEEDNIPER_DAMAGE = { 10, 20 };
    public static float[] S_SEEDNIPER_SPEED = { 10, 20, 30 };
    public static int[] S_SEEDNIPER_RICOCHET = { 10 };

    public static int S_SEEDNIPER_LEVEL = 0;
    public static int S_SEEDNIPER_CAPACITY = 0;
    public static int S_SEEDNIPER_CHEST = 0;
    #endregion

    #region PINECONE_LAUNCHER
    public static int[] PINECONE_LAUNCHER_AREA = { 10 };
    public static int[] PINECONE_LAUNCHER_DAMAGE = { 10 };
    public static float[] PINECONE_LAUNCHER_SPEED = { 10 };
    public static float[] PINECONE_LAUNCHER_RANGE = { 10 };
    public static int[] PINECONE_LAUNCHER_DAMAGE_STUN = { 10 };
    public static int[] PINECONE_LAUNCHER_CLUSTER = { 10 };

    public static int PINECONE_LAUNCHER_LEVEL = 0;
    public static int PINECONE_LAUNCHER_CAPACITY = 0;
    public static int PINECONE_LAUNCHER_CHEST = 0;
    #endregion

    #region PHOTOSYNTHETIC_LASER
    public static int[] PHOTOSYNTHETIC_LASER_DAMAGE = { 10, 20 };
    public static float[] PHOTOSYNTHETIC_LASER_RANGO = { 10, 20 };
    public static int[] PHOTOSYNTHETIC_LASER_OBJETIVOS = { 10, 20 };

    public static int PHOTOSYNTHETIC_LASER_LEVEL = 0;
    public static int PHOTOSYNTHETIC_LASER_CAPACITY = 0;
    public static int PHOTOSYNTHETIC_LASER_CHEST = 0;
    #endregion

    #region NUT_ROLL
    public static int[] NUT_ROLL_DAMAGE = { 10, 20 };
    public static float[] NUT_ROLL_SPEED = { 10, 20 };
    public static int[] NUT_ROLL_EXTRA = { 10 };
    public static int[] NUT_ROLL_HITS = { 10 };

    public static int NUT_ROLL_LEVEL = 0;
    public static int NUT_ROLL_CAPACITY = 0;
    public static int NUT_ROLL_CHEST = 0;
    #endregion

    #region CARNIVOROUS
    public static int[] CARNIVOROUS_SALIVA = { 10 };
    public static int[] CARNIVOROUS_DAMAGE = { 10 };
    public static float[] CARNIVOROUS_SPEED = { 10, 20, 30 };
    public static int[] CARNIVOROUS_HEADS = { 10 };

    public static int CARNIVOROUS_LEVEL = 0;
    public static int CARNIVOROUS_CAPACITY = 0;
    public static int CARNIVOROUS_CHEST = 0;
    #endregion

    #region PORCUTHROW
    public static int[] PORCUTHROW_PROJECTILES = { 10, 20, 30 };
    public static float[] PORCUTHROW_SPEED = { 10, 20 };
    public static int[] PORCUTHROW_PIERCING = { 10 };

    public static int PORCUTHROW_LEVEL = 0;
    public static int PORCUTHROW_CAPACITY = 0;
    public static int PORCUTHROW_CHEST = 0;
    #endregion

    #region ELECTRIC_POTATO
    public static int[] ELECTRIC_POTATO_RAY = { 10, 20 };
    public static int[] ELECTRIC_POTATO_DAMAGE = { 10 };
    public static float[] ELECTRIC_POTATO_SPEED = { 10 };
    public static int[] ELECTRIC_POTATO_STUN = { 10, 20 };

    public static int ELECTRIC_POTATO_LEVEL = 0;
    public static int ELECTRIC_POTATO_CAPACITY = 0;
    public static int ELECTRIC_POTATO_CHEST = 0;
    #endregion

    #region FLAMEPEPPET
    public static int[] FLAMEPEPPET_CONE = { 10, 20 };
    public static int[] FLAMEPEPPET_RANGO = { 10 };
    public static int[] FLAMEPEPPET_DAMAGE = { 10, 20, 30 };

    public static int FLAMEPEPPET_LEVEL = 0;
    public static int FLAMEPEPPET_CAPACITY = 0;
    public static int FLAMEPEPPET_CHEST = 0;
    #endregion

    #endregion

    #region PLAYER
    public static int[] PLAYER_SPEED = { 10, 20, 30 };
    public static int[] PLAYER_INVENTORY = { 10, 20, 30 };
    public static int[] PLAYER_CAPACITY = { 10, 20, 30 };
    public static int[] PLAYER_LIFT = { 10 };
    #endregion



}
