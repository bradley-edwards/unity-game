using UnityEngine;
using System.Collections;

public class winGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("WinGame", 1.5f);
	}
	
	// Update is called once per frame
	void WinGame () {
		Application.LoadLevel ("levelSelect");
	}
}
