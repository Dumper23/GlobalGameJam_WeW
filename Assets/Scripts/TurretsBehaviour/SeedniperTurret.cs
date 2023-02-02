using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedniperTurret : TurretsFather
{
    private bool ricochet = false;
    private void Awake()
    {
        turretId = "S_SEEDNIPER";
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

        GameObject bul = BulletPool.bulletPoolInstance.GetSeedniper();
        bul.transform.position = GetBulletSpawnPoint().position;

        bul.SetActive(true);
        bul.GetComponent<SeedniperBullet>().SetTarget(base.currentTarget.transform);
        bul.GetComponent<SeedniperBullet>().SetDamage(base.damage);
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
                case "ricochet":
                    if (stat.Value == 0)
                    {
                        ricochet = false;
                    }
                    if (stat.Value == 1)
                    {
                        ricochet = true;
                    }
                    break;
            }
        }
    }

    public override void SetTraits(int newmaxAmmo, int newDamage, float newFireRate, bool newRicochet = false, float none = -1)
    {
        maxAmmo = newmaxAmmo;
        damage = newDamage;
        fireRate = newFireRate;
        ricochet = newRicochet;
    }
}
