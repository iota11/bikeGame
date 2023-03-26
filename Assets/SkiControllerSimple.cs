using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum SkiState
{
    inair,
    onground
}
public class SkiControllerSimple : MonoBehaviour
{
    public SkiState m_skistate = SkiState.inair;
    public float slopAngle = 20;
    public Transform feet_transform;
    public Vector3 m_speed_w = new Vector3(0, 0, 10);
    public Vector3 m_speed_y = new Vector3(0, 0, 0);
    public Vector3 m_speed_x = new Vector3(0, 0, 0);
    public Transform m_transform;
    public float rayDis = 3;
    public float normalHeight = 0.5f;
    public float stretchHeight = 1.2f;
    public float contractHeight = 0.2f;
    public float legLoose = 3f;
    public Vector3 m_gravity = new Vector3(0, -10f, 0);
    public float m_forceFactor = 0.1f;
    public float m_mass = 70f;
    private Vector3 ori_speed;
    public float turnSpeed = 10.0f;
    private Quaternion initialRotation;
    void Start() {
        m_transform = GetComponent<Transform>();
        ori_speed = m_speed_w;
        initialRotation = m_transform.rotation;
        m_speed_w = Quaternion.Euler(slopAngle, 0, 0) * m_speed_w;

    }

    // Update is called once per frame
    void FixedUpdate() {
        m_transform.rotation = Quaternion.Euler(slopAngle, 0, 0) * initialRotation;
        int layerMask = 1 << 8;
        //layerMask = ~layerMask;
        RaycastHit hit;
        Vector3 rayPos = new Vector3(m_transform.position.x, m_transform.position.y + rayDis, m_transform.position.z);
        if (Physics.Raycast(rayPos, new Vector3(0, -1, 0), out hit, Mathf.Infinity, layerMask)) {
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.tag == "JumpGround") {
                legLoose = Mathf.Lerp(legLoose, 1, Time.deltaTime*5);
                Debug.Log("to jump");
            } else {
                legLoose = 5;
            }
            float buttPosY = hit.distance - rayDis + normalHeight;
            if (buttPosY > stretchHeight) {
                // in the air
                m_speed_y = Accelerate(m_speed_y, m_gravity * m_mass, m_mass);
            } else {
                KeyControl();
                if (m_speed_y.y < -0.1f) {
                    m_speed_y *= Mathf.Clamp((buttPosY - contractHeight) * legLoose, 0, 1f);
                } else {
           
                    m_transform.position = Vector3.Lerp(m_transform.position, hit.point, Time.deltaTime * 30 / legLoose);
                    if (buttPosY < contractHeight / 2f) {
                        m_transform.position = hit.point + new Vector3(0, contractHeight / 2f - normalHeight, 0);
                    }
                }

                feet_transform.position = Vector3.Lerp(feet_transform.position, hit.point, Time.deltaTime *20) ;

            }
        }
        m_transform.Translate((m_speed_y + m_speed_w + m_speed_x) * Time.deltaTime, Space.World);
    }

    Vector3 Accelerate(Vector3 speed, Vector3 force, float mass) {
        return (speed + (force / mass) * Time.deltaTime);
    }

    void KeyControl() {
        if (Input.GetKey("left")) {
            m_speed_x += new Vector3(1, 0, 0) * Time.deltaTime* turnSpeed;

        } else if (Input.GetKey("right")) {
            m_speed_x -= new Vector3(1, 0, 0) * Time.deltaTime * turnSpeed;
        } else {
            m_speed_x = Vector3.Lerp(m_speed_x, new Vector3(0, 0, 0), Time.deltaTime * 30f);
        }
        m_speed_x.x = Mathf.Clamp(m_speed_x.x ,- 10, 10);

    }
}
