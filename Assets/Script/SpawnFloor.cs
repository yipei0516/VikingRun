using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloor : MonoBehaviour
{
    public GameObject tileToSpawn;
    public GameObject referenceObject;

    public float timeOffset = 0.2f;//0.2->0.002
    public float distanceBetweenTiles = 8.0F;//5->0.5
    public float randomValue = 0.8f;//0.8->0.4
    private Vector3 previousTilePosition;
    private float startTime;
    private Vector3 direction, mainDirection = new Vector3(0, 0, 1), otherDirection = new Vector3(1, 0, 0);//x z

    private bool destroy;
    private Transform viking;


    [SerializeField] GameObject[] hurdles;
    [SerializeField] GameObject coinPrefab;

    private Vector3 spawnPos;


    private GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        startTime = Time.time;
        viking = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > timeOffset)
        {
            if (Random.value < randomValue)
            {
                direction = mainDirection;
            }
            else
            {
                Vector3 temp = direction;
                direction = otherDirection;
                mainDirection = direction;
                otherDirection = temp;
            }
            spawnPos = previousTilePosition + distanceBetweenTiles * direction;
            startTime = Time.time;

            ground = Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));

            //不要連續兩個洞
            if ((destroy == false) && (Random.value < 0.01))
            {
                Destroy(ground);
                destroy = true;
            }
            else if (Random.value >= 0.0)
            {
                destroy = false;
            }



           
            
            //產生障礙物
            if (Random.value < 0.31f)
            {
                SpawnHurdle();
                
            }
            //產生coin
            if(Random.value < 0.41f)
            {
                SpawnCoin();
            }

            //記住前一個位置
            previousTilePosition = spawnPos;

 
        }
    }

    private void SpawnHurdle()
    {

        //問寶寶！
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(4, 7);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Vector3 s = new Vector3(spawnPos.x + spawnPoint.position.x, spawnPos.y, spawnPos.z);

        //產生障礙物
        int randomHurdle = Random.Range(0, hurdles.Length);//maxExcusive is exclusive

        //x
        if (direction == new Vector3(1, 0, 0))
        {
            Instantiate(hurdles[randomHurdle], s, Quaternion.Euler(270f, 90f, 0), transform);
        }
        //z
        if (direction == new Vector3(0, 0, 1))
        {
            Instantiate(hurdles[randomHurdle], s, hurdles[randomHurdle].transform.rotation, transform);
        }
    }

    private void SpawnCoin()
    {
        int obstacleSpawnIndex = Random.Range(4, 7);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;


        Vector3 s = new Vector3(spawnPos.x + spawnPoint.position.x, 9f, spawnPos.z);
        
        //x
        if (direction == new Vector3(1, 0, 0))
        {
            Instantiate(coinPrefab, s, Quaternion.Euler(270f, 90f, 0), transform);
        }
        //z
        if (direction == new Vector3(0, 0, 1))
        {
            Instantiate(coinPrefab, s, coinPrefab.transform.rotation, transform);
        }
    }
}
