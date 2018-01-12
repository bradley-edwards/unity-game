using UnityEngine;
using System.Collections;

public class bossShooter : MonoBehaviour {

	private float timer = 0;
	private GameObject bumper;
	public GameObject player;
	public GameObject Obstacles;
	public GameObject bumperPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (player.transform.position);
		timer += Time.deltaTime;
		if (timer >= 2) {
			timer = 0;
			bumper = Instantiate (bumperPrefab, transform.position + transform.forward, transform.rotation) as GameObject;
			bumper.transform.SetParent (Obstacles.transform);
		}
	}
}
