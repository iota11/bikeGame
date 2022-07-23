using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0f;
    public Transform m_tranform;
    void Start()
    {
        m_tranform = GetComponent<Transform>();
    }

    void Update()
    {
        Debug.Log(m_tranform.forward);
        m_tranform.position +=  m_tranform.forward*speed* Time.deltaTime;
    }
}
