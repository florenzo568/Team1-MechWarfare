using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneHealth : MonoBehaviour
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
            anim.SetBool("death 0", true);
            Destroy(this.gameObject, .75f);
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
