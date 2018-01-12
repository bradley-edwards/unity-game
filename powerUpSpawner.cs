using UnityEngine;
using System.Collections;

public class powerUpSpawner : MonoBehaviour {

	public Transform[] SpawnPoints;
	public GameObject Obstacles;
	public GameObject[] powerups;
	public GameObject powerUpObject;
	private int x;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update (){
		if (Time.time >= x) {
			int spawnIndex = Random.Range (0, SpawnPoints.Length);
			int powerUp = Random.Range (0, powerups.Length);
			powerUpObject = Instantiate (powerups [powerUp], new Vector3(SpawnPoints[spawnIndex].position.x, SpawnPoints[spawnIndex].position.y + 1, SpawnPoints[spawnIndex].position.z), SpawnPoints[spawnIndex].rotation) as GameObject;
			powerUpObject.transform.SetParent(Obstacles.transform);
			if (SpawnPoints[spawnIndex] != null) {
				SpawnPoints[spawnIndex] = null;
				x+=3;
			}
		}
	}
}
