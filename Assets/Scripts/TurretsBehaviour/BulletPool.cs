using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;

    [SerializeField]
    private GameObject seedBullet;
    private bool notEnoughSeedsInPool = true;

    private List<GameObject> seeds;

    private void Awake()
    {
        bulletPoolInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        seeds = new List<GameObject>();
    }

    public GameObject GetSeed()
    {
        if (seeds.Count > 0)
        {
            for (int i = 0; i < seeds.Count; i++)
            {
                if (!seeds[i].activeInHierarchy)
                {
                    return seeds[i];
                }
            }
        }

        if (notEnoughSeedsInPool)
        {
            GameObject bul = Instantiate(seedBullet);
            bul.SetActive(false);
            seeds.Add(bul);
            return bul;
        }

        return null;
    }
}
