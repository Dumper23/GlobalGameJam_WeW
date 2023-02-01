using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineconeTurret : TurretsFather
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

        GameObject bul = BulletPool.bulletPoolInstance.GetPinecone();
        bul.transform.position = GetBulletSpawnPoint().position;

        bul.SetActive(true);
        bul.GetComponent<PineconeBullet>().SetTarget(base.currentTarget.transform);
        bul.GetComponent<PineconeBullet>().SetDamage(base.damage);
        ammunituion--;
    }
}
