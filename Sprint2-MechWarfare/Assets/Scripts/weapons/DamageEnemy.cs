using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public float Damage;
    public EnemyHealth PlayBullet;
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
    }
}
