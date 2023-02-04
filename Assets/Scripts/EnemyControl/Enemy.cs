using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string id;
    public int maxHealth;
    public float speed;
    public string type; //flying, etc
    public List<Vector3> waypoints = new List<Vector3>();
    public int fertilizerToGive = 10;

    public int waypointIndex = 0;
    public int currentHealth;

    public static float TARGET_OFFSET = 2f;

    // Start is called before the first frame update
    void Start()
    {
        initialize();
    }

    // Update is called once per frame
    void Update()
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
            Vector3 offsetWaypoint = getRandomPoint(waypoint.position);
            waypoints.Add(offsetWaypoint);
        }
        currentHealth = maxHealth;
    }

    void move()
    {
        //Put z to 0
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        waypoints[waypointIndex] = new Vector3(waypoints[waypointIndex].x, waypoints[waypointIndex].y, 0);

        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex], speed * Time.deltaTime);
        //getRandomPoint(waypoints[waypointIndex].transform.position)

        if (Vector3.Distance(transform.position, waypoints[waypointIndex]) < 0.5) waypointIndex += 1;

        if (waypointIndex == waypoints.Count)
        {
            //Remove one life from the player
            GameManager.Instance.removePlayerHP();

            gameObject.SetActive(false); //Disappears when reaches the top of the tree
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            die();
        }
    }

    public void die()
    {
        gameObject.SetActive(false);
        GameManager.Instance.fertilizer += fertilizerToGive;
    }

    private Vector3 getRandomPoint(Vector3 center)
    {
        return center + new Vector3((Random.value - 0.5f) * TARGET_OFFSET, (Random.value - 0.5f) * TARGET_OFFSET, 0);
    }
}
