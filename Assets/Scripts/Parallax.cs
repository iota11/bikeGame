using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float lenth, startpos;
    public GameObject cam;
    public float parallaxeffect;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        lenth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxeffect));
        float dist = (cam.transform.position.x * parallaxeffect);
        transform.position = new Vector3(startpos + dist,transform.position.y, transform.position.z);
        if (temp > startpos + lenth) startpos += lenth;
        else if (temp < startpos - lenth) startpos -= lenth;
    }
}
