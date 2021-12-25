using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    //public GameObject coin;
    public float coinTime = 2.5f;
    private Transform viking;
    int randomCoin;

    bool inRange;

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
        coinPosition.x += 1.3f;
        if (Random.value < 0.009f)
        {
            Instantiate(this, coinPosition + viking.forward * 20, transform.rotation);
        }
        
    }
    /*
    IEnumerator spawnCoin()
    {
        yield return new WaitForSeconds(coinTime);
        spawn();
    }
    void spawn()
    {
        //randomCoin = Random.Range(0, coin.Length);//最右邊 is exclusive

        Vector3 coinPosition = viking.position;
        //coinPosition.y = -0.2f;
        //coin[0].transform.Rotate(new Vector3(100 * Time.deltaTime, 0, 0));
        //在修一下！
        coinPosition.x += 1.3f;
        
        //Quaternion coinDirec = coin[randomCoin].transform.rotation;
        //coinDirec.x = 180f;
        
        //transform.LookAt(viking);

        //coin[randomCoin].transform.Rotate(viking.forward);
        

        
        Instantiate(this, coinPosition + viking.forward * 20, transform.rotation);

        //coin[randomCoin].transform.LookAt(viking);
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
        if (!inRange)
        {
            Destroy(this.gameObject);
        }
    }
    
}
