using UnityEngine;
using System.Collections;

public class portal : MonoBehaviour {
	public AudioClip[] audioClip;
	public GameObject levelComplete;

	void Awake(){
		levelComplete.gameObject.SetActive (false);
	}
	void OnTriggerEnter (Collider Other) {
		if (Other.gameObject.name == "Player") {
			PlaySound (0);
				levelComplete.gameObject.SetActive(true);
			Time.timeScale = 0.01f;
			Invoke ("mainLevel", 0.02f);
		}
	}
	void PlaySound(int clip) {
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = audioClip[clip];
		audio.PlayOneShot (audio.clip, 1f);
	}
	void mainLevel(){
		if (Application.loadedLevelName == "Level1") {
			PlayerPrefs.SetInt ("Level2", 1);
		}
		if (Application.loadedLevelName == "Level2") {
			PlayerPrefs.SetInt ("Level3", 1);
		}
		if (Application.loadedLevelName == "Level3") {
			PlayerPrefs.SetInt ("Level4", 1);
		}
		if (Application.loadedLevelName == "Level4") {
			PlayerPrefs.SetInt ("Level5", 1);
		}
		if (Application.loadedLevelName == "Level5") {
			PlayerPrefs.SetInt ("Level6", 1);
		}
		if (Application.loadedLevelName == "Level6") {
			PlayerPrefs.SetInt ("Level7", 1);
		}
		if (Application.loadedLevelName == "Level7") {
			PlayerPrefs.SetInt ("Level8", 1);
		}
		if (Application.loadedLevelName == "Level8") {
			PlayerPrefs.SetInt ("Level9", 1);
		}
		if (Application.loadedLevelName == "Level9") {
			PlayerPrefs.SetInt ("Level10", 1);
		}
		if (Application.loadedLevelName == "Level10") {
			Application.LoadLevel ("winLevel");
		} else {
			Application.LoadLevel ("levelSelect");
		}
		Time.timeScale = 1;
	}

}
