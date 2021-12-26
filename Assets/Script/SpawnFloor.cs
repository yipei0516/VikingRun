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

    // Start is called before the first frame update
    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        startTime = Time.time;
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
            Vector3 spawnPos = previousTilePosition + distanceBetweenTiles * direction;
            startTime = Time.time;

            GameObject ground = Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));

            if ((destroy == false) && (Random.value < 0.01))
            {
                Destroy(ground);
                destroy = true;
            }
            else if (Random.value >= 0.0)
            {
                destroy = false;
            }
            previousTilePosition = spawnPos;
        }
    }
}
