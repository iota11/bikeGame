using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 offset;
    private Transform m_transform;
    public GameObject player;
    void Start()
    {
        m_transform = GetComponent<Transform>();
        offset = m_transform.position - player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        m_transform.position = new Vector3(offset.x + player.transform.position.x/2f, offset.y + player.transform.position.y, offset.z + player.transform.position.z);
    }
}
