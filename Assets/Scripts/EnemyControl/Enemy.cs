using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string id;
    public int maxHealth;
    public float speed;
    public string type; //flying, etc
    public Transform[] waypoints;

    public int waypointIndex = 0;
    public int currentHealth;

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

    void initialize()
    {
        //get waypoints from GameManager
        waypoints = GameManager.Instance.getWaypoints(type);
        transform.position = waypoints[0].position;
        currentHealth = maxHealth;
    }

    void move()
    {
        //Put z to 0
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        waypoints[waypointIndex].transform.position = new Vector3(waypoints[waypointIndex].transform.position.x, waypoints[waypointIndex].transform.position.y, 0);

        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < 0.5) waypointIndex += 1;

        if (waypointIndex == waypoints.Length)
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
    }
}
