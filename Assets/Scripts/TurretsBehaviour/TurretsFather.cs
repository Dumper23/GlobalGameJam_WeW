using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretsFather : MonoBehaviour
{
    //private bool inRange;
    //private bool hasAmmo;
    //protected bool hasAmmo;
    //protected bool inRange;
    [SerializeField]
    protected float rangeAttack, fireRate;
    private float lastShot;

    protected int ammunituion;

    protected GameObject currentTarget;

    [SerializeField]//TMP
    protected List<GameObject> enemyList;

    [SerializeField]
    private Transform bulletSpawn;

    [SerializeField]
    private GameObject mobilePart;

    // Start is called before the first frame update
    protected void Start()
    {
        //Set Default settings

    }

    // Update is called once per frame
    protected void Update()
    {

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
        }
        DetectObjective();
    }

    public void SetEnemyList(List<GameObject> newEnemyList)
    {
        enemyList = new List<GameObject>(newEnemyList);
    }

    protected bool HasAmmo()
    {
        return (ammunituion > 0) ;
    }

    private bool CanShoot()
    {
        return (Time.time >= lastShot + fireRate);
    }

    protected void FaceObjective()
    {
        Vector2 direction = (Vector2)currentTarget.transform.position - (Vector2)mobilePart.transform.position;

        direction.Normalize();

        mobilePart.transform.rotation = Quaternion.LookRotation(direction, Vector3.back) * Quaternion.Euler(90, 0 , -90);

    }

    protected void DetectObjective()
    {
        int closestPos = -1;
        float closestDistance = Mathf.Infinity;
        int posIterator = 0;

        foreach (GameObject o in enemyList)
        {
            if (IsInRange(o)) {
                //TMP DESDE LA TORRETA
                if (closestDistance > Vector2.Distance(transform.position, o.transform.position))
                {
                    closestDistance = Vector2.Distance(transform.position, o.transform.position);
                    closestPos = posIterator;
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

    private bool IsInRange(GameObject target)
    {
        return (Vector3.Distance(target.transform.position, gameObject.transform.position) < rangeAttack);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }
}
