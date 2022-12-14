using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float Speed;
    public float Health = 100;
    private float horizontal;
    public float JumpForce;
    public bool FacingRight;
    public bool canJump = true;
    public SpriteRenderer Renderer;
    [SerializeField] Animator anim;
    public Rigidbody2D rb;
    public float jumpTime = 0.3f;
    public float StartjumpTime;
    public float TurretDamage;
    public bool flame;
    public bool flameObtained = false;
    public bool Gun = true;
    public bool Rockets;
    public bool RocketsObtained = false;
    public bool ShotGun;
    public bool ShotGunObtained;
    public bool Sniper;
    public bool SniperObtained;
    private float deathTime = 2f;

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
            anim.SetBool("Jump", true);
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
            deathTime -= Time.deltaTime;
            Death();
            if(deathTime <= 0)
            {
                SceneManager.LoadScene("CreditScene", LoadSceneMode.Single);
            }
        }
        if(horizontal > 0 || 0 > horizontal)
        {
            anim.SetBool("IsRunning", true);
        }
        else if (horizontal == 0)
        {
            anim.SetBool("IsRunning", false);
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
            anim.SetBool("Jump", false);
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
            anim.SetBool("NotGrounded", true);
        }
        
    }

    void Death()
    {
        anim.SetBool("Death", true);
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
        if (ShotGunObtained == true)
        {
            if (Input.GetButtonDown("3"))
            {
                Rockets = false;
                flame = false;
                Gun = false;
                Sniper = false;
                ShotGun = true;

            }
        }
        if (SniperObtained == true)
        {
            if (Input.GetButtonDown("4"))
            {
                ShotGun = false;
                Rockets = false;
                flame = false;
                Gun = false;
                Sniper = true;

            }
        }
        if (RocketsObtained == true)
        {
            if (Input.GetButtonDown("5"))
            {
                Sniper = false;
                ShotGun = false;
                Rockets = true;
                flame = false;
                Gun = false;

            }
        }
            
    }
    
}
