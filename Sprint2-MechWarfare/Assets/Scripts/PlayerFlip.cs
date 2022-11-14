using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    [SerializeField] GameObject PlayerT;
    public Camera mainCam;
    private Vector3 mousePos;
    [SerializeField] SpriteRenderer PlayerSprite;
    public float playerPos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        playerPos = PlayerT.transform.position.x;

        if(mousePos.x < playerPos)
        {
            PlayerSprite.flipX = true;
        }
        else if (mousePos.x > playerPos)
        {
            PlayerSprite.flipX = false;
        }
    }
}
