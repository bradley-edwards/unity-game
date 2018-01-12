using UnityEngine;
using System.Collections;

public class FansRotatingRight : MonoBehaviour {
	private int x;
	private float counter;
	// Use this for initialization
	void Start () {
		x = 0;
		counter = -1;
	}
	
	// Update is called once per frame
	void Update () {
			transform.Translate (counter * Vector3.left * Time.deltaTime);
		
		if (Time.time >= x) {
			x = x + 3;
			counter = counter * -1;
		}
	}
}