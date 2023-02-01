using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorcuthrowBullet : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed, bulletDuration;

    private Transform target;

    private int damage;

    private Vector2 newDirection;

    private bool firstHit = false;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        Invoke("Destroy", bulletDuration);
        firstHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!firstHit)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log(newDirection);
            transform.Translate(newDirection* moveSpeed * Time.deltaTime);
        }

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
            if (target.position == collision.transform.position)
            {
                newDirection = (collision.transform.position - transform.position).normalized;
                if (newDirection == Vector2.zero)
                {
                    newDirection = new Vector2(-1, 0);
                }
                firstHit = true;
            }

            collision.gameObject.GetComponent<TMPEnemy>().Damage(damage);
            //collision.gameObject.GetComponent<EnemyScript>().Damage();
        }
    }
}
