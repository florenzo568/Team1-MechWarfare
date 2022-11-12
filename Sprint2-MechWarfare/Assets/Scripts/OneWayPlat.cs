using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlat : MonoBehaviour
{
    public GameObject currentPlat;
    [SerializeField] private BoxCollider2D playerCollider;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Down"))
        {
            if(currentPlat != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("OneWay"))
        {
            currentPlat = other.gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("OneWay"))
        {
            currentPlat = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentPlat.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider,platformCollider, false);
    }
}
