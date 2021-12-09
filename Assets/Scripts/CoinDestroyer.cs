using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDestroyer : MonoBehaviour
{
    private float coin = 0;

    public TextMeshProUGUI textCoins;


    private void OnTriggerEnter(Collider other){

         if(other.transform.tag == "Player"){

            coin++;
            textCoins.text = "Coins:" + coin.ToString();

             Destroy(gameObject);
        
         }

    }
}
