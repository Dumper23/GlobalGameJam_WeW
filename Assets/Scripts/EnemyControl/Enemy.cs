using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string id;
    public int health;
    public int damage;
    public float speed;
    public float attackRate;
    public string type; //flying, etc
    public Transform[] waypoints;

    private int waypointIndex = 0;

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
        waypoints = GameManager.Instance.waypoints;
        transform.position = waypoints[waypointIndex].position;
    }

    void move()
    {
        //Put z to 0
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        waypoints[waypointIndex].transform.position = new Vector3(waypoints[waypointIndex].transform.position.x, waypoints[waypointIndex].transform.position.y, 0);

        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position) waypointIndex += 1;

        if (waypointIndex == waypoints.Length) waypointIndex = 0;
    }
}
