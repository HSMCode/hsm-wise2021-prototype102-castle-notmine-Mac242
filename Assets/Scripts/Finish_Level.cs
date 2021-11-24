using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Finish_Level : MonoBehaviour
{
    public GameObject player;
    public GameObject winPanel;

    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
    }

    private void OnCollisionEnter(Collision col) // check for Collision
    {
        if (col.gameObject.CompareTag("Finish")) // Check if Player collides with Finish (Tagged with Finish)
        {
            Debug.Log("WIN");
            winPanel.SetActive(true); // show Winning Message
            player.SetActive(false); // hide the Player

        }
    }
}
