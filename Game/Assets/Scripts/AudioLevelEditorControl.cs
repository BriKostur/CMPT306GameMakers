using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLevelEditorControl : MonoBehaviour {

	public AudioSource slow; // Plug slower track in here
	public AudioSource fast; // Plug faster track in here

	// Used to adjust where in audio file to loop to
	bool speedForLoop = false; // false = slow, true = fast

	float slowDownFactor = 1.21587f; // Speed factor adjustment to go fast -> slow
	float speedUpFactor = 0.82246f; // Speed factor adjustment to go slow -> fast

	float fadeRate = 3.0f;
	float interpolationValue = 0.0f;
	float fadedVolume;
	bool fadeAudioOut = false;

	// Use this for initialization
	void Start () {
		slow.Play (); // Play slow track on Level Editor entry
	}

	void Update() {
		if (fadeAudioOut == true) {
			audioFade ();
		}
	}

	void FixedUpdate() {
		if (speedForLoop == false && slow.isPlaying == false) {
			slow.time = 65.456f; // Loop position
			slow.Play ();
		}
		if (speedForLoop == true && fast.isPlaying == false) {
			fast.time = 53.834f; // Loop position
			fast.Play ();
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			fadeAudioOut = true;
			Debug.Log (fadeAudioOut);
		}
	}

	// Switch to fast (pressed "Play" in editor)
	public void fastAudio () {
		speedForLoop = true; // Set bool that we are playing fast track
		float time = slow.time; // Save current time position of slow track
		float playTime = time * speedUpFactor; // Time position to set fast track
		slow.Stop ();
		fast.time = playTime;
		fast.Play ();
	}

	// Switch to slow (pressed "p" on keyboard)
	public void slowAudio() {
		speedForLoop = false; // Set bool that we are playing slow track
		float time = fast.time; // Save current time position of fast track
		float playTime = time * slowDownFactor; // Time position to set slow track
		fast.Stop ();
		slow.time = playTime;
		slow.Play ();
	}

	void audioFade() {
		interpolationValue += Time.deltaTime * fadeRate;
		fadedVolume = Mathf.Lerp (1f, 0f, interpolationValue);
		slow.volume = fadedVolume;

		// Modify interpolation values to emulate a more realistic fade-out
		if (slow.volume >= 0.4f && slow.volume < 0.5f) {
			fadeRate = 1.0f;
		}
		if (slow.volume >= 0.3f && slow.volume < 0.4f) {
			fadeRate = 0.8f;
		}
		if (slow.volume >= 0.2f && slow.volume < 0.3f) {
			fadeRate = 0.6f;
		}
		if (slow.volume >= 0.1f && slow.volume < 0.2f) {
			fadeRate = 0.4f;
		}
		if (slow.volume >= 0.03f && slow.volume < 0.1f) {
			fadeRate = 0.1f;
		}
		if (slow.volume < 0.03f) {
			fadeRate = 0.05f;
		}
	}
}
