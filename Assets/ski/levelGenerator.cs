using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    public List<GameObject> tileTypes;
    public GameObject startTile;
    public GameObject enemyPrefab;
    public float slope = 0f;
    public float height = 0f;

    public float tileLength = 10.0f;
    public int loadingRange = 10;
    private float speed = 0.0f;

    private Queue<GameObject> tileList;
    private List<GameObject> enemyList;
    private float gap = 0;
    private Player player;

    [Header("Random")]
    public float widthRange = 0.0f;
    public float degreeRange = 0.0f;


private void Start()
    {
        player = FindObjectOfType<Player>();
        tileList = new Queue<GameObject>();
        enemyList = new List<GameObject>();

        for (int i=0; i< loadingRange/2+1; i++)
        {
            GameObject startPlaneNew = Instantiate(startTile, transform);
            startPlaneNew.transform.position = new Vector3(tileLength*i, height,Random.Range(-widthRange/2f, widthRange/2f));
            //startPlaneNew.transform.localRotation = Quaternion.Euler(0, Random.Range(-degreeRange/2, degreeRange/2),0 );
            startPlaneNew.transform.Rotate(new Vector3(0, Random.Range(-degreeRange / 2, degreeRange / 2), 0), Space.World);
            tileList.Enqueue(startPlaneNew);
        }
       
    }

    private void FixedUpdate()
    {
        speed = player.xspeed;
        gap += speed * Time.deltaTime;

        int tileID = Random.Range(0, tileTypes.Count);
        //move tiles and enemies globally
        Vector3 dir = new Vector3( -Mathf.Cos(Mathf.Deg2Rad * slope), Mathf.Sin(Mathf.Deg2Rad * slope), 0);

        foreach(GameObject tile in tileList)
        {
            tile.transform.Translate(dir *speed*Time.deltaTime, Space.World);
        }
        

        if (gap > tileLength)
        {

            GameObject planeNew = Instantiate(tileTypes[tileID], transform);
            if (slope > 0.001f)
            {
                planeNew.transform.position = new Vector3(tileLength * (int)(loadingRange / 2) * Mathf.Cos(Mathf.Deg2Rad * slope),
                    -tileLength * (int)(loadingRange / 2) * Mathf.Sin(Mathf.Deg2Rad * slope) + height, 
                    Random.Range(-widthRange / 2f, widthRange / 2f)   );
            }
            else
            {
                planeNew.transform.position = new Vector3(tileLength * (int)(loadingRange / 2),
                  height, 
                  Random.Range(-widthRange / 2f + height,  widthRange / 2f)   );
            }
            //planeNew.transform.localRotation = Quaternion.Euler(0, Random.Range(-degreeRange / 2, degreeRange / 2), 0);
            planeNew.transform.Rotate(new Vector3(0, Random.Range(-degreeRange / 2, degreeRange / 2), 0), Space.World);

            tileList.Enqueue(planeNew);
            gap = 0.0f;
        }

        if(tileList.Count > loadingRange)
        {
            GameObject releaseTile = tileList.Dequeue();
            Destroy(releaseTile);
        }

       


    }
}