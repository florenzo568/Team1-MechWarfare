using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketsPickup : MonoBehaviour
{
    [SerializeField] Movement Player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.RocketsObtained = true;
            Destroy(this.gameObject);
        }
    }
}
