using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorcuthrowBullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    [SerializeField]
    private float moveSpeed, bulletDuration;

    private Transform target;

    private int damage;

    private Vector2 newDirection;

    private bool piercing;
    [Header("Bullet Settings")]

    [SerializeField]
    private GameObject sprite;
    [SerializeField]
    private float rotationModifier;

    //private bool firstHit = false;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        piercing = false;
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
        //transform.rotation = Quaternion.LookRotation(newDirection + (Vector2)transform.position);
    }
    private void FixedUpdate()
    {
        //Vector2 v = (newDirection + (Vector2)transform.position);
        //sprite.transform.rotation = Quaternion.LookRotation(Vector3.forward, newDirection);
        Vector3 vectorTarget = newDirection;
        float angle = Mathf.Atan2(vectorTarget.y, vectorTarget.x) * Mathf.Rad2Deg - rotationModifier;
        sprite.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

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

    public void SetPiercing(bool newPiercing)
    {
        piercing = newPiercing;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
            //collision.gameObject.GetComponent<EnemyScript>().Damage();

            if (!piercing)//check if lvl piercing
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
