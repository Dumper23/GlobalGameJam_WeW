using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorcuthrowTurret : TurretsFather
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

        GameObject bul = BulletPool.bulletPoolInstance.GetPorcuthrow();
        bul.transform.position = GetBulletSpawnPoint().position;

        bul.SetActive(true);
        bul.GetComponent<PorcuthrowBullet>().SetTarget(base.currentTarget.transform);
        bul.GetComponent<PorcuthrowBullet>().SetDamage(base.damage);
        ammunituion--;
    }
}
