using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorcuthrowTurret : TurretsFather
{
    [SerializeField]
    private float startAngle = 0f, endAngle = 360f;

    [SerializeField]
    private int bulletsAmmount = 11;

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
