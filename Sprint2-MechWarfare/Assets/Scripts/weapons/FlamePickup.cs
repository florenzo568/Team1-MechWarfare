using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePickup : MonoBehaviour
{
    [SerializeField] Movement Player;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player.flameObtained = true;
            Destroy(this.gameObject);
        }
    }
}
