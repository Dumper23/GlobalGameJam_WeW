using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedniperTurret : TurretsFather
{
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
        bul.GetComponent<SeedniperBullet>().SetDamage(base.damage);
        ammunituion--;
    }
}
