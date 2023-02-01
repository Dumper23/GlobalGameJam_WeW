using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public GameObject objectToPool;
    public int amountToPool;
    public float spawnRate;
    public List<GameObject> pooledObjects;
}

[System.Serializable]
public class EnemySpawn : MonoBehaviour
{
    public Pool[] pools;

    private float[] counters;

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
                aux.SetActive(false);
                pool.pooledObjects.Add(aux);
            }
        }

        //Initialize counters
        counters = new float[pools.Length];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            counters[i] += Time.deltaTime;

            if (counters[i] >= pools[i].spawnRate)
            {
                spawnEnemy(i);
                counters[i] = 0;
            }
        }
    }

    public void spawnEnemy(int poolIndex)
    {
        GameObject enemy = getPooledObject(poolIndex);
        enemy.transform.position = transform.position;
        enemy.GetComponent<Enemy>().waypointIndex = 0;
        enemy.GetComponent<Enemy>().currentHealth = enemy.GetComponent<Enemy>().maxHealth;
        enemy.SetActive(true);
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
        aux.SetActive(false);
        pools[poolIndex].pooledObjects.Add(aux);
        return aux;
    }
}
