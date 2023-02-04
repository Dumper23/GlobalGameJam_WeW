using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineconeTurret : TurretsFather
{
    [Header("Pinecone Default Stats")]

    [SerializeField]
    private bool cluster = false;
    [SerializeField]
    private float radius = 5;
    [SerializeField]
    private float stunness;

    private void Awake()
    {
        turretId = "PINECONE_LAUNCHER";
    }

    void Start()
    {
        //ammunituion = 5;
        //damage = 10;
        base.Start();

    }

    void Update()
    {
        base.Update();
    }

    protected override void Shoot()
    {
        base.Shoot();

        GameObject bul = BulletPool.bulletPoolInstance.GetPinecone();
        bul.transform.position = GetBulletSpawnPoint().position;

        bul.SetActive(true);
        bul.GetComponent<PineconeBullet>().SetTarget(base.currentTarget.transform);
        bul.GetComponent<PineconeBullet>().SetDamage(base.damage);
        bul.GetComponent<PineconeBullet>().SetRadius(radius);
        bul.GetComponent<PineconeBullet>().SetCluster(cluster);
        bul.GetComponent<PineconeBullet>().SetStunness(stunness);
        ammunituion--;
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
                    maxChest = (int)newChest;
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
        if (d.TryGetValue("areaLevel", out float LArea))
        {
            if (LArea != 0)
            {
                if (d.TryGetValue("area", out float newArea))
                {
                    radius = newArea;
                }
            }
        }
        if (d.TryGetValue("clusterLevel", out float LCluster))
        {
            if (LCluster != 0)
            {
                if (d.TryGetValue("cluster", out float newCluster))
                {
                    if ((int)newCluster == 0)
                    {
                        cluster = false;
                    }
                    if ((int)newCluster == 1)
                    {
                        cluster = true;
                    }
                }
            }
        }
        if (d.TryGetValue("damageStunLevel", out float LStun))
        {
            if (LStun != 0)
            {
                if (d.TryGetValue("stun", out float newStun))
                {
                    stunness = newStun;
                }
            }
        }
        if (d.TryGetValue("rangeLevel", out float LRange))
        {
            if (LRange != 0)
            {
                if (d.TryGetValue("range", out float newRange))
                {
                    rangeAttack = newRange;
                }
            }
        }

    }
    /*public override void SetTraits(int newmaxAmmo, int newDamage, float newRadius, bool newCluster = false, float none = -1, float none1 = -1, float none2 = -1)
    {
        maxAmmo = newmaxAmmo;
        damage = newDamage;
        radius = newRadius;
        cluster = newCluster;
    }*/
    protected override void DetectObjective()
    {
        int closestPos = -1;
        float closestDistance = Mathf.Infinity;
        int posIterator = 0;

        foreach (GameObject o in enemyList)
        {
            if (o != null && o.activeInHierarchy)
            {
                if (IsInRange(o))
                {

                    if (closestDistance > Vector2.Distance(transform.position, o.transform.position))
                    {
                        closestDistance = Vector2.Distance(transform.position, o.transform.position);
                        closestPos = posIterator;
                    }
                }
            }
            posIterator++;
        }
        if (closestPos != -1)
        {
            //Attack
            currentTarget = enemyList[closestPos];
        }
        else
        {
            //No attack
            currentTarget = null;
        }
    }
}
