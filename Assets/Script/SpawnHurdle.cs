using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHurdle : MonoBehaviour
{
    public GameObject[] hurdles;
    public float hurdleTime = 3.2f;
    private Transform viking;
    int randomHurdle;
    
    private Vector3 xDirection = new Vector3(1, 0, 0);
    private Vector3 zDirection = new Vector3(0, 0, 1);


    // Start is called before the first frame update
    void Start()
    {
        viking = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(spawnHurdle());
    }
    IEnumerator spawnHurdle()
    {
        yield return new WaitForSeconds(hurdleTime);
        spawn();
    }
    void spawn()
    {
        randomHurdle = Random.Range(0, hurdles.Length);//maxExcusive is exclusive

        Vector3 hurdlePosition = viking.position;
        hurdlePosition.y = 7.8f;
        Instantiate(hurdles[randomHurdle], hurdlePosition + viking.forward * 20, hurdles[randomHurdle].transform.rotation);
        StartCoroutine(spawnHurdle());
    }
}
