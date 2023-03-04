using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    private bool done = false;
    public bool spawn = false;
    public Transform spawnlocation;
    public Collider2D boxcollider;
    
    void OnTriggerEnter2D(Collider2D col)
    {
       
        
        if (col.tag == "Player")
        {
            spawn = true;
            Debug.Log("hit");
            
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       if(spawn == true)
       {
            spawn = false;
            int rand = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[rand], spawnlocation.position + new Vector3(0, 0, 0), Quaternion.identity, null);
            Destroy(boxcollider);
            

        }
        
    }
   

}
