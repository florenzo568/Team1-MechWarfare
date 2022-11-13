using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    [SerializeField] GameObject PlayerT;
    private Camera mainCam;
    private Vector3 mousePos;
    [SerializeField] SpriteRenderer PlayerSprite;
    public float playerPos;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

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
