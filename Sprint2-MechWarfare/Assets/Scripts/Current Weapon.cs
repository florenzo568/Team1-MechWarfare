using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentWeapon : MonoBehaviour
{
    [SerializeField] Movement Player;
    [SerializeField] TextMeshProUGUI Weapon;
    void Start()
    {
        Weapon.text = "Balius VI";
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.Gun == true)
        {
            Weapon.text = "Balius VI";
        }
        if(Player.flame == true)
        {
            Weapon.text = "Heavy FlameThrower";
        }
        if (Player.Rockets == true)
        {
            Weapon.text = "Missile Launcher";
        }
        if (Player.ShotGun == true)
        {
            Weapon.text = "Shot Gun";
        }
        if (Player.Sniper == true)
        {

            Weapon.text = "Sniper Rifle";
        }
    }
}
