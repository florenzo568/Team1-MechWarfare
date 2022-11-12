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
    [SerializeField] SpriteRenderer laser;
    public Transform bulletTransform;
    public bool canFire = true;
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

        float rotationZ = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0, rotationZ);
        if(mousePos.x < 0)
        {
            Player.Renderer.flipX = true;
        }
        else if (mousePos.x > 0)
        {
            Player.Renderer.flipX = false;
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
