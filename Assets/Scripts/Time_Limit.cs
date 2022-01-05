using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Time_Limit : MonoBehaviour
{
    // set fixed time limit and UI element where it will be displayed
    public float timeLimit = 30;
    public float currentTime;
    public TMP_Text timerText;

    void Start() {
        // set the current time to timeLimit value (counter initialized)
        currentTime = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        // refresh time limit counter in UI
        DisplayTime(currentTime);

        // count down as long as there is time left
        if (currentTime > 0) {
            currentTime -= Time.deltaTime;
        }
        // call losing function when no time is left
        else {
            currentTime = 0;
            gameObject.GetComponent<GameOver>().DisplayGameOverUI(false);
        }
    }

    void DisplayTime(float timeToDisplay)
    {        
        // format countdown for UI
        float minutes = Mathf.FloorToInt(timeToDisplay / timeLimit);
        float seconds = Mathf.FloorToInt(timeToDisplay % timeLimit);

        // overwrite timer UI element
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
