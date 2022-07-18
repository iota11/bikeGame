using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 m_speed = new Vector3(20f, 0f, 0f);
    public float m_mass = 70f;
    public Transform m_transform;
    public float rayDis = 2.0f;
    public Vector3 m_gravity = new Vector3(0, -10f, 0);
    public float m_forceFactor = 0.1f;
    public float rotateSpeed = 100.0f;
    void Start()
    {
        m_transform = GetComponent<Transform>();
        m_gravity *= m_mass;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        RaycastHit hit;
        Vector3 rayPos = new Vector3(m_transform.position.x, m_transform.position.y + rayDis, m_transform.position.z);
        if (Physics.Raycast(rayPos, new Vector3(0,-1,0), out hit, Mathf.Infinity, layerMask))
        {
            if (hit.distance > rayDis)//in the air
            {
                m_speed = Accelerate(m_speed, m_gravity, m_mass);
            }
            else 
            {
                //hit
                m_transform.position = new Vector3(0, rayDis - hit.distance, 0) + m_transform.position;
                Vector3 m_speed_old = m_speed;
                m_speed = PlanProject(m_speed, hit.normal);
                float cosChange = Vector3.Dot(m_speed_old.normalized, m_speed.normalized);

                if (cosChange > 0.7) //preserve speed;
                {
                    m_speed = m_speed.normalized * m_speed_old.magnitude;
                }
                else
                {
                    Debug.Log("big change");
                }

                //calculate force
                Vector3 forcePlane = PlanProject(m_gravity, hit.normal);
                Vector3 forcePressure = m_gravity - forcePlane;
                Vector3 forceFriction = m_speed.normalized * forcePressure.magnitude * m_forceFactor;
                m_speed = Accelerate(m_speed, forcePlane - forceFriction, m_mass);

                //update transform
                if (Input.GetKey("left"))
                {
                    m_speed = Quaternion.AngleAxis(rotateSpeed * Time.deltaTime, Vector3.up) * m_speed;

                }
                if (Input.GetKey("right"))
                {
                    m_speed = Quaternion.AngleAxis(-rotateSpeed * Time.deltaTime, Vector3.up) * m_speed;
                }
                m_transform.up = hit.normal;
                m_transform.forward = m_speed.normalized;
            }
        }
        else
        {
            m_speed = Accelerate(m_speed, m_gravity, m_mass);
        }

        

        //update speed
        m_transform.Translate(m_speed * Time.deltaTime, Space.World);
    }

    Vector3 Accelerate(Vector3 speed, Vector3 force, float mass)
    {
        return (speed + (force / mass)*Time.deltaTime);
    }

    Vector3 PlanProject(Vector3 inVector, Vector3 normal){
        Vector3 normalProjection = normal * Vector3.Dot(inVector , normal);
        return inVector-normalProjection;
     }



}
