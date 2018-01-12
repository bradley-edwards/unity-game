using UnityEngine;
using System.Collections;

public class boundary : MonoBehaviour {
	public AudioClip[] audioClip;
	public static bool playLose;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void OnTriggerExit (Collider Other) {
		if (Other.gameObject.name == "Player") {
			PlaySound (0);
			Invoke ("resetLevel", 2.3f);
		}
		if (Other.gameObject.name == "BananaPeelComplete(Clone)") {
			Destroy (Other.gameObject);

		}
	}


	void PlaySound(int clip) {
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = audioClip[clip];
		audio.PlayOneShot (audio.clip, 1f);
	}
	void resetLevel() {
		GameController.levelOver = true;
	}
}
