using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string id;
    public int maxHealth;
    public float speed;
    public float currentSpeed;
    public string type; //flying, etc
    public List<Vector3> waypoints = new List<Vector3>();
    public int fertilizerToGive = 10;
    public bool isSlowed = false;
    public bool isStunned = false;
    public GameObject hitParticles;

    public GameObject bloodParticles;
    public GameObject bloodDecal;

    public int waypointIndex = 0;
    public int currentHealth;

    public static float TARGET_OFFSET = 0.5f;
    private Vector3 currentAngle = new Vector3();

    public GameObject deathSound;

    // Start is called before the first frame update
    private void Start()
    {
        initialize();
    }

    // Update is called once per frame
    private void Update()
    {
        move();
    }

    public void initialize()
    {
        waypointIndex = 0;
        waypoints.Clear();
        //get waypoints from GameManager
        foreach (Transform waypoint in GameManager.Instance.getWaypoints(type))
        {
            if (waypoint != null)
            {
                Vector3 offsetWaypoint = getRandomPoint(waypoint.position);
                waypoints.Add(offsetWaypoint);
            }
            
        }
        this.currentHealth = this.maxHealth;
        this.currentSpeed = this.speed;
        this.rotateEnemy(0);
    }

    private void move()
    {
        //Put z to 0
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        waypoints[waypointIndex] = new Vector3(waypoints[waypointIndex].x, waypoints[waypointIndex].y, 0);

        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex], currentSpeed * Time.deltaTime);
        //getRandomPoint(waypoints[waypointIndex].transform.position)

        if (Vector3.Distance(transform.position, waypoints[waypointIndex]) < 0.5)
        {
            if (waypointIndex == 2 && this.type == "walk")
            {
                //rotate enemy
                this.rotateEnemy(90f);
            }
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Count)
        {
            //Remove one life from the player
            GameManager.Instance.removePlayerHP();

            gameObject.SetActive(false); //Disappears when reaches the top of the tree
        }
    }

    public void rotateEnemy(float offset)
    {
        float angle2 = Mathf.Atan2(Vector3.forward.normalized.y, Vector3.forward.normalized.x) * Mathf.Rad2Deg;
        this.gameObject.transform.rotation = Quaternion.AngleAxis(angle2 + offset, Vector3.forward);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(hitParticles, transform.position, Quaternion.identity);
        if (currentHealth <= 0)
        {
            die();
        }
    }

    public void die()
    {
        Instantiate(bloodParticles, transform.position, Quaternion.identity);
        GameObject go = Instantiate(bloodDecal, transform.position, Quaternion.Euler(new Vector3(0, 0, Random.Range(0f, 360f))));
        go.GetComponentInChildren<SpriteRenderer>().color = new Color(0.0990566f, Random.Range(0.1f, 0.9f), 0.1093038f);
        Instantiate(deathSound, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        GameManager.Instance.fertilizer += fertilizerToGive;
    }

    private Vector3 getRandomPoint(Vector3 center)
    {
        return center + new Vector3(Random.Range(-1, 1) * TARGET_OFFSET, Random.Range(-1, 1) * TARGET_OFFSET, 0);
    }

    public void stun(float time)
    {
        this.currentSpeed = 0;
        this.isStunned = true;
        Invoke("setOriginalSpeed", time);
    }

    public void slowDown(float amount)
    {

        this.currentSpeed -= this.currentSpeed * amount;
        this.isSlowed = true;
        Invoke("setOriginalSpeed", 3);
    }

    public void setOriginalSpeed()
    {
        this.currentSpeed = this.speed;
        this.isSlowed = false;
        this.isStunned = false;
    }
}