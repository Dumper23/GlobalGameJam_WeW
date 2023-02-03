using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedniperTurret : TurretsFather
{
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

        foreach (KeyValuePair<string, float> stat in d)
        {
            switch (stat.Key)
            {
                case "capacity":
                    if ((int)stat.Value != 0)
                    {
                        maxAmmo = (int)stat.Value;
                    }
                    break;
                case "damage":
                    if ((int)stat.Value != 0)
                    {
                        damage = (int)stat.Value;
                    }
                    break;
                case "speed":
                    if (stat.Value != 0)
                    {
                        fireRate = stat.Value;
                    }
                    break;
                case "ricochet":
                    if (stat.Value == 0)
                    {
                        ricochet = false;
                    }
                    if (stat.Value == 1)
                    {
                        ricochet = true;
                    }
                    break;
            }
        }
    }

    public override void SetTraits(int newmaxAmmo, int newDamage, float newFireRate, bool newRicochet = false, float none = -1, float none1 = -1, float none2 = -1)
    {
        maxAmmo = newmaxAmmo;
        damage = newDamage;
        fireRate = newFireRate;
        ricochet = newRicochet;
    }

    protected override void DetectObjective()
    {
        base.DetectObjective();

        int closestPos = -1;
        float closestDistance = Mathf.Infinity;
        int posIterator = 0;

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
        }
    }
}
