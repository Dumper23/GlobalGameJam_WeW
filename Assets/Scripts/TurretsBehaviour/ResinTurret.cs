using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResinTurret : TurretsFather
{
    [Header("Resin Default Stats")]

    [SerializeField]
    private float resinDuration;
    [SerializeField]
    private float slowness, length;
    private float startTime;

    [Header("Resin Settings")]

    [SerializeField]
    private GameObject resinBullet;

    private bool iShooting = false;
    private void Awake()
    {
        turretId = "RESIN_SPIT";
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (iShooting && Time.time > startTime + resinDuration)
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
        resinBullet.GetComponent<ResinBullet>().SetDuration(resinDuration);
        resinBullet.GetComponent<ResinBullet>().SetLength(length);
        resinBullet.SetActive(true);
        resinBullet.GetComponent<ResinBullet>().SetDamage(damage);
        resinBullet.GetComponent<ResinBullet>().SetSlowness(slowness);

        startTime = Time.time;
        lastShot = Time.time + resinDuration;
        iShooting = true;
    }
    protected override void DeactivateTurret()
    {
        //None
    }
    protected override void FaceObjective()
    {
        //None
    }
    protected override void InintiateStatsAtCurrentUpgrades()
    {
        Debug.Log(turretId);
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
        if (d.TryGetValue("sticknessLevel", out float LStickness))
        {
            if (LStickness != 0)
            {
                if (d.TryGetValue("stick", out float newStickness))
                {
                    slowness = newStickness;
                }
            }
        }
        if (d.TryGetValue("durationResinLevel", out float LDuration))
        {
            if (LDuration != 0)
            {
                if (d.TryGetValue("duration", out float newDuration))
                {
                    resinDuration = newDuration;
                }
            }
        }
        if (d.TryGetValue("lengthResinLevel", out float LLength))
        {
            if (LLength != 0)
            {
                if (d.TryGetValue("length", out float newLength))
                {
                    length = newLength;
                }
            }
        }
    }

    /*public override void SetTraits(int newmaxAmmo, int newDamage, float newFireRate, bool extra = false, float durationResin = -1, float newSize = -1, float newStickness = -1)
    {
        maxAmmo = newmaxAmmo;
        damage = newDamage;
        fireRate = newFireRate;
        resinDuration = durationResin;
        length = newSize;
        slowness = newStickness;
    }*/
}
