using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedniperTurret : TurretsFather
{
    [Header("Seedniper Default Stats")]
    [SerializeField]
    private bool ricochet = false;

    private GameObject secondTarget;
    private void Awake()
    {
        turretId = "S_SEEDNIPER";
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

        GameObject bul = BulletPool.bulletPoolInstance.GetSeedniper();
        bul.transform.position = GetBulletSpawnPoint().position;

        bul.SetActive(true);
        bul.GetComponent<SeedniperBullet>().SetTarget(base.currentTarget.transform);
        if (ricochet) {
            bul.GetComponent<SeedniperBullet>().SetTarget2(secondTarget.transform);
        }
        bul.GetComponent<SeedniperBullet>().SetDamage(base.damage);
        bul.GetComponent<SeedniperBullet>().SetRicochet(ricochet);
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
                    chestIndicators[maxChest - 1].SetActive(true);
                    chestIndicators[maxChest - 1].GetComponent<SpriteRenderer>().color = Color.red;
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
        if (d.TryGetValue("ricochetLevel", out float LRicochet))
        {
            if (LRicochet != 0)
            {
                if (d.TryGetValue("speed", out float newRicochet))
                {
                    if ((int)newRicochet == 0)
                    {
                        ricochet = false;
                    }
                    if ((int)newRicochet == 1)
                    {
                        ricochet = true;
                    }
                }
            }
        }
    }

    /*public override void SetTraits(int newmaxAmmo, int newDamage, float newFireRate, bool newRicochet = false, float none = -1, float none1 = -1, float none2 = -1)
    {
        maxAmmo = newmaxAmmo;
        damage = newDamage;
        fireRate = newFireRate;
        ricochet = newRicochet;
    }*/

    protected override void DetectObjective()
    {
        //FIRST TARGET
        #region 1st
        int closestPos = -1;
        float closestDistance = Mathf.Infinity;
        int posIterator = 0;
        
        foreach (GameObject o in enemyList)
        {

            if (o != null && o.activeInHierarchy)
            {
                if (IsInRange(o) && o.GetComponent<Enemy>().type == "fly")
                {

                    if (closestDistance > Vector2.Distance(endWayPoint.position, o.transform.position))
                    {
                        closestDistance = Vector2.Distance(endWayPoint.position, o.transform.position);
                        closestPos = posIterator;
                    }
                }
            }
            posIterator++;

        }
        if (closestPos != -1)
        {
            //Attack fly
            currentTarget = enemyList[closestPos];
        }
        else
        {
            currentTarget = null;
            closestPos = -1;
            closestDistance = Mathf.Infinity;
            posIterator = 0;
            foreach (GameObject o in enemyList)
            {

                if (o != null && o.activeInHierarchy)
                {
                    if (IsInRange(o) && o.GetComponent<Enemy>().type == "walk")
                    {

                        if (closestDistance > Vector2.Distance(endWayPoint.position, o.transform.position))
                        {
                            closestDistance = Vector2.Distance(endWayPoint.position, o.transform.position);
                            closestPos = posIterator;
                        }
                    }
                }
                posIterator++;
            }
            if (closestPos != -1)
            {
                //Attack no fly
                currentTarget = enemyList[closestPos];
            }
            else
            {
                //No attack
                currentTarget = null;
            }
        }
        #endregion
        #region 2nd
        //SECOND TARGET
        if (currentTarget != null) {
            closestPos = -1;
            closestDistance = Mathf.Infinity;
            posIterator = 0;
            foreach (GameObject o in enemyList)
            {

                if (o != null && o.activeInHierarchy)
                {
                    if (o.gameObject != currentTarget.gameObject && IsInRange(o) && o.GetComponent<Enemy>().type == "fly")
                    {

                        if (closestDistance > Vector2.Distance(endWayPoint.position, o.transform.position))
                        {
                            closestDistance = Vector2.Distance(endWayPoint.position, o.transform.position);
                            closestPos = posIterator;
                        }
                    }
                }
                posIterator++;

            }
            if (closestPos != -1)
            {
                //Attack fly
                secondTarget = enemyList[closestPos];
            }
            else
            {
                secondTarget = null;
                closestPos = -1;
                closestDistance = Mathf.Infinity;
                posIterator = 0;
                foreach (GameObject o in enemyList)
                {

                    if (o != null && o.activeInHierarchy)
                    {
                        if (o.gameObject != currentTarget.gameObject && IsInRange(o) && o.GetComponent<Enemy>().type == "walk")
                        {

                            if (closestDistance > Vector2.Distance(endWayPoint.position, o.transform.position))
                            {
                                closestDistance = Vector2.Distance(endWayPoint.position, o.transform.position);
                                closestPos = posIterator;
                            }
                        }
                    }
                    posIterator++;

                }
                if (closestPos != -1)
                {
                    //Attack no fly
                    secondTarget = enemyList[closestPos];
                }
                else
                {
                    //No attack
                    secondTarget = null;
                }
            }
        }
        #endregion
        /*
         * base----
        foreach (GameObject o in enemyList)
        {
            if (o != null && o.activeInHierarchy)
            {
                if (o.gameObject != currentTarget.gameObject && IsInRange(o))
                {

                    if (closestDistance > Vector2.Distance(endWayPoint.position, o.transform.position))
                    {
                        closestDistance = Vector2.Distance(endWayPoint.position, o.transform.position);
                        closestPos = posIterator;
                    }
                }
            }
            posIterator++;
        }
        if (closestPos != -1)
        {
            //Attack
            secondTarget = enemyList[closestPos];
        }
        else
        {
            //No attack
            secondTarget = null;
        }*/
    }
}
