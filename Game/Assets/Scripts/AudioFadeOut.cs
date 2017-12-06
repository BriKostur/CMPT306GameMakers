using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeOut : MonoBehaviour {

	float fadeRate = 3.0f;
	float interpolationValue = 0.0f;
	float fadedVolume;

	public void audioFade(AudioSource trackName) {
		interpolationValue += Time.deltaTime * fadeRate;
		fadedVolume = Mathf.Lerp (1f, 0f, interpolationValue);
		trackName.volume = fadedVolume;

		// Modify interpolation values to emulate a more realistic fade-out
		if (trackName.volume >= 0.4f && trackName.volume < 0.5f) {
			fadeRate = 1.0f;
		}
		if (trackName.volume >= 0.3f && trackName.volume < 0.4f) {
			fadeRate = 0.8f;
		}
		if (trackName.volume >= 0.2f && trackName.volume < 0.3f) {
			fadeRate = 0.6f;
		}
		if (trackName.volume >= 0.1f && trackName.volume < 0.2f) {
			fadeRate = 0.4f;
		}
		if (trackName.volume >= 0.03f && trackName.volume < 0.1f) {
			fadeRate = 0.1f;
		}
		if (trackName.volume < 0.03f) {
			fadeRate = 0.05f;
		}
	}
}
