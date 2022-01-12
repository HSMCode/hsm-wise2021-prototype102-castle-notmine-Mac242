using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoin : MonoBehaviour
{

    // save collected coins to bag and assign UI variable
    public int collectedCoins = 0;
    public TMP_Text textCoins;

    // check for collisions of player
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Coin")) {
            collectedCoins++;

            // add collected coins to UI
            textCoins.text = collectedCoins.ToString() + " chink(s),";

            // add  bonus seconds to timer to get out of nook
            gameObject.GetComponent<Time_Limit>().timeLimit += 3;
            gameObject.GetComponent<Time_Limit>().currentTime += 3;

            // set collected coin inactive and destroy after short delay
            col.gameObject.SetActive(false);
            Destroy(col.gameObject, 0.5f);
        }
    }
}
