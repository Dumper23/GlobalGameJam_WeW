using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutRollTurret : TurretsFather
{
    [SerializeField]
    private int hits = 10;

    [SerializeField]
    private bool extra = false;

    private void Awake()
    {
        turretId = "NUT_ROLL";
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    private void OnEnable()
    {
        //PlaceTurret();
    }

    protected override void Shoot()
    {
        base.Shoot();

        GameObject bul = BulletPool.bulletPoolInstance.GetNut();
        bul.transform.position = GetBulletSpawnPoint().position;

        bul.SetActive(true);
        bul.GetComponent<NutBullet>().SetHits(hits);
        bul.GetComponent<NutBullet>().SetDamage(base.damage);
        ammunituion--;
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
                case "extra":
                    if (stat.Value == 0)
                    {
                        extra = false;
                    }
                    if (stat.Value == 1)
                    {
                        extra = true;
                    }
                    break;
                case "hits":
                    if ((int)stat.Value != 0)
                    {
                        hits = (int)stat.Value;
                    }
                    break;
            }
        }
    }

    public override void SetTraits(int newmaxAmmo, int newDamage, float newFireRate, bool newExtra = false, float newHits = -1)
    {
        maxAmmo = newmaxAmmo;
        damage = newDamage;
        fireRate = newFireRate;
        extra = newExtra;
        hits = (int)newHits;
    }
}