using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    private float horizontal;
    public float JumpForce;
    public bool FacingRight;
    private bool canJump = true;
    public SpriteRenderer Renderer;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && canJump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
        if(Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.AddForce(transform.up * JumpForce);
        }
        //Flip();
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
    }

    /*private void Flip()
        {
            if (horizontal <0f)
            {
                Renderer.flipX = true;
            }
            else if (horizontal > 0f)
            {
                Renderer.flipX = false;
            }
        }*/
    
}
