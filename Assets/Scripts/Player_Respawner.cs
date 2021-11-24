using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawner : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint; // Position where the player should respawn
    
    private void OnCollisionEnter(Collision col) // check for Collision
    {
        if (col.gameObject.CompareTag("Respawn"))  // Check if Player collides with Obstacles (Tagged with Respawn)
        {
            //Debug.Log("Collision");
            player.transform.position = spawnPoint.transform.position; // Reset Player Position
        }
        
    }
}
