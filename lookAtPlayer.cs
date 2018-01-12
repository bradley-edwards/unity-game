using UnityEngine;
using System.Collections;

public class lookAtPlayer : MonoBehaviour {
	public GameObject player;
	private int speed = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		
		transform.rotation = Quaternion.RotateTowards(transform.rotation,
		                                              Quaternion.LookRotation(new Vector3(
			(transform.position.x - player.transform.position.x),
			((transform.position.y)),
			(transform.position.z - player.transform.position.z)
			)), step);

				
	}



	
}
