using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSprites : MonoBehaviour
{
     [SerializeField] Movement Player;
     [SerializeField] Rockets AimCS;
     [SerializeField] SpriteRenderer Gun;
     [SerializeField] SpriteRenderer Flame;
     [SerializeField] SpriteRenderer Rocket;
     [SerializeField] SpriteRenderer ShotGun;
     [SerializeField] SpriteRenderer Sniper;
    void Start()
    {
            Sniper.enabled = false;
            Flame.enabled = false;
            Gun.enabled = false;
            ShotGun.enabled = false;
            Rocket.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.Sniper == true)
        {
            Sniper.enabled = true;
            Flame.enabled = false;
            Gun.enabled = false;
            ShotGun.enabled = false;
            Rocket.enabled = false;
            if(AimCS.flip == true)
            {
                Sniper.flipY = true;
            }
            else
            {
                Sniper.flipY = false;
            }
        }
        if(Player.Gun == true)
        {
            Gun.enabled = true;
            Sniper.enabled = false;
            Flame.enabled = false;
            ShotGun.enabled = false;
            Rocket.enabled = false;
            if(AimCS.flip == true)
            {
                Gun.flipY = true;
            }
            else
            {
                Gun.flipY = false;
            }
        }
        if(Player.flame == true)
        {
            Flame.enabled = true;
            Gun.enabled = false;
            Sniper.enabled = false;
            ShotGun.enabled = false;
            Rocket.enabled = false;
            if(AimCS.flip == true)
            {
                Flame.flipY = true;
            }
            else
            {
                Flame.flipY = false;
            }
        }
        if(Player.ShotGun == true)
        {
            ShotGun.enabled = true;
            Flame.enabled = false;
            Gun.enabled = false;
            Sniper.enabled = false;
            Rocket.enabled = false;
            if(AimCS.flip == true)
            {
                ShotGun.flipY = true;
            }
            else
            {
                ShotGun.flipY = false;
            }
        }
        if(Player.Rockets == true)
        {
            Rocket.enabled = true;
            ShotGun.enabled = false;
            Flame.enabled = false;
            Gun.enabled = false;
            Sniper.enabled = false;
            if(AimCS.flip == true)
            {
                Rocket.flipY = true;
            }
            else
            {
                Rocket.flipY = false;
            }
        }
    }
}
