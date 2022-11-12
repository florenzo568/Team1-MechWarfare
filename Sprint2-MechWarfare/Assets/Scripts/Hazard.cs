using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    public float tickTime;
    public float startTime;
    public float Damage;
    public bool Hit;
    [SerializeField] Movement Player;
    void Start()
    {
        startTime = tickTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Hit == true)
        {
            tickTime -= Time.deltaTime;
            if(tickTime <= 0)
            {
                Player.Health -= Damage;
                tickTime = startTime;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Player.Health -= Damage;
        Hit = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Hit = false;
    }
}
