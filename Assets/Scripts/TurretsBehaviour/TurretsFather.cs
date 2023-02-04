using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class TurretsFather : MonoBehaviour
{
    #region traits

    //Coses carles
    public TextMeshProUGUI ammoLeftUI;

    public SpriteRenderer mobile;
    public SpriteRenderer fixedPart;

    public Sprite originalMobile;
    public Sprite originalFixed;
    public Sprite outlinedFixed;
    public Sprite outlinedMobile;

    public SpriteRenderer outOfOrtherSign;
    public Sprite inServiceSprite;
    public Sprite outOfOrtherSprite;

    public string ammoType;

    //--

    [Header("Default Stats")]

    [SerializeField]
    protected float fireRate;
    [SerializeField]
    protected float rangeAttack;

    [SerializeField]
    protected int damage, maxAmmo, maxChest;

    protected int ammunituion, chest;

    #endregion traits

    protected float lastShot = 0;

    protected GameObject currentTarget;

    protected List<GameObject> enemyList;

    [Header("Settings")]
    [SerializeField]
    private Transform bulletSpawn;

    [SerializeField]
    private GameObject mobilePart;

    protected Transform endWayPoint;

    protected string turretId = "";

    // Start is called before the first frame update
    protected void Start()
    {
        //Set Default settings
        enemyList = new List<GameObject>(GameManager.Instance.getAllEnemies());
        endWayPoint = GameManager.Instance.topFloor.transform.Find("waypoint").transform;
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
            //set active panell
            updateAmmoUI("0");
            DeactivateTurret();
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

    protected virtual void DeactivateTurret()
    {
        mobilePart.transform.rotation = Quaternion.Euler(0, 0, 45);
    }

    public abstract void SetTraits(int newmaxAmmo, int newDamage, float newFireRate, bool extra = false, float durationResin = -1, float size = -1, float stickness = -1);//RangeAttack?

    protected abstract void InintiateStatsAtCurrentUpgrades();

    protected bool HasAmmo()
    {
        if (ammunituion <= 0)
        {
            if (chest <= 0)
            {
                return false;
            }
            else
            {
                chest--;
                ammunituion = maxAmmo;
            }
        }
        updateAmmoUI((ammunituion).ToString());
        return true;
    }

    public bool GiveAmmo()
    {
        /*if (chest >= maxChest)
        {
            return false;
        }
        else
        {
            chest++;
            return true;
        }*/
        updateAmmoUI((ammunituion).ToString());

        if (chest < maxChest)
        {
            chest++;
            return true;
        }
        else
        {
            return false;
        }

        /*
        if (chest + newChests > maxChest)
        {
            chest = maxChest;
            return (chest + newChests) - maxChest;
        }
        else
        {
            if(chest + newChests <= maxChest)
            {
                chest += newChests;
                return 0;
            }
        }*/
        //ammunituion += ammo;
        //set deactive panell
    }

    private void updateAmmoUI(string newAmmo)
    {
        if (newAmmo.Equals("0"))
        {
            ammoLeftUI.SetText("");
            outOfOrtherSign.sprite = outOfOrtherSprite;
        }
        else
        {
            ammoLeftUI.SetText(newAmmo);
            outOfOrtherSign.sprite = inServiceSprite;
        }
    }

    public void PlaceTurret()
    {
        //maybe set active?
        ammunituion = 0;
        chest = 0;
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

        mobilePart.transform.rotation = Quaternion.LookRotation(direction, Vector3.back) * Quaternion.Euler(90, 0, -90);
    }

    protected virtual void DetectObjective()
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
        updateAmmoUI((ammunituion).ToString());
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

    public void UpdateDatabase()
    {
        InintiateStatsAtCurrentUpgrades();
    }
}