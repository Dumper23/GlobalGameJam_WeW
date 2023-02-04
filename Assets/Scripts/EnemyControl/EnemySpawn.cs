using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string enemyId;
    public GameObject objectToPool;
    public int amountToPool;
    public List<GameObject> pooledObjects;
}

public class EnemyWaveState
{
    public int totalEnemies;
    public int numSpawned;
    public bool waveActive;
    public float counter;
    public string enemyId;
    public float spawnRate;
    public int amount;
    public float delay;
    public bool completed;

    public EnemyWaveState(int totalEnemies, int numSpawned, bool waveActive, float counter, string enemyId, float spawnRate, int amount, float delay, bool completed)
    {
        this.totalEnemies = totalEnemies;
        this.numSpawned = numSpawned;
        this.waveActive = waveActive;
        this.counter = counter;
        this.enemyId = enemyId;
        this.spawnRate = spawnRate;
        this.amount = amount;
        this.delay = delay;
        this.completed = completed;
    }
}



[System.Serializable]
public class EnemySpawn : MonoBehaviour
{
    public List<Pool> pools;
    public string id;
    public float area;

    public static int AREA_RANGE = 5;

    private bool isActive = false;
    private List<EnemyWave> enemyWaves = new List<EnemyWave>();
    private List<EnemyWaveState> enemyWaveStates = new List<EnemyWaveState>();
    
    // Start is called before the first frame update
    void Start()
    {
        //Create pools
        foreach (var pool in pools)
        {
            GameObject aux;
            for (int i = 0; i < pool.amountToPool; i++)
            {
                aux = Instantiate(pool.objectToPool);
                aux.transform.parent = GameObject.Find("Enemies").transform;
                aux.SetActive(false);
                pool.pooledObjects.Add(aux);
                GameManager.Instance.allEnemies.Add(aux);
            }
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if (isActive) //and not paused
        {
            foreach (EnemyWaveState enemyWaveState in enemyWaveStates)
            {
                if (!enemyWaveState.completed)
                {
                    if (!enemyWaveState.waveActive)
                    {
                        enemyWaveState.counter += Time.deltaTime;
                        if (enemyWaveState.counter >= enemyWaveState.delay && !enemyWaveState.waveActive)
                        {
                            enemyWaveState.waveActive = true;
                            enemyWaveState.counter = enemyWaveState.spawnRate;
                        }
                    }
                    else
                    {
                        enemyWaveState.counter += Time.deltaTime;
                        if (enemyWaveState.counter >= enemyWaveState.spawnRate)
                        {
                            spawnEnemy(getPoolIndex(enemyWaveState.enemyId), enemyWaveState);
                            enemyWaveState.counter = 0;
                        }
                    }
                }
                else
                {
                    if (checkAllWavesCompleted() && checkAllEnemiesDeactivated())
                    {
                        //go to night
                        GameManager.Instance.changeDayState();
                        return;
                    }
                }
            }
        }
    }

    public void spawnEnemy(int poolIndex, EnemyWaveState enemyWaveState)
    {
        if(poolIndex >= 0)
        {
            for (int i = 0; i < enemyWaveState.amount; i++)
            {
                if(enemyWaveState.numSpawned < enemyWaveState.totalEnemies)
                {
                    GameObject enemy = getPooledObject(poolIndex);
                    enemy.transform.position = getRandomPoint(transform.position);
                    enemy.GetComponent<Enemy>().initialize();
                    enemy.SetActive(true);
                    enemyWaveState.numSpawned++;
                }
                else
                {
                    enemyWaveState.completed = true;
                }
            }
        }
    }

    public GameObject getPooledObject(int poolIndex)
    {
        for (int i = 0; i < pools[poolIndex].amountToPool; i++)
        {
            if (!pools[poolIndex].pooledObjects[i].activeInHierarchy)
            {
                return pools[poolIndex].pooledObjects[i];
            }
        }

        GameObject aux = Instantiate(pools[poolIndex].objectToPool);
        aux.transform.parent = GameObject.Find("Enemies").transform;
        aux.SetActive(false);
        pools[poolIndex].pooledObjects.Add(aux);
        GameManager.Instance.allEnemies.Add(aux);
        return aux;
    }

    public void activateSpawn()
    {
        isActive = true;
        enemyWaves = GameManager.Instance.getCurrentDayWavesSpawn(id);
        enemyWaveStates.Clear();
        //initialize enemyWaveStates
        foreach (EnemyWave enemywave in enemyWaves)
        {
            EnemyWaveState state = new EnemyWaveState(enemywave.totalEnemies, 0, false, 0, enemywave.enemyId, enemywave.enemySpawnRate, enemywave.enemyAmountPerSpawn, enemywave.delay, false);
            enemyWaveStates.Add(state);
        }
    }

    public void deactivateSpawn()
    {
        isActive = false;
    }

    public int getPoolIndex(string enemyId)
    {
        return pools.IndexOf(pools.Find((x) => x.enemyId == enemyId));
    }

    private Vector3 getRandomPoint(Vector3 center)
    {
        return center + new Vector3((Random.value - 0.5f) * AREA_RANGE, (Random.value - 0.5f) * AREA_RANGE, 0);
    }
    
    private bool checkAllWavesCompleted()
    {
        foreach (EnemyWaveState wave in enemyWaveStates)
        {
            if (!wave.completed) return false;
        }
        return true;
    }

    private bool checkAllEnemiesDeactivated()
    {
        foreach (Pool pool in pools)
        {
            foreach (GameObject enemy in pool.pooledObjects)
            {
                if (enemy.activeInHierarchy) return false;
            }
        }
        return true;
    }

    void OnDrawGizmosSelected()
    {
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.up, AREA_RANGE);
    }
}
