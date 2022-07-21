using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : Player
{
    public Transform body_transform;
    public float speed_roll = 50.0f;
    private float angle_roll_ideal = 0.0f;
    private float angle_roll_current = 0.0f;
    public void FixedUpdate()
    {
        GlobalRotate();
        SelfMovement();
    }

    void SelfMovement()
    {
        
        if (Input.GetKey("left"))
        {
            angle_roll_ideal = -60.0f;
        }
        else if (Input.GetKey("right"))
        {
            angle_roll_ideal = 60.0f;
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

    }
}
