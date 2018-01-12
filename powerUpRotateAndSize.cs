using UnityEngine;
using System.Collections;

public class powerUpRotateAndSize : MonoBehaviour {
	private float marker = -1f;
	private int x;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime * 150);

		transform.localScale += Vector3.one * Time.deltaTime * marker / 2;
		if (Time.time >= x) {
			x += 1;
			marker = marker * -1;
		}
	}
}
