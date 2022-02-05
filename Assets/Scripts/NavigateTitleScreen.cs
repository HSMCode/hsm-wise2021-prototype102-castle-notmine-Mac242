using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigateTitleScreen : MonoBehaviour
{
    public Button playButton;
    public Button creditsButton;
    public Button returnButton;
    public GameObject creditsUI;

    void Start() {
        // start playing background music
        SoundManager.Instance.PlayMusicBox();

        // add listener script to play button
        playButton.onClick.AddListener(FindObjectOfType<LevelManager>().StartPlaying);

        // add listener script to credits button
        creditsButton.onClick.AddListener(ShowCredits);

        // add listener script to return button
        returnButton.onClick.AddListener(HideCredits);
    }

    public void ShowCredits() {
        creditsUI.SetActive(true);
    }    
    public void HideCredits() {
        creditsUI.SetActive(false);
    }
}
