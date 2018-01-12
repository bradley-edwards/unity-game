using UnityEngine;
using System.Collections;

public class SceneFading : MonoBehaviour {
	public Texture2D fadeOutTexture; // overlays screne iwth black
	public float fadeSpeed = 0.8f;

	private int drawDepth = -1000; // drawn last (renders on top)
	private float alpha = 1.0f;		// opaque to start;
	private int fadeDir = -1; // -1 to fade in, 1 to fade out



	void OnGUI () {
		alpha += fadeDir * fadeSpeed * Time.deltaTime;

		//clamp alpha between 0 and 1
		alpha = Mathf.Clamp01 (alpha);

		//set colour of GUI.
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth; // set black texture of top
		GUI.DrawTexture ( new Rect (0,0,Screen.width, Screen.height), fadeOutTexture ); // draw texture over entire screen
	}
	//set fade in or out
	public float BeginFade (int direction) {
		fadeDir = direction;
		return(fadeSpeed); // returns a time to load level with

	}

	void OnLevelWasLoaded() {
		alpha = 1;
		BeginFade (-1); //fade in
	}
	
	
}
