using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutRollTurret : TurretsFather
{
    [Header("NutRoll Default Stats")]

    [SerializeField]
    private int hits = 10;

    [SerializeField]
    private bool extra = false;

    /*
    [Header("NutRoll Settings")]

    [SerializeField]
    private List<Transform> waypoints;*/

    private void Awake()
    {
        turretId = "NUT_ROLL";
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    protected override void Shoot()
    {
        base.Shoot();

        GameObject bul = BulletPool.bulletPoolInstance.GetNut();
        bul.transform.position = GetBulletSpawnPoint().position;
        /*
        int pos = 0;
        bool found = false;
        foreach (Transform w in waypoints)
        {
            if (!found) {
                if (w.position.y > GetBulletSpawnPoint().position.y)
                {
                    found = true;
                }
                else
                {
                    pos++;
                }
            }
        }*/
        bul.SetActive(true);
        bul.GetComponent<NutBullet>().SetHits(hits);
        bul.GetComponent<NutBullet>().SetDamage(base.damage);
        //bul.GetComponent<NutBullet>().DetermineRoute(waypoints, pos-1);
        if (extra)
        {
            Invoke("ExtraShoot", 0.5f);
        }
        ammunituion--;
    }
    private void ExtraShoot()
    {
        GameObject bul = BulletPool.bulletPoolInstance.GetNut();
        bul.transform.position = GetBulletSpawnPoint().position;
        /*
        int pos = 0;
        bool found = false;
        foreach (Transform w in waypoints)
        {
            if (!found) {
                if (w.position.y > GetBulletSpawnPoint().position.y)
                {
                    found = true;
                }
                else
                {
                    pos++;
                }
            }
        }*/
        bul.SetActive(true);
        bul.GetComponent<NutBullet>().SetHits(hits);
        bul.GetComponent<NutBullet>().SetDamage(base.damage);
        //bul.GetComponent<NutBullet>().DetermineRoute(waypoints, pos-1);
    }
    /*
    public void SetWaypointsList(List<GameObject> newEnemyList)
    {
        enemyList = new List<GameObject>(newEnemyList);
    }
    */
    protected override void DeactivateTurret()
    {
        //None
    }

    protected override void FaceObjective()
    {
        //None
    }
    protected override void InintiateStatsAtCurrentUpgrades()
    {
        Dictionary<string, float> d = GameManager.Instance.getTurretInfo(turretId);

        if (d.TryGetValue("damageLevel", out float LDamage))
        {
            if (LDamage != 0)
            {
                if (d.TryGetValue("damage", out float newDamage))
                {
                    damage = (int)newDamage;
                }
            }
        }
        if (d.TryGetValue("capacityLevel", out float LCapacity))
        {
            if (LCapacity != 0)
            {
                if (d.TryGetValue("capacity", out float newCapacity))
                {
                    maxAmmo = (int)newCapacity;
                }
            }
        }
        if (d.TryGetValue("chestLevel", out float LChest))
        {
            if (LChest != 0)
            {
                if (d.TryGetValue("chest", out float newChest))
                {
                    if (maxChest != (int)newChest)
                    {
                        maxChest = (int)newChest;
                        chestIndicators[maxChest - 1].SetActive(true);
                        chestIndicators[maxChest - 1].GetComponent<SpriteRenderer>().color = Color.red;
                    }
                }
            }
        }
        if (d.TryGetValue("speedLevel", out float LSpeed))
        {
            if (LSpeed != 0)
            {
                if (d.TryGetValue("speed", out float newSpeed))
                {
                    fireRate = newSpeed;
                }
            }
        }
        if (d.TryGetValue("hitsLevel", out float LHits))
        {
            if (LHits != 0)
            {
                if (d.TryGetValue("hits", out float newHits))
                {
                    hits = (int)newHits;
                }
            }
        }
        if (d.TryGetValue("extraLevel", out float LExtra))
        {
            if (LExtra != 0)
            {
                if (d.TryGetValue("extra", out float newExtra))
                {
                    if ((int)newExtra == 0)
                    {
                        extra = false;
                    }
                    if ((int)newExtra == 1)
                    {
                        extra = true;
                    }
                }
            }
        }
    }

    /*public override void SetTraits(int newmaxAmmo, int newDamage, float newFireRate, bool newExtra = false, float newHits = -1, float none = -1, float none1 = -1)
    {
        maxAmmo = newmaxAmmo;
        damage = newDamage;
        fireRate = newFireRate;
        extra = newExtra;
        hits = (int)newHits;
    }*/
}
