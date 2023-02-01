using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResinTurret : TurretsFather
{
    [SerializeField]
    private float duration;
    private float startTime;

    [SerializeField]
    private GameObject resinBullet;

    private bool iShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (iShooting && Time.time > startTime + duration)
        {
            iShooting = false;
        }
    }

    protected override void Shoot()
    {
        //base.Shoot();

        //GameObject bul = BulletPool.bulletPoolInstance.GetResin();
        //bul.transform.position = GetBulletSpawnPoint().position;

        //bul.SetActive(true);
        //bul.GetComponent<ResinBullet>().SetTarget(base.currentTarget.transform);
        //bul.GetComponent<ResinBullet>().SetDamage(base.damage);
        ammunituion--;

        resinBullet.transform.position = GetBulletSpawnPoint().position;
        resinBullet.SetActive(true);
        resinBullet.GetComponent<ResinBullet>().SetDuration(duration);
        resinBullet.GetComponent<ResinBullet>().SetDamage(damage);
        startTime = Time.time;
        lastShot = Time.time + duration;
        iShooting = true;
    }

    public override void SetTraits(float newRangeAttack, float newFireRate, int newmaxAmmo, int newDamage, float durationResin = 0)
    {
        base.SetTraits(newRangeAttack, newFireRate, newmaxAmmo, newDamage);
        duration = durationResin;
    }
}
