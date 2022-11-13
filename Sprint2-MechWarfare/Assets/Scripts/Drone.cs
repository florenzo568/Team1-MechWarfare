using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float speed;
    private GameObject player;
    public bool chase = false;
    public Transform startingPoint;
    public SpriteRenderer Sprite;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Sprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            return;
        }
        if(chase == true)
        {
            Chase();
        }
        else
        {
            ReturnToStart();
        }
        Chase();
        Flip();
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void Flip()
    {
        if(transform.position.x > player.transform.position.x)
        {
            Sprite.flipX = false;
        }
        else if(transform.position.x < player.transform.position.x)
        {
            Sprite.flipX = true;
        }
    }
    private void ReturnToStart()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }
}
