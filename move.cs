using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public GameObject stage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (this.transform.position.x, (stage.transform.position.y - 50f), this.transform.position.z);
	}
}
