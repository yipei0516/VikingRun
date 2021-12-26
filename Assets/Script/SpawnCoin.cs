using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject coin;
    public float coinTime = 2.5f;
    private Transform viking;
    int randomCoin;
    GameObject c;
    bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        
        viking = GameObject.FindGameObjectWithTag("Player").transform;
        //StartCoroutine(spawnCoin());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 coinPosition = viking.position;

        coinPosition.y = 9f;
        //在修一下！
        
        //x
        if (viking.transform.forward == new Vector3(1, 0, 0) && Random.value < 0.009f &&inRange)
        {
            //coinPosition.x += 1.3f;
            c = Instantiate(coin, coinPosition + viking.forward * 20, Quaternion.Euler(-90f, 90f, 0));
            inRange = false;
        }
        //z
        if (viking.transform.forward == new Vector3(0, 0, 1) && Random.value < 0.009f&&inRange)
        {
            //coinPosition.x -= 1.3f;
            c = Instantiate(coin, coinPosition + viking.forward * 20, coin.transform.rotation);
            inRange = false;
        }/*
        if (!inRange)
        {
            Destroy(c);
        }*/
    }
    /*
    IEnumerator spawnCoin()
    {
        yield return new WaitForSeconds(coinTime);
        spawn();
        Update();
    }
    void spawn()
    {
        //randomCoin = Random.Range(0, coin.Length);//最右邊 is exclusive

        Vector3 coinPosition = viking.position;

        //coinPosition.y = 0f;
        //在修一下！
        coinPosition.x += 1.3f;
        //x
        if(viking.transform.forward==new Vector3(1, 0, 0))
        {
            Instantiate(this, coinPosition + viking.forward * 20, Quaternion.Euler(0, 90f, 0));
        }
        //z
        if(viking.transform.forward == new Vector3(0, 0, 1)) 
        {
            Instantiate(this, coinPosition + viking.forward * 20, transform.rotation);
        }

        StartCoroutine(spawnCoin());
    }
    */
    
    private void OnColliderEnter(Collision collision)
    {
        if (collision.transform.name == "floor_01_variability_05")
        {
            inRange = true;
            Debug.Log("on ground = " + collision.transform.name);
        }
        if (collision.transform.name == "floor_01_variability_05(Clone)")
        {
            inRange = true;
            Debug.Log("on ground = " + collision.transform.name);
        }
        
        
    }
    /*
    private void OnColliderStay(Collision collision)
    {
        if (collision.transform.name == "floor_01_variability_05")
        {
            inRange = true;
            Debug.Log("on ground = " + collision.transform.name);
        }
        if (collision.transform.name == "floor_01_variability_05(Clone)")
        {
            inRange = true;
            Debug.Log("on ground = " + collision.transform.name);
        }

        if (!inRange)
        {
            Destroy(this.gameObject);
        }
    }
    */
}
