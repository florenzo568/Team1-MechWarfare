using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float Range;
    public Transform Target;
    public bool Detected = false;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject Bullet;
    public Transform FirePoint;
    public float FireRate;
    public float NextTimeToFire;
    public float Force;
    public float Health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        if(rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                if(Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if(Detected == true)
                {
                    Detected = false;
                }
            }
        }

        if(Detected)
        {
            Gun.transform.up = Direction;
            if(Time.time > NextTimeToFire)
            {
                NextTimeToFire = Time.time + 1/FireRate;
                Shoot();
            }
        }
    }
    void OnDrawGizmoSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    void Shoot()
    {
        GameObject BulletInst = Instantiate(Bullet,FirePoint.position, Quaternion.identity);
        BulletInst.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

    
}
