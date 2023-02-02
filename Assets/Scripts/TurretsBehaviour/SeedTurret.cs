using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTurret : TurretsFather
{
    private void Awake()
    {
        turretId = "MACHINE_SEED";
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

    private void OnEnable()
    {
        PlaceTurret();
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

        foreach (KeyValuePair<string, float> stat in d)
        {
            switch (stat.Key)
            {
                case "capacity":
                    maxAmmo = (int)stat.Value;
                    break;
                case "damage":
                    damage = (int)stat.Value;
                    break;
                case "speed":
                    fireRate = stat.Value;
                    break;
            }
        }
    }

    public override void SetTraits(int newmaxAmmo, int newDamage, float newFireRate, bool extra = false, float none = -1)
    {
        maxAmmo = newmaxAmmo;
        damage = newDamage;
        fireRate = newFireRate;
    }
}
