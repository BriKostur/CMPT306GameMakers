using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioTitleScreenControl : MonoBehaviour {
		
	// Used to control initializing audio source to play
	public AudioSource titleScreenMusic;

	// Used to make call to AudioFadeOut script to fade-out track
	private bool isFading = false;

	void Start() {
		titleScreenMusic.Play ();
	}
		
	void Update() {
		// Call fade-out function if isFading is true
		if (isFading == true) {
			this.GetComponent<AudioFadeOut> ().audioFade (titleScreenMusic);
		}

		// Set audio loop if end-of-track is reached
		if (titleScreenMusic.time >= 101.999f) {
			titleScreenMusic.Stop ();
			titleScreenMusic.time = 6.015f;
			titleScreenMusic.Play ();
		}
	}

	public void initiate() {
		isFading = true;
		Debug.Log ("Message received from LoadLevel.cs");
	}
}
