using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float Timer;
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Timer = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
