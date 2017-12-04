using UnityEngine;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
	public Image image;
	public float fadeRate = 1.0f;

	float interpolationValue = 0.0f;
	float transparency = 0.0f;
	Color imageColor;
	bool isFading = false;
	bool fadeOut;

	void Awake()
	{
		imageColor = image.color;
		isFading = false;
	}

	void Update()
	{
		if (isFading)
			FadeImage();
	}

	public void initiate(bool val)
	{
		isFading = true;
		fadeOut = val;
	}

	// Bandaid fix for UCL fade
	public void initiateUCLFade() {
		isFading = true;
	}

	public void FadeImage()
	{
		interpolationValue += Time.deltaTime * fadeRate;
		if (fadeOut == false) { // Fade an image in from alpha 0 to 255
			transparency = Mathf.Lerp (0f, 1f, interpolationValue);
		} else { // Fade an image out from alpha 255 to 0
			transparency = Mathf.Lerp (1f, 0f, interpolationValue);
		}
		image.color = new Color (imageColor.r, imageColor.g, imageColor.b, transparency);

        Physics2D.gravity = new Vector2(0, -9.81f);

    }
}