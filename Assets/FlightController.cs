using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : Player
{
    public Transform body_transform;
    public float speed_roll = 50.0f;
    private float angle_roll_ideal = 0.0f;
    private float angle_roll_current = 0.0f;
    public float angle_roll_max = 40.0f;
    public void FixedUpdate()
    {
        GlobalRotate();
        SelfMovement();
    }

    void SelfMovement()
    {
        
        if (Input.GetKey("left"))
        {
            angle_roll_ideal = -angle_roll_max;
        }
        else if (Input.GetKey("right"))
        {
            angle_roll_ideal = angle_roll_max;
        }
        else
        {
            angle_roll_ideal = 0.0f;
        }

        if (angle_roll_current < angle_roll_ideal - 1.0f)
        {
            angle_roll_current += speed_roll * Time.deltaTime;
        }else if(angle_roll_current > angle_roll_ideal + 1.0f)
        {
            angle_roll_current -= speed_roll * Time.deltaTime;
        }
        else
        {
            angle_roll_current = angle_roll_ideal;
        }

        body_transform.localRotation = Quaternion.Euler(angle_roll_current, 0, 0);
        m_transform.RotateAround(m_transform.position, new Vector3(0, 1, 0), -rotateSpeed * angle_roll_current *0.1f* Time.deltaTime);
        /*
        if (Input.GetKey("left"))
        {
            m_transform.RotateAround(m_transform.position, new Vector3(0, 1, 0), rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            m_transform.RotateAround(m_transform.position, new Vector3(0, 1, 0), -rotateSpeed * Time.deltaTime);
        }*/


    }
}
