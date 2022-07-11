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
    private Transform m_transform;
    private Rigidbody m_Rigidbody;

    void Start()
    {
        m_transform = GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("left"))
        {
            m_transform.RotateAround(m_transform.position, m_transform.up, rotateSpeed*Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            m_transform.RotateAround(m_transform.position, m_transform.up, -rotateSpeed*Time.deltaTime);
        }

        float Rotation;
        if (m_transform.eulerAngles.y <= 180f)
        {
            Rotation = m_transform.eulerAngles.y;
        }
        else
        {
            Rotation = m_transform.eulerAngles.y - 360f;
        }



        inputAngle = Rotation;
        xspeed = speed * Mathf.Cos(inputAngle * Mathf.Deg2Rad);
        wspeed = speed * Mathf.Sin(inputAngle * Mathf.Deg2Rad);

       m_transform.Translate(new Vector3(0,0,-1*wspeed*Time.deltaTime), Space.World); 

    }
}
