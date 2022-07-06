using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, prefabs.Length);
        
        Instantiate(prefabs[rand], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
