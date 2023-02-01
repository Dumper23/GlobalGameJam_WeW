using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTurret : TurretsFather
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

        GameObject bul = BulletPool.bulletPoolInstance.GetSeed();
        bul.transform.position = GetBulletSpawnPoint().position;

        bul.SetActive(true);
        bul.GetComponent<SeedBullet>().SetTarget(base.currentTarget.transform);
        bul.GetComponent<SeedBullet>().SetDamage(base.damage);
        ammunituion--;
    }
}
