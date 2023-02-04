using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResinBullet : MonoBehaviour
{

    [SerializeField]
    private float slowness, resinDuration;

    private float startDuration, length;

    private int damage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= startDuration + resinDuration)
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    public void SetDamage(int bulletDamage)
    {
        damage = bulletDamage;
    }

    public void SetDuration(float newDuration)
    {
        resinDuration = newDuration;
    }

    public void SetSlowness(float newSlowness)
    {
        slowness = newSlowness;
    }

    public void SetLength(float newLength)
    {
        length = newLength;
    }

    private void OnEnable()
    {
        startDuration = Time.time;
        transform.localScale = new Vector3(transform.localScale.x, length, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
            //collision.gameObject.GetComponent<EnemyScript>().Slow() i dmg;
        }
    }
}
