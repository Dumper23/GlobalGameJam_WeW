using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterBullet : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed, radius, bulletDuration;

    private int damage;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
    private void OnEnable()
    {
        Invoke("Destroy", bulletDuration);
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

    public void SetDamage(int bulletDamage)
    {
        damage = bulletDamage/4;
    }

    public void SetRadius(float newRadius)
    {
        radius = newRadius/6;
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void SetTime(float duration)
    {
        bulletDuration = duration;
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
