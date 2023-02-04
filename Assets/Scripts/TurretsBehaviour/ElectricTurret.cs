using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTurret : TurretsFather
{

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
                case "ray":
                    if ((int)stat.Value != 0)
                    {
                        rayHits = (int)stat.Value;
                    }
                    break;
                case "stun":
                    if (stat.Value != 0)
                    {
                        stunness = stat.Value;
                    }
                    break;
            }
        }
    }

    public override void SetTraits(int newmaxAmmo, int newDamage, float newFireRate, bool extra = false, float newRayHits = -1, float newStun = -1, float none = -1)
    {
        maxAmmo = newmaxAmmo;
        damage = newDamage;
        fireRate = newFireRate;
        rayHits = (int)newRayHits;
        stunness = newStun;
    }
}
