using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] Movement Player;
    public float Fuel = 1;
    public float maxFuel;
    public float regenRate;
    public float Thrust;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Player.canJump == false && Input.GetButton("Jump") && Fuel > 0 && Player.jumpTime <= 0)
        {
            Player.rb.velocity = new Vector2(Player.rb.velocity.x, Thrust);
            Fuel -= Time.deltaTime;
        }
        else if(Fuel < 0)
        {
            Player.rb.velocity = new Vector2(Player.rb.velocity.x, 0);
        }

        if (Fuel < maxFuel)
        {
            Fuel += regenRate * Time.deltaTime;
        }
    }
}
