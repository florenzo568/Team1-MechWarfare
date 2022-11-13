using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseControl : MonoBehaviour
{
    public Drone[] DroneArray;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            foreach(Drone drone in DroneArray)
            {
                drone.chase = true;
            }
        }
    }


     private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            foreach(Drone drone in DroneArray)
            {
                drone.chase = false;
            }
        }
    }
}
