using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public Text coin;
    public Text time;

    public void Setup(int coinCount, float survivalTime) 
    {
        gameObject.SetActive(true);

        coin.text = "$Coin:" + coinCount;
        time.text = "Survival Time:" + survivalTime.ToString("F2");
    }
}
