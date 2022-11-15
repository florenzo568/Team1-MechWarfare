using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerDamage : MonoBehaviour
{
    public float tickTimer;
    private float StartTick;
    public float Damage;
    void Start()
    {
        StartTick = tickTimer;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        tickTimer -= Time.deltaTime;
        if(tickTimer <= 0)
        {
            EnemyHealth HP = other.gameObject.GetComponent<EnemyHealth>();
            if(HP != null)
            {
                HP.Health -= Damage;
            }
            
        }
    }
}
