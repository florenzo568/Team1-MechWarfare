using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    private float horizontal;
    public float JumpForce;
    public bool FacingRight;
    public bool canJump = true;
    public SpriteRenderer Renderer;
    public Rigidbody2D rb;
    public float jumpTime = 0.3f;
    public float StartjumpTime;

    void Start()
    {
        StartjumpTime = jumpTime;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && canJump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
        if(canJump == false)
        {
            jumpTime -= Time.deltaTime;
        }
        else
        {
            jumpTime = StartjumpTime;
        }

        //Flip();
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
        
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
        
    }
    
}
