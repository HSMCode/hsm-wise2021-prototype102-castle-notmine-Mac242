using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Return to Title Screen when pressing ESC
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScreen");
        }

        // Reload Scene when pressing R
        if (Input.GetKeyUp(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void StartPlaying() {
        SceneManager.LoadScene("FrightKnight");
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
