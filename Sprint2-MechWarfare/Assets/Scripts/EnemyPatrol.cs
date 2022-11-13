using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public bool mustPatrol;
    public bool mustTurn;
    public Transform groundCheckPos;
    public Rigidbody2D rb;
    public float walkSpeed;
    public LayerMask GroundLayer;
    public Collider2D bodyCollider;
    public GameObject Bullet;

    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }

    }

    void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.2f, GroundLayer);
        }
    }

    void Patrol()
    {
        if(mustTurn || bodyCollider.IsTouchingLayers(GroundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(transform.right.x * walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }



}
