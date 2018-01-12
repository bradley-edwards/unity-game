using UnityEngine;
using System.Collections;

public class restartGame : MonoBehaviour {

	// Use this for initialization
	public void RestartGame() {
		PlayerPrefs.DeleteAll ();
		Application.LoadLevel (Application.loadedLevel);
	}
}
