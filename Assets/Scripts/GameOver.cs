using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // get gameover UI element and components
    public GameObject gameOverUI;
    public TMP_Text gameOverTitle;
    public TMP_Text gameOverText;
    public Button restartButton;
    public TMP_Text restartButtonText;

    // Start is called before the first frame update
    void Start()
    {
        // make sure that the game is not paused when starting
        Time.timeScale = 1;

        // disable unwanted UI elements on startup
        gameOverUI.SetActive(false);

        // add listener script to restart button
        restartButton.onClick.AddListener(RestartGame);
    }

    public void DisplayGameOverUI(bool win) {
        /* 
        - stop time
        - sync respawnCounter with Player_Controller script
        - sync collectedCoins with Player_Controller script
        */
        Time.timeScale = 0;
        int respawnCounter = gameObject.GetComponent<Player_Controller>().respawnCounter;
        int collectedCoins = gameObject.GetComponent<Player_Controller>().collectedCoins;

        if (win) 
        {
            // sync time left with currentTime value from Time_Limit script
            string timeLeft = gameObject.GetComponent<Time_Limit>().timerText.text;

            // change title and button text for flavor
            // change information text to display tries, time left and collected coins
            gameOverTitle.text = "Thee wonneth!";
            restartButtonText.text = "Hie up and keepeth walking!";
            gameOverText.text = "I congratulate thee, brave knight.  Thee hath reached the next chamb'r with <b><color=#2e7aec>" + timeLeft + 
            "</color></b> left and <b><color=#ffc107>" + collectedCoins + "</color></b> golden chink(s) in thy pocket. \n" + 
            "But wherefore didst thee runneth backeth to the entrance <b><color=#f35218>" + respawnCounter + "</color></b> time(s)? Nev'rmind ...";
        } 
        else 
        {
            // change title and button text for flavor
            // change information text to display tries and encouraging start-again message
            gameOverTitle.text = "Game Ov'r";
            restartButtonText.text = "Anoth'r adventure awaits ...";
            gameOverText.text = "Oh nay, thee hath tried but thy feareth ov'rcame thee once again. \n" + 
            "Thankfully, nay one did notice thee running backeth to the entrance <b><color=#f35218>" + respawnCounter + "</color></b> time(s)!";
        }

        // activate UI elements
        gameOverUI.SetActive(true);
    }

    public void RestartGame() {
        /* 
        - reload the scene
        - reset the timer (within Time_Limit.cs) when restarting
        - unpause the game
        */
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Anoth'r adventure begins. (restart successful)");
    }
}
