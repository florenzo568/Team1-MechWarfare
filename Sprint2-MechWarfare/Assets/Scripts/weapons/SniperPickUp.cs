using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperPickUp : MonoBehaviour
{
    [SerializeField] Movement Player;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player.SniperObtained = true;
            Destroy(this.gameObject);
        }
    }
}
