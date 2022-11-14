using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    [SerializeField] Movement Player;
    [SerializeField] SpriteRenderer Sprite;
    [SerializeField] BoxCollider2D Flame;
    public Camera mainCam;
    private Vector3 mousePos;
    
    void Start()
    {
        Sprite.enabled = false;
        Flame.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        Vector3 rotation = mousePos - transform.position;

        float rotationZ = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0, rotationZ);

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
