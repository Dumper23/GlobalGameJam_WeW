using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretsFather : MonoBehaviour
{

    #region traits
    [SerializeField]//TMP XQ EXTERN
    protected float rangeAttack, fireRate;
    [SerializeField]//TMP XQ EXTERN
    protected int ammunituion, damage, maxAmmo;
    #endregion

    protected float lastShot = 0;

    protected GameObject currentTarget;

    [SerializeField]//TMP
    protected List<GameObject> enemyList;

    [SerializeField]
    private Transform bulletSpawn;

    [SerializeField]
    private GameObject mobilePart;

    [SerializeField]//TMP
    protected Transform endWayPoint;

    protected string turretId = "";

    // Start is called before the first frame update
    protected void Start()
    {
        //Set Default settings

    }

    // Update is called once per frame
    protected void Update()
    {
        //TODO: FER CARTUTXOS I AMMO
        if (HasAmmo())
        {
            DetectObjective();
            
            if (HaveTarget())
            {
                FaceObjective();
                if (CanShoot())
                {
                    Shoot();
                }
                else
                {
                    //wait firerate
                }
            }
            else
            {
                //no target
            }
        }
        else
        {
            //desactivada
            //set active panell
            mobilePart.transform.rotation = Quaternion.Euler(0, 0, 45);
            //LerpValues.Lerp();
            //Quaternion.Slerp(mobilePart.transform.rotation, Quaternion.identity, Time.deltaTime / 10);
        }
    }

    public void SetEnemyList(List<GameObject> newEnemyList)
    {
        enemyList = new List<GameObject>(newEnemyList);
    }

    public void SetEndWaypoint(Transform end)
    {
        endWayPoint = end;
    }

    public string GetTurretId()
    {
        return turretId;
    }

    public abstract void SetTraits(int newmaxAmmo, int newDamage, float newFireRate, bool extra = false, float durationResin = -1);//RangeAttack?

    protected abstract void InintiateStatsAtCurrentUpgrades();

    protected bool HasAmmo()
    {
        return (ammunituion > 0) ;
    }

    public void GiveAmmo(int ammo)
    {
        ammunituion += ammo;
        //set deactive panell
    }

    public void PlaceTurret()
    {
        //maybe set active?
        ammunituion = 0;
        //check lvls
        InintiateStatsAtCurrentUpgrades();
    }

    private bool CanShoot()
    {
        return (Time.time >= lastShot + fireRate);
    }

    protected virtual void FaceObjective()
    {
        Vector2 direction = (Vector2)currentTarget.transform.position - (Vector2)mobilePart.transform.position;

        direction.Normalize();

        mobilePart.transform.rotation = Quaternion.LookRotation(direction, Vector3.back) * Quaternion.Euler(90, 0 , -90);

    }

    protected virtual void DetectObjective()
    {
        int closestPos = -1;
        float closestDistance = Mathf.Infinity;
        int posIterator = 0;

        foreach (GameObject o in enemyList)
        {
            if (o != null && o.activeInHierarchy) {
                if (IsInRange(o)) {

                    if (closestDistance > Vector2.Distance(endWayPoint.position, o.transform.position))
                    {
                        closestDistance = Vector2.Distance(endWayPoint.position, o.transform.position);
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

    private bool HaveTarget()
    {
        return (currentTarget != null && currentTarget.activeInHierarchy);
    }

    protected virtual void Shoot()
    {
        lastShot = Time.time;
    }

    protected Transform GetBulletSpawnPoint()
    {
        return bulletSpawn;
    }

    protected bool IsInRange(GameObject target)
    {
        return (Vector3.Distance(target.transform.position, gameObject.transform.position) < rangeAttack);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }
}
