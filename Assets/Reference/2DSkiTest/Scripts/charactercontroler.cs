using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroler : MonoBehaviour
{
    public bool move = false;
    public GameObject sprites;
    public Rigidbody2D rb;
    public float speed = 20f;
    public bool isgrounded = true;
    public float rotationspeed = 1.5f;
    public float backwardrotspeed = -1f;
    public bool didihitground = false;
    public float jumpforce = 10f;
    public GameObject normal;
    public GameObject Jump_crouch;
    public GameObject Jump_standing;
    public float boostspeed;
    public GameObject particleeffect;
    public GameObject losestate;
    public GameObject cam;
    public GameObject looseui;
    // Start is called before the first frame update
    void Start()
    {
        normal.SetActive(true);
        Jump_crouch.SetActive(false);
        Jump_standing.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            move = true;
        }
        if (Input.GetButtonUp("Fire1") || Input.GetButtonUp("Jump"))
        {
            move = false;
        }
        

    }
    private void FixedUpdate()
    {
        
        if (isgrounded)
        {
            normal.SetActive(true);
            Jump_crouch.SetActive(false);
            Jump_standing.SetActive(false);
            particleeffect.SetActive(true);

        }
        else
        {
            particleeffect.SetActive(false);
        }
        if (didihitground == false)
        {
            rb.AddForce(transform.right * speed * Time.deltaTime * 100f, ForceMode2D.Force);
        }


        if (move == true)
        {
            if (isgrounded==false)
            {
                rb.AddTorque(rotationspeed * rotationspeed, ForceMode2D.Force);
                normal.SetActive(false);
                Jump_crouch.SetActive(true);
                Jump_standing.SetActive(false);


            }
            else
            {
                rb.AddForce(transform.up * jumpforce * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }

        }
        else
        {
            if(isgrounded == false)
            {
                normal.SetActive(false);
                Jump_crouch.SetActive(false);
                Jump_standing.SetActive(true);
            }
        }
        
        if(move == false )
        {
            if(isgrounded == false)
            {
                rb.AddTorque(backwardrotspeed * 1 * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
        }

    }
    public void OnCollisionEnter2D()
    {
        isgrounded = true;
        normal.SetActive(true);
        Jump_crouch.SetActive(false);
        Jump_standing.SetActive(false);

    }
    public void OnCollisionExit2D()
    {
        isgrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost")
        {
            rb.AddForce(transform.right * boostspeed, ForceMode2D.Impulse);
        }
        if(collision.tag == "Ground")
        {
            didihitground = true;
            losestate.transform.position = gameObject.transform.position;
            Instantiate(losestate);
            Destroy(gameObject);
            cam.SetActive(false);
            looseui.SetActive(true);

        }
        if(collision.tag == "Rock")
        {
            didihitground = true;
            losestate.transform.position = gameObject.transform.position;
            Instantiate(losestate);
            Destroy(gameObject);
            cam.SetActive(false);
            looseui.SetActive(true);
        }
    }
}
