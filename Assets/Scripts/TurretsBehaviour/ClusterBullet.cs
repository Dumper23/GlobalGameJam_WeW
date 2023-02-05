using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterBullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    [SerializeField]
    private float moveSpeed, radius, bulletDuration;

    private bool isDestroying = false;

    private int damage;

    private Vector2 direction;

    [Header("Bullet Settings")]
    [SerializeField]
    private GameObject sprite;

    [SerializeField]
    private Animator explosion;

    [SerializeField]
    private GameObject eSoundB;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isDestroying)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        Invoke("Destroy", bulletDuration);
    }

    private void Destroy()
    {
        isDestroying = true;

        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D c in enemies)
        {
            if (c.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                c.GetComponent<Enemy>().takeDamage(damage);
            }
        }
        explosion.gameObject.SetActive(true);
        explosion.Play("explosionSmall");
        Instantiate(eSoundB);
        sprite.SetActive(false);
        Invoke("Disable", 1f);
    }

    private void Disable()
    {
        isDestroying = false;

        sprite.SetActive(true);
        explosion.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void SetDamage(int bulletDamage)
    {
        damage = bulletDamage / 4;
    }

    public void SetRadius(float newRadius)
    {
        radius = newRadius / 6;
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