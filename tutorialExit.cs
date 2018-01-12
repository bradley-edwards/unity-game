using UnityEngine;
using System.Collections;

public class tutorialExit : MonoBehaviour {
	public GameObject tutorial;
	// Use this for initialization
	public void TutorialExit () {
		tutorial.SetActive (false);
	}
}
