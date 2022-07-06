using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camrafollow : MonoBehaviour
{
    public Transform target;
    
    public Vector3 offset;
    

    public charactercontroler controler;
    private void LateUpdate()
    {
        Vector3 newpos = target.position + offset;
        newpos.z = transform.position.z;
        transform.position = newpos;
       
       
    }
   





}
