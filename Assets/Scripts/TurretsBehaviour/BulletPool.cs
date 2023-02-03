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
    /*
    #region Resin
    [SerializeField]
    private GameObject resinBullet;
    private bool notEnoughResinsInPool = true;

    private List<GameObject> resins;
    #endregion*/
    #region Seedsniper
    [SerializeField]
    private GameObject seedniperBullet;
    private bool notEnoughSeedsniperInPool = true;

    private List<GameObject> seedsniper;
    #endregion

    #region Seedsniper
    [SerializeField]
    private GameObject pineconeBullet;
    private bool notEnoughPineconesInPool = true;

    private List<GameObject> pinecones;
    #endregion

    #region Porcuthrow
    [SerializeField]
    private GameObject porcuthrowBullet;
    private bool notEnoughPorcuthrowsInPool = true;

    private List<GameObject> porcuthrows;
    #endregion

    #region Cluster
    [SerializeField]
    private GameObject clusterBullet;
    private bool notEnoughClustersInPool = true;

    private List<GameObject> clusters;
    #endregion

    #region NutRoll
    [SerializeField]
    private GameObject nutBullet;
    private bool notEnoughNutsInPool = true;

    private List<GameObject> nuts;
    #endregion

    private void Awake()
    {
        bulletPoolInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        seeds = new List<GameObject>();
        seedsniper = new List<GameObject>();
        pinecones = new List<GameObject>();
        porcuthrows = new List<GameObject>();
        nuts = new List<GameObject>();
        clusters = new List<GameObject>();
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
    /*
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
    }*/
    public GameObject GetSeedniper()
    {
        if (seedsniper.Count > 0)
        {
            for (int i = 0; i < seedsniper.Count; i++)
            {
                if (!seedsniper[i].activeInHierarchy)
                {
                    return seedsniper[i];
                }
            }
        }

        if (notEnoughSeedsniperInPool)
        {
            GameObject bul = Instantiate(seedniperBullet);
            bul.SetActive(false);
            seedsniper.Add(bul);
            return bul;
        }

        return null;
    }
    public GameObject GetPinecone()
    {
        if (pinecones.Count > 0)
        {
            for (int i = 0; i < pinecones.Count; i++)
            {
                if (!pinecones[i].activeInHierarchy)
                {
                    return pinecones[i];
                }
            }
        }

        if (notEnoughPineconesInPool)
        {
            GameObject bul = Instantiate(pineconeBullet);
            bul.SetActive(false);
            pinecones.Add(bul);
            return bul;
        }

        return null;
    }

    public GameObject GetPorcuthrow()
    {
        if (porcuthrows.Count > 0)
        {
            for (int i = 0; i < porcuthrows.Count; i++)
            {
                if (!porcuthrows[i].activeInHierarchy)
                {
                    return porcuthrows[i];
                }
            }
        }

        if (notEnoughPorcuthrowsInPool)
        {
            GameObject bul = Instantiate(porcuthrowBullet);
            bul.SetActive(false);
            porcuthrows.Add(bul);
            return bul;
        }

        return null;
    }
    
    public GameObject GetCluster()
    {
        if (clusters.Count > 0)
        {
            for (int i = 0; i < clusters.Count; i++)
            {
                if (!clusters[i].activeInHierarchy)
                {
                    return clusters[i];
                }
            }
        }

        if (notEnoughClustersInPool)
        {
            GameObject bul = Instantiate(clusterBullet);
            bul.SetActive(false);
            clusters.Add(bul);
            return bul;
        }

        return null;
    }

    public GameObject GetNut()
    {
        if (nuts.Count > 0)
        {
            for (int i = 0; i < nuts.Count; i++)
            {
                if (!nuts[i].activeInHierarchy)
                {
                    return nuts[i];
                }
            }
        }

        if (notEnoughNutsInPool)
        {
            GameObject bul = Instantiate(nutBullet);
            bul.SetActive(false);
            nuts.Add(bul);
            return bul;
        }

        return null;
    }
}
