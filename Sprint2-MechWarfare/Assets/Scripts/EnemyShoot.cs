using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] NewEnemyPatrol Enemy;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform bulletPos;
    public float FireRate;
    public float StartRate;
    public float Force;
    [SerializeField] Transform FirePoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Enemy.Seen == true)
        {
            FireRate += Time.deltaTime;
            if(FireRate > StartRate)
            {
                FireRate = 0;
                Shoot();
            }
        }
        
    }


    void Shoot()
    {
        Instantiate(Bullet,bulletPos.position, Quaternion.identity);

    }
}
