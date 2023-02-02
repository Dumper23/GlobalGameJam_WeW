using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResinTurret : TurretsFather
{
    [SerializeField]
    private float resinDuration, slowness;
    private float startTime;

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
    private void OnEnable()
    {
        PlaceTurret();
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
        resinBullet.GetComponent<ResinBullet>().SetDuration(resinDuration);
        resinBullet.GetComponent<ResinBullet>().SetDamage(damage);
        resinBullet.GetComponent<ResinBullet>().SetSlowness(slowness);
        startTime = Time.time;
        lastShot = Time.time + resinDuration;
        iShooting = true;
    }

    protected override void FaceObjective()
    {
        //None
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
                case "stick":
                    if (stat.Value != 0)
                    {
                        slowness = stat.Value;
                    }
                    break;
            }
        }
    }

    public override void SetTraits(int newmaxAmmo, int newDamage, float newFireRate, bool extra = false, float durationResin = -1)
    {
        maxAmmo = newmaxAmmo;
        damage = newDamage;
        fireRate = newFireRate;
        resinDuration = durationResin;
    }
}
