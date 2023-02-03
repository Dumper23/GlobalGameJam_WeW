using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutBullet : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed, bulletDuration, nextWPRadius = 1;

    [SerializeField]
    private int hits;

    private List<Transform> waypoints;
    private int start;
    private int current;

    private bool move = false;

    //private Transform target;

    private int damage;

    //private Vector2 lastPos, lastPos2;

    //private bool lostTarget;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Bullet"), LayerMask.NameToLayer("Bullet"));
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //controlar hits
        if (move) {
            Debug.Log(current);
            if (Vector2.Distance(waypoints[current].transform.position, transform.position) < nextWPRadius)
            {
                current--;
                if (current <= -1)
                {
                    //fin destroy
                    move = false;
                    Destroy();
                }
            }
            if (move) {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * moveSpeed);
            }
        }*/
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
    /*
    public void DetermineRoute(List<Transform> _waypoints, int pos)
    {
        Debug.Log("SHOOT");
        waypoints = _waypoints;
        current = pos;
        start = pos;
        move = true;
    }*/

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
            hits--;
            Debug.Log("HIIIIITTT!!");
            collision.gameObject.GetComponent<TMPEnemy>().Damage(damage);
            if (hits <= 0)
            {
                Destroy();
            }
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, nextWPRadius);
    }
}
