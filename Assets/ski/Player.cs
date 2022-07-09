using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotateSpeed = 100f;
    public float xspeed = 10.0f;
    public float wspeed = 0.0f;
    public float inputAngle = 3.1415926f;
    private Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("left"))
        {
            transform.RotateAround(transform.position, transform.up, rotateSpeed*Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            transform.RotateAround(transform.position, transform.up, -rotateSpeed*Time.deltaTime);
        }

        float Rotation;
        if (transform.eulerAngles.y <= 180f)
        {
            Rotation = transform.eulerAngles.y;
        }
        else
        {
            Rotation = transform.eulerAngles.y - 360f;
        }



        inputAngle = Rotation;
        xspeed = speed * Mathf.Cos(inputAngle * Mathf.Deg2Rad);
        wspeed = speed * Mathf.Sin(inputAngle * Mathf.Deg2Rad);

        transform.Translate(new Vector3(0,0,-1*wspeed*Time.deltaTime), Space.World); 

    }
}
