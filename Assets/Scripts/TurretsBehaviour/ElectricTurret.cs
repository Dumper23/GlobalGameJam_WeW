using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTurret : TurretsFather
{
    [Header("Electric Default Stats")]

    [SerializeField]
    private float stunness;

    [SerializeField]
    private int rayHits;

    private void Awake()
    {
        turretId = "ELECTRIC_POTATO";
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

        GameObject bul = BulletPool.bulletPoolInstance.GetElectric();
        bul.transform.position = GetBulletSpawnPoint().position;

        bul.GetComponent<ElectricBullet>().SetHitsRay(rayHits);
        bul.SetActive(true);
        bul.GetComponent<ElectricBullet>().SetTarget(base.currentTarget.transform);
        bul.GetComponent<ElectricBullet>().SetDamage(base.damage);
        bul.GetComponent<ElectricBullet>().SetStun(stunness);
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
        if (d.TryGetValue("rayLevel", out float LRay))
        {
            if (LRay != 0)
            {
                if (d.TryGetValue("ray", out float newRay))
                {
                    rayHits = (int)newRay;
                }
            }
        }
        if (d.TryGetValue("stunLevel", out float LStun))
        {
            if (LStun != 0)
            {
                if (d.TryGetValue("stun", out float newStun))
                {
                    stunness = newStun;
                }
            }
        }
    }

    /*public override void SetTraits(int newmaxAmmo, int newDamage, float newFireRate, bool extra = false, float newRayHits = -1, float newStun = -1, float none = -1)
    {
        maxAmmo = newmaxAmmo;
        damage = newDamage;
        fireRate = newFireRate;
        rayHits = (int)newRayHits;
        stunness = newStun;
    }*/
}
