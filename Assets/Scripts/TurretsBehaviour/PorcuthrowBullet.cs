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

    //private bool firstHit = false;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        Invoke("Destroy", bulletDuration);
        //firstHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!firstHit)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log(newDirection);
            transform.Translate(newDirection* moveSpeed * Time.deltaTime);
        }
        */
        transform.Translate(newDirection * moveSpeed * Time.deltaTime);
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

    public void UpdateNewDirection(Vector2 dir)
    {
        newDirection = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.GetComponent<TMPEnemy>().Damage(damage);
            //collision.gameObject.GetComponent<EnemyScript>().Damage();

            if (false)//check if lvl piercing
            {
                Destroy();
            }


        }
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
