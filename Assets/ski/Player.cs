using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotateSpeed = 100f;
    public float xspeed = 10.0f;
    public float wspeed = 0.0f;
    public float yspeed = 0.0f;
    public Vector3 speedDir = new Vector3(0,0,0);
    public float inputAngle = 3.1415926f;

    private Transform m_transform;
    private Rigidbody m_Rigidbody;
    //public Transform ray_transform;
    public float rayDis = 2.0f;
    public float gravity = -10.0f;
    void Start()
    {
        m_transform = GetComponent<Transform>();
        //m_Rigidbody = GetComponent<Rigidbody>();

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

        UpdateVerticelSpeed();
        ApplyVerticalSpeed();

    }

    void UpdateVerticelSpeed()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        Vector3 rayPos =  new Vector3(m_transform.position.x, m_transform.position.y + rayDis, m_transform.position.z);
        //Debug.Log("rayPos is "+ rayPos);
        //Debug.Log("pos is " + m_transform.position);
        if (Physics.Raycast( rayPos, m_transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
        {
            //Debug.Log(hit.distance);
            //chit.normal
            if(hit.distance > rayDis)
            {
                yspeed += (-gravity) * Time.deltaTime; //accellerate;
            }
            else
            {
                //Debug.Log("what ");
                m_transform.position = new Vector3( 0 ,  rayDis- hit.distance, 0) + m_transform.position;
                yspeed = 0.0f;
            }
        }
        else
        {
            yspeed = 0.0f;  //remain still
        }
    }
    void ApplyVerticalSpeed()
    {
        m_transform.Translate(new Vector3(0, -1 * yspeed * Time.deltaTime, 0), Space.World);
    }

}

