using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] EnemyPatrol Enemy;
    [SerializeField] GameObject Bullet;
    public float FireRate;
    private float StartRate;
    public float Force;
    [SerializeField] Transform FirePoint;
    // Start is called before the first frame update
    void Start()
    {
        StartRate = FireRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
        Enemy.mustPatrol = false;
        FireRate -= Time.deltaTime;
        if(FireRate <= 0)
        {
            Shoot();
            FireRate = StartRate;
        }
        }
        else
        {
            Enemy.mustPatrol = true;
        }
        
        
    }

    void Shoot()
    {
        GameObject BulletInst = Instantiate(Bullet,FirePoint.position, Quaternion.identity);
        BulletInst.GetComponent<Rigidbody2D>().AddForce(transform.right * Force);
    }
}
