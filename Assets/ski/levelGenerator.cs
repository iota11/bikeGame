using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    public List<GameObject> tileTypes;
    public GameObject startTile;
    public GameObject enemyPrefab;
    public float tileLength = 10.0f;
    public int loadingRange = 10;
    private float speed = 0.0f;

    private Queue<GameObject> tileList;
    private List<GameObject> enemyList;
    private float gap = 0;
    private Player player;


    private void Start()
    {
        player = FindObjectOfType<Player>();
        tileList = new Queue<GameObject>();
        enemyList = new List<GameObject>();
        for (int i=0; i< loadingRange/2+1; i++)
        {
            GameObject startPlaneNew = Instantiate(startTile, transform);
            startPlaneNew.transform.position = new Vector3(tileLength*i, 0,0);
            tileList.Enqueue(startPlaneNew);
        }
       
    }





    private void FixedUpdate()
    {
        speed = player.xspeed;
        gap += speed * Time.deltaTime;

        int tileID = Random.Range(0, tileTypes.Count);
        //move tiles and enemies globally
        foreach(GameObject tile in tileList)
        {
            tile.transform.Translate(Vector3.left*speed*Time.deltaTime);
        }
        /*
        foreach(GameObject enemy in enemyList)
        {
            enemy.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        */

        if (gap > tileLength)
        {

            GameObject newPlaneNew = Instantiate(tileTypes[tileID], transform);
            newPlaneNew.transform.position = new Vector3(tileLength * (int)(loadingRange/2), 0, 0);
            tileList.Enqueue(newPlaneNew);
            /*
            GameObject newEnemy = Instantiate(enemyPrefab, transform);
            newEnemy.transform.position = new Vector3(tileLength * (int)(loadingRange / 2), 0, 0);
            enemyList.Add(newEnemy);
            */
            gap = 0.0f;
        }

        if(tileList.Count > loadingRange)
        {
            GameObject releaseTile = tileList.Dequeue();
            Destroy(releaseTile);
        }

        /*
        foreach(GameObject e in enemyList)
        {
            if (e.transform.position.x < -10)
            {
                //enemyList.Remove(e);
               // Destroy(e);
            }
        
        }*/
        //process enemy


    }
}