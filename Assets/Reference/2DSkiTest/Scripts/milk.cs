using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milk : MonoBehaviour
{
    public GameObject particles;
    public Rigidbody2D rb;
    public float rotationspeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(rotationspeed * rotationspeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bily")
        {
            Destroy(gameObject);
            Debug.Log("milk gone");
            
            particles.transform.position = gameObject.transform.position;
            Instantiate(particles);
        }
    }

    
}