using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public float Damage;
    public EnemyHealth PlayBullet;
    public DroneHealth Drone;
    void Awake()
    {

    }

    // Update is called once per frame
void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
           PlayBullet = other.gameObject.GetComponent<EnemyHealth>();
           if(PlayBullet != null)
           {
                PlayBullet.Health -= Damage;
           }
           
        }
        if(other.gameObject.CompareTag("Drone"))
        {
            Debug.Log("Hit");
           Drone = other.gameObject.GetComponent<DroneHealth>();
           if(Drone != null)
           {
                Drone.Health -= Damage;
           }
           
        }
    }
}
