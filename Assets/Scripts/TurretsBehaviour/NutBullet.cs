using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutBullet : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed, bulletDuration;

    [SerializeField]
    private int hits;
    //private Transform target;

    private int damage;

    //private Vector2 lastPos, lastPos2;

    //private bool lostTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //controlar hits
    }

    private void OnEnable()
    {
        Invoke("Destroy", bulletDuration);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    public void SetDamage(int bulletDamage)
    {
        damage = bulletDamage;
    }

    public void SetHits(int newHits)
    {
        hits = newHits;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            /*
            if (lostTarget)
            {
                collision.gameObject.GetComponent<TMPEnemy>().Damage(damage);
                //collision.gameObject.GetComponent<EnemyScript>().Damage();
                Destroy();
            }
            else
            {
                if (collision.gameObject.transform == target)
                {
                    collision.gameObject.GetComponent<TMPEnemy>().Damage(damage);
                    //collision.gameObject.GetComponent<EnemyScript>().Damage();
                    Destroy();
                }
            }
            */
        }
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
