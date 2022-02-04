using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	// components for music
	public AudioSource musicSource;
    public AudioClip backgroundMusic;

    // components for sound effects
    public AudioSource clipSource;
    public AudioClip winningClip;
    public AudioClip losingClip;
    public AudioClip coinClip;
    public AudioClip puddleClip;
    public AudioClip resetClip;

	// Singleton instance
	public static SoundManager Instance = null;
	
	// Initialize the singleton instance
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene
		DontDestroyOnLoad (gameObject);
	}

    public void PlaySoundEffect(AudioClip clip, float volume) {
        clipSource.PlayOneShot(clip, volume);
    }

    public void PlayMusicBox() {
        if (!musicSource.isPlaying) {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    public void StopMusicBox() {
        musicSource.Stop();
    }
}
