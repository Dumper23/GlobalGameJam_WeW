using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedniperBullet : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed, bulletDuration, rotationModifier;

    private Transform target;
    private Transform target2;

    private int damage;

    private Vector2 lastPos, lastPos2;

    private bool lostTarget;

    private bool ricochet;

    private bool firstTarget = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && target.gameObject.activeInHierarchy && !lostTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            lastPos = target.position;
            lastPos2 = transform.position;

        }
        else
        {
            //transform.Translate((lastPos - lastPos2).normalized * moveSpeed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, lastPos, moveSpeed * Time.deltaTime);
            lostTarget = true;

        }

    }
    private void FixedUpdate()
    {
        if(target != null && target.gameObject.activeInHierarchy && !lostTarget)
        {
            Vector3 vectorTarget = target.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorTarget.y, vectorTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 1000);
        }
        else
        {
            Vector3 vectorTarget = (lastPos - (Vector2)transform.position);
            float angle = Mathf.Atan2(vectorTarget.y, vectorTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * moveSpeed);
        }
    }

    private void OnEnable()
    {
        target = null;
        lostTarget = false;
        firstTarget = true;
        Invoke("Destroy", bulletDuration);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    public void SetTarget2(Transform target2)
    {
        this.target2 = target2;
    }

    public void SetDamage(int bulletDamage)
    {
        damage = bulletDamage;
    }

    public void SetRicochet(bool newRicochet)
    {
        ricochet = newRicochet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (lostTarget)
            {
                collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
                //collision.gameObject.GetComponent<EnemyScript>().Damage();
                if (ricochet)
                {
                    if (!firstTarget)
                    {
                        Destroy();
                    }
                    else
                    {
                        firstTarget = false;

                        if (collision.gameObject.transform == target2)
                        {
                            Destroy();
                        }
                        else
                        {
                            target = target2;
                        }
                        lostTarget = false;
                    }
                }
                else
                {
                    Destroy();
                }
            }
            else
            {
                if (collision.gameObject.transform == target)
                {
                    collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
                    //collision.gameObject.GetComponent<EnemyScript>().Damage();
                    if (ricochet) {
                        if (!firstTarget) {
                            Destroy();
                        }
                        else
                        {
                            firstTarget = false;
                            target = target2;
                        }
                    }
                    else
                    {
                        Destroy();
                    }
                }
            }

        }
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
