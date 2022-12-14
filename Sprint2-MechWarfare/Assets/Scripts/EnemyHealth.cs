using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health;
    [SerializeField] Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            anim.SetTrigger("death");
            Destroy(this.gameObject, .35f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Flame"))
        {
            Health -= 5;
        }
    }
}
