using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    [SerializeField] Movement Player;
    [SerializeField] SpriteRenderer Sprite;
    [SerializeField] BoxCollider2D Flame;

    
    void Start()
    {
        Sprite.enabled = false;
        Flame.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.flame == true)
        {
            if(Input.GetMouseButton(0))
            {
                Sprite.enabled = true;
                Flame.enabled = true;
            }
            else
            {
                Sprite.enabled = false;
                Flame.enabled = false;
            }
        }
    }
}
