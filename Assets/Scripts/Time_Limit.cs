using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Time_Limit : MonoBehaviour
{
    public float timeValue = 30;
    public Text timerText;
    public GameObject player;
    public Transform spawnPoint; // Position where the player should respawn



    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Time is up! Try again!");
            player.transform.position = spawnPoint.transform.position; // Reset Player Position
            timeValue += 30;
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 30);
        float seconds = Mathf.FloorToInt(timeToDisplay % 30);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    
    // Time stops counting when Finish Point is reached
    private void OnCollisionEnter(Collision col) // check for Collision
    {
        if (col.gameObject.CompareTag("Finish")) // Check if Player collides with Finish (Tagged with Finish)
        {
            timeValue = 0;
        }
    }



}
