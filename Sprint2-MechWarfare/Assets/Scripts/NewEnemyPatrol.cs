using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyPatrol : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    public float Speed;
    private int waypointIndex = 1;
    public bool Seen;
    public GameObject Bullet;
    public float FireRate;
    private float StartRate;
    public float Force;
    [SerializeField] Transform FirePoint;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        StartRate = FireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(waypointIndex <= waypoints.Length -1 && Seen == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Speed * Time.deltaTime);
            if(transform.position == waypoints[waypointIndex].transform.position)
            {
                if(waypointIndex == 0)
                {
                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                }
                waypointIndex += 1;
            }
        } 
        else if(waypointIndex >= waypoints.Length)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            waypointIndex = 0;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Seen = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Seen = false;
        }
        
    }

}
