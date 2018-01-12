using UnityEngine;
using System.Collections;

public class mainSoundTrack : MonoBehaviour {
	public GameObject cam;
	public AudioClip soundtrack;
	public static GameObject instance;
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this.gameObject;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	void Start(){
		cam = GameObject.Find("Main Camera");
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = soundtrack;
		audio.Play ();
	}
	void Update() {
		this.transform.position = cam.transform.position;
	}

}
