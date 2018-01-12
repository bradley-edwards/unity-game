using UnityEngine;
using System.Collections;

public class PickBanana : MonoBehaviour {
	public AudioClip banana;


    void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			GameController.score += 10;
			GameController.gameTimer += 3;
			AudioSource.PlayClipAtPoint(banana, transform.position);
			this.gameObject.SetActive(false);
		}
    }
}