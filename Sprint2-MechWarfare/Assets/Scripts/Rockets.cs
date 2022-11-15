using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockets : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject rocket;
    [SerializeField]
    Movement Player;
    public Transform bulletTransform;
    public bool canFire = true;
    public bool flip;
    private float Timer;
    public float FireRate;
    public int Ammo;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        Vector3 rotation = mousePos - transform.position;

        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        if (mousePos.x < 0)
        {
            Player.Renderer.flipX = true;
            flip = true;
        }
        else if (mousePos.x > 0)
        {
            Player.Renderer.flipX = false;
            flip = false;
        }

        if (!canFire)
        {
            Timer += Time.deltaTime;
            if (Timer > FireRate)
            {
                canFire = true;
                Timer = 0;
            }
        }
        if (Player.Rockets == true)
        {
            if (Input.GetMouseButton(0) && canFire)
            {
                canFire = false;
                Instantiate(rocket, bulletTransform.position, Quaternion.identity);
                Ammo -= 1;
            }
        }

    }
}


