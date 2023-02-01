using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedniperBullet : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

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
            collision.gameObject.GetComponent<TMPEnemy>().Damage(damage);
            //collision.gameObject.GetComponent<EnemyScript>().Damage();
        }
    }
}
