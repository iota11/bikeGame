using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loose : MonoBehaviour
{
    public GameObject sittingstate;
    public Rigidbody2D rb;
    public float boostspeed;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.right * boostspeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            sittingstate.transform.position = gameObject.transform.position;
            Instantiate(sittingstate);
            Destroy(gameObject);
        }
    }

}
