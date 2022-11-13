using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    public float Health = 100;
    private float horizontal;
    public float JumpForce;
    public bool FacingRight;
    public bool canJump = true;
    public SpriteRenderer Renderer;
    public Rigidbody2D rb;
    public float jumpTime = 0.3f;
    public float StartjumpTime;
    public float TurretDamage;
    public bool flame = true;
    public bool flameObtained = false;
    public bool Gun = true;
    public bool Rockets = true;
    public bool RocketsObtained = false;
    public bool ShotGun;
    public bool ShotGunObtained;
    public bool Sniper;
    public bool SniperObtained;

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
        WeaponSwapping();
        if(Health <= 0)
        {
            Debug.Log("Dead");
        }
        
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
        if(other.gameObject.CompareTag("TurretBullet"))
        {
            Health -= TurretDamage;
        }
        
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
        
    }
    void WeaponSwapping()
    {
        if (Input.GetButtonDown("1"))
        {
            Gun = true;
            flame = false;
            Rockets = false;
            Sniper = false;
            ShotGun = false;
        }
        if(flameObtained == true)
        {
            if (Input.GetButtonDown("2"))
            {
                flame = true;
                Gun = false;
                Rockets = false;
                Sniper = false;
                ShotGun = false;
            }
        }
        if (RocketsObtained == true)
        {
            if (Input.GetButtonDown("3"))
            {
                Rockets = true;
                flame = false;
                Gun = false;
                Sniper = false;
                ShotGun = false;

            }
        }
        if (ShotGunObtained == true)
        {
            if (Input.GetButtonDown("4"))
            {
                ShotGun = true;
                Rockets = false;
                flame = false;
                Gun = false;
                Sniper = false;

            }
        }
        if (SniperObtained == true)
        {
            if (Input.GetButtonDown("5"))
            {
                Sniper = true;
                ShotGun = false;
                Rockets = false;
                flame = false;
                Gun = false;

            }
        }
            
    }
    
}
