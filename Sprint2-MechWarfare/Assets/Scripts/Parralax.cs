using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    public float Plax;
    public Vector3 Origin;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Origin + Player.transform.position * Plax;
    }
}
