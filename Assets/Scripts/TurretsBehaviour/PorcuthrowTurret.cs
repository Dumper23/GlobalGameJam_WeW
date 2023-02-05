using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorcuthrowTurret : TurretsFather
{
    [Header("Porcuthrow Default Stats")]

    [SerializeField]
    private int bulletsAmmount = 11;

    [SerializeField]
    private bool piercing = false;

    [Header("Porcuthrow Settings")]
    [SerializeField]
    private float startAngle = 0f;
    [SerializeField]
    private float endAngle = 360f;

    private void Awake()
    {
        turretId = "PORCUTHROW";
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

        float angleStep = (endAngle - startAngle) / bulletsAmmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmmount + 1; i++)
        {
            float bulDirX = GetBulletSpawnPoint().position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = GetBulletSpawnPoint().position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector3 bulDir = (bulMoveVector - GetBulletSpawnPoint().position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetPorcuthrow();
            bul.transform.position = GetBulletSpawnPoint().position;

            bul.SetActive(true);
            bul.GetComponent<PorcuthrowBullet>().SetTarget(base.currentTarget.transform);
            bul.GetComponent<PorcuthrowBullet>().SetDamage(base.damage);
            bul.GetComponent<PorcuthrowBullet>().SetPiercing(piercing);

            Vector3 facingDir = -GetBulletSpawnPoint().up.normalized;

            float angleAux = Vector3.Angle(bulDir, new Vector3(1, 0, 0));
            if (bulDir.y < 0)
            {
                angleAux = 360 - angleAux;
            }

            //bul.GetComponent<PorcuthrowBullet>().UpdateNewDirection(bulDir);
            bul.GetComponent<PorcuthrowBullet>().UpdateNewDirection((Quaternion.AngleAxis(angleAux, Vector3.forward)* facingDir).normalized);
            angle += angleStep;
        }
        ammunituion--;
    }
    protected override void InintiateStatsAtCurrentUpgrades()
    {
        Dictionary<string, float> d = GameManager.Instance.getTurretInfo(turretId);

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
                    if (maxChest != (int)newChest)
                    {
                        maxChest = (int)newChest;
                        chestIndicators[maxChest - 1].SetActive(true);
                        chestIndicators[maxChest - 1].GetComponent<SpriteRenderer>().color = Color.red;
                    }
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
        if (d.TryGetValue("projectilesLevel", out float LProjectiles))
        {
            if (LProjectiles != 0)
            {
                if (d.TryGetValue("projectiles", out float newProjectiles))
                {
                    bulletsAmmount = (int)newProjectiles - 1;
                }
            }
        }
        if (d.TryGetValue("piercingLevel", out float LPiercing))
        {
            if (LPiercing != 0)
            {
                if (d.TryGetValue("piercing", out float newPiercing))
                {
                    if ((int)newPiercing == 0)
                    {
                        piercing = false;
                    }
                    if ((int)newPiercing == 1)
                    {
                        piercing = true;
                    }
                }
            }
        }
    }
    /*public override void SetTraits(int newmaxAmmo, int newProjectiles, float newFireRate, bool newPiercing = false, float none = -1, float none1 = -1, float none2 = -1)
    {
        maxAmmo = newmaxAmmo;
        bulletsAmmount = newProjectiles;
        fireRate = newFireRate;
        piercing = newPiercing;
    }*/
    protected override void DetectObjective()
    {
        int closestPos = -1;
        float closestDistance = Mathf.Infinity;
        int posIterator = 0;

        foreach (GameObject o in enemyList)
        {
            if (o != null && o.activeInHierarchy)
            {
                if (IsInRange(o))
                {

                    if (closestDistance > Vector2.Distance(transform.position, o.transform.position))
                    {
                        closestDistance = Vector2.Distance(transform.position, o.transform.position);
                        closestPos = posIterator;
                    }
                }
            }
            posIterator++;
        }
        if (closestPos != -1)
        {
            //Attack
            currentTarget = enemyList[closestPos];
        }
        else
        {
            //No attack
            currentTarget = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
        Gizmos.DrawLine(GetBulletSpawnPoint().position, (GetBulletSpawnPoint().position - GetBulletSpawnPoint().right));
        Gizmos.color = Color.red;
        float angleStep = (endAngle - startAngle) / bulletsAmmount; 
        float angle = startAngle;

        for (int i = 0; i < bulletsAmmount + 1; i++)
        {
            float bulDirX = GetBulletSpawnPoint().position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = GetBulletSpawnPoint().position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector3 bulDir = (bulMoveVector - GetBulletSpawnPoint().position).normalized;

           
            

            Vector3 facingDir = -GetBulletSpawnPoint().up.normalized;

            float angleAux = Vector3.Angle(bulDir, new Vector3(1, 0, 0));
            if (bulDir.y < 0)
            {
                angleAux = 360 - angleAux;
            }

            //bul.GetComponent<PorcuthrowBullet>().UpdateNewDirection(bulDir);
            Gizmos.DrawLine(GetBulletSpawnPoint().position, GetBulletSpawnPoint().position + (Quaternion.AngleAxis(angleAux, Vector3.forward) * facingDir).normalized);
            angle += angleStep;
        }

    }
}
