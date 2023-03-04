using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loosecam : MonoBehaviour
{
    public GameObject rotaion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = rotaion.transform.rotation;
    }
}
