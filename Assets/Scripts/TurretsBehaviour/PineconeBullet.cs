using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineconeBullet : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed, radius;

    private Transform target;

    private int damage;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
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

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SetDamage(int bulletDamage)
    {
        damage = bulletDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
