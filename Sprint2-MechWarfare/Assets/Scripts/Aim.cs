using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public GameObject Sniperbullet;
    public GameObject ShotGunbullet;
    [SerializeField] Movement Player;
    [SerializeField] GameObject PlayerT;
    [SerializeField] SpriteRenderer laser;
    [SerializeField] SpriteRenderer PlayerSprite;
    public Transform PlayerTrans;
    public Transform bulletTransform;
    public bool canFire = true;
    public bool flip;
    public float playerPos;
    private float Timer;
    public float FireRate;
    public int Ammo;
    public int pellets;
    private float angle;
    private float spread;
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
       
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;

        float rotationZ = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0, rotationZ);
        
        if(mousePos.x < PlayerTrans.position.x)
        {
            flip = false;
        }
        else if (mousePos.x > PlayerTrans.position.x)
        {
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

    /*if(Player.ShotGun == true)
    {
        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;

            for (int i = 0; i < pellets; i++)
            {
                spread = Random.Range(-10,10);
                Quaternion bulletRotation = Quaternion.Euler(new Vector3(0,0,rotationZ + spread));
                Debug.Log(bulletRotation);
                GameObject bulletInstance = Instantiate(ShotGunbullet, bulletTransform.position, Quaternion.identity);

            }
            
                
                
                Ammo -= 1;
        }
    }*/
        
    }
}
