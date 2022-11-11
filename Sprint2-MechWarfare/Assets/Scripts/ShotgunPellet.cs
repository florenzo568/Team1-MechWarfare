using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPellet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public float lifeTime;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        float spread = Random.Range(-10, 10);
        //Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, 0, (angle + spread) * -1));
        //direction.z = bulletRotation.z;
        rb.velocity = transform.up * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //transform.rotation = bulletRotation;
        Debug.Log(angle);
    }
    

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }
}
