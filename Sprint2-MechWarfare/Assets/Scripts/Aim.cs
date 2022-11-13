using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public GameObject Sniperbullet;
    [SerializeField] Movement Player;
    [SerializeField] GameObject PlayerT;
    [SerializeField] SpriteRenderer laser;
    [SerializeField] SpriteRenderer PlayerSprite;
    public Transform bulletTransform;
    public bool canFire = true;
    public bool flip;
    public float playerPos;
    private float Timer;
    public float FireRate;
    public int Ammo;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        laser.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        playerPos = PlayerT.transform.position.x;
       

        float rotationZ = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0, rotationZ);
        
        if(mousePos.x < playerPos)
        {
            PlayerSprite.flipX = true;
            flip = false;

        }
        else if (mousePos.x > playerPos)
        {
            PlayerSprite.flipX = false;
            flip = true;

        }

        if(!canFire)
        {
            Timer += Time.deltaTime;
            if(Timer > FireRate)
            {
                canFire = true;
                Timer = 0;
            }
        }
    if(Player.Gun == true)
    {
        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
                Ammo -= 1;
        }
    }
    if(Player.Sniper == true)
    {
        laser.enabled = true;
        if(Input.GetMouseButton(0) && canFire)
        {
            
            canFire = false;
            Instantiate(Sniperbullet, bulletTransform.position, Quaternion.identity);
                Ammo -= 1;
        }
    }
    else
    {
        laser.enabled = false;
    }
        
    }
}
