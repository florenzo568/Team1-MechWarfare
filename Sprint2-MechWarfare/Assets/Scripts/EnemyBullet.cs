using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float Force;
    public GameObject player;
    private Rigidbody2D rb;
    public float Damage;
    private Movement PlayerCS;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerCS = player.gameObject.GetComponent<Movement>();
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * Force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerCS.Health -= Damage;
            Destroy(this.gameObject);
             
        }
       
    }
}
