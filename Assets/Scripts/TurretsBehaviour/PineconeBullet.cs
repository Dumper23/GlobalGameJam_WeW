using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineconeBullet : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed, radius, bulletDuration;

    private Transform target;

    private int damage;

    private Vector2 lastPos, lastPos2;

    private bool lostTarget;

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
            transform.Translate((lastPos - lastPos2).normalized * moveSpeed * Time.deltaTime);
            lostTarget = true;
        }
    }
    private void OnEnable()
    {
        target = null;
        lostTarget = false;
        Invoke("Disappear", bulletDuration);
    }

    private void Destroy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D c in enemies)
        {
            if (c.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                c.GetComponent<TMPEnemy>().Damage(damage);
            }
        }
        gameObject.SetActive(false);
    }

    private void Disappear()
    {
        gameObject.SetActive(false);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SetDamage(int bulletDamage)
    {
        damage = bulletDamage;
    }

    public void SetRadius(float newRadius)
    {
        radius = newRadius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (lostTarget)
            {
                //collision.gameObject.GetComponent<TMPEnemy>().Damage(damage);
                //collision.gameObject.GetComponent<EnemyScript>().Damage();
                Destroy();
            }
            else
            {
                if (collision.gameObject.transform == target)
                {
                    //collision.gameObject.GetComponent<TMPEnemy>().Damage(damage);
                    //collision.gameObject.GetComponent<EnemyScript>().Damage();
                    Destroy();
                }
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
