using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;

    #region Seeds
    [SerializeField]
    private GameObject seedBullet;
    private bool notEnoughSeedsInPool = true;

    private List<GameObject> seeds;
    #endregion

    #region Resin
    [SerializeField]
    private GameObject resinBullet;
    private bool notEnoughResinsInPool = true;

    private List<GameObject> resins;
    #endregion

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

    public GameObject GetResin()
    {
        if (resins.Count > 0)
        {
            for (int i = 0; i < resins.Count; i++)
            {
                if (!resins[i].activeInHierarchy)
                {
                    return resins[i];
                }
            }
        }

        if (notEnoughResinsInPool)
        {
            GameObject bul = Instantiate(resinBullet);
            bul.SetActive(false);
            resins.Add(bul);
            return bul;
        }

        return null;
    }
}
