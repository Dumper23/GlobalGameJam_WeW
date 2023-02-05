using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTurret : TurretsFather
{
    private void Awake()
    {
        turretId = "MACHINE_SEED";
    }

    private void Start()
    {
        //ammunituion = 5;
        //damage = 10;
        base.Start();
    }

    private void Update()
    {
        base.Update();
    }

    protected override void Shoot()
    {
        base.Shoot();

        GameObject bul = BulletPool.bulletPoolInstance.GetSeed();
        bul.transform.position = GetBulletSpawnPoint().position;

        bul.SetActive(true);
        bul.GetComponent<SeedBullet>().SetTarget(base.currentTarget.transform);
        bul.GetComponent<SeedBullet>().SetDamage(base.damage);
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
    }

    /*public override void SetTraits(int newmaxAmmo, int newDamage, float newFireRate, bool extra = false, float none = -1, float none1 = -1, float none2 = -1)
    {
        maxAmmo = newmaxAmmo;
        damage = newDamage;
        fireRate = newFireRate;
    }*/
}