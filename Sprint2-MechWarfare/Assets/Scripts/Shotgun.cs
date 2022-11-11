using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    [SerializeField] Movement Player;
    public Transform bulletTransform;
    public bool canFire = true;
    private float Timer;
    public float FireRate;
    public int Ammo;
    public int pellets;
    private float angle;
    private float spread;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotationZ = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;

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
    if(Player.ShotGun == true)
    {
        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;

            for (int i = 0; i < pellets; i++)
            {
                spread = Random.Range(-10,10);
                Quaternion bulletRotation = Quaternion.Euler(new Vector3(0,0,angle + spread));
                GameObject bulletInstance = Instantiate(bullet, bulletTransform.position, bulletRotation);

            }
            
                
                
                Ammo -= 1;
        }
    }
        
    }
}
