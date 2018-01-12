using UnityEngine;
using System.Collections;

public class mainMenuTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Level2", 1);
		StartCoroutine (Time());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator Time() {

		yield return new WaitForSeconds (2f);
		Application.LoadLevel (5);
	}
}
