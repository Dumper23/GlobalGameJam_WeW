using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave
{
    public EnemyWave(int totalEnemies, string enemyId, float enemySpawnRate, float delay, int enemyAmountPerSpawn, string spawnId)
    {
        this.totalEnemies = totalEnemies;
        this.enemyId = enemyId;
        this.spawnId = spawnId;
        this.enemyAmountPerSpawn = enemyAmountPerSpawn;
        this.delay = delay;
        this.enemySpawnRate = enemySpawnRate;
    }

    public int totalEnemies;
    public string enemyId;
    public string spawnId;
    public float enemySpawnRate;
    public float delay;
    public int enemyAmountPerSpawn;
}