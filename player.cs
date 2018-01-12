using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public float CameraSpeed;
	public float Acceleration;
	public float CameraMoveSpeed;
	
	private Rigidbody rb;
	public Vector3 AxisOfThrust;
	private Vector3 CameraRigCurrentPosition;
	
	
	public GameObject Pivot;
	public GameObject Stage;
	public GameObject CameraRig;
	
	public Quaternion XStageRotation;
	public Quaternion ZStageRotation;
	public Quaternion StageTargetRotation;
	
	private Quaternion CurrentRotation;
	
	private float distToGround;




	public GameObject shot;
	
	public float fireRate;
	private float nextFire;

	private bool powerUp;
	private float timer;


	public AudioClip[] audioClip;
	public static float accelerometerSpeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		CurrentRotation = CameraRig.transform.rotation;
		CameraRigCurrentPosition = CameraRig.transform.position;
		distToGround = 1;
		Acceleration = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
	//phone version
	//float horizontal = Input.acceleration.y;
	//float vertical = Input.acceleration.x;
		
		
		AxisOfThrust = CameraRig.transform.rotation * new Vector3 (horizontal, 0.0f, vertical);
		XStageRotation = Quaternion.AngleAxis (Mathf.Pow (vertical, 2) * 2, CameraRig.transform.right * vertical); 
		ZStageRotation = Quaternion.AngleAxis (Mathf.Pow (horizontal, 2) * -5, CameraRig.transform.forward * horizontal);


		if (Input.GetKeyDown("space") && IsGrounded() && GameController.score > 0) {
			rb.AddForce (0, 200 * rb.mass, 0);
			GameController.score -= 1;
			PlaySound (0);
		}



		if (Input.GetKeyDown("e") && Time.time > nextFire && GameController.score > 1) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, new Vector3 (transform.position.x, transform.position.y + 0.4f, transform.position.z), CameraRig.transform.rotation);
			GameController.score -= 2;
			PlaySound(1);
		}
		distToGround = this.transform.localScale.x / 2;
		MoveCamera ();
	}
	
	void FixedUpdate() {
		//pivot stage around ball
		Pivot.transform.position = transform.position;
		Stage.transform.SetParent (Pivot.transform);
		Pivot.transform.rotation = XStageRotation * ZStageRotation;
		Stage.transform.SetParent (null);
		//push ball in direction camera is facing
		rb.AddForce (AxisOfThrust * (Mathf.Pow(3.0f, Acceleration)));
		

		if (powerUp == true) {
			timer += Time.deltaTime;
			if (timer >= 8) {
				resetPowerUps();
				powerUp = false;
			}
		}

		accelerometerSpeed = Mathf.Round(Vector3.Magnitude(rb.velocity));
	}
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.CompareTag("speedPowerUp")) {
			Destroy(collision.gameObject);
			resetPowerUps();
			this.Acceleration = 3f;
			powerUp = true;
			PlaySound (2);
		}
		if (collision.gameObject.CompareTag("miniPowerUp")) {
			Destroy(collision.gameObject);
			resetPowerUps();
			this.transform.localScale = new Vector3 (1, 1, 1);
			this.Acceleration = 1.5f;
			rb.mass = 0.66f;
			rb.drag = 0.5f;
			powerUp = true;
			PlaySound (2);
		}
		if (collision.gameObject.CompareTag("bigPowerUp")) {
			Destroy(collision.gameObject);
			resetPowerUps();
			this.transform.localScale = new Vector3 (4, 4, 4);
			rb.mass = 3f;
			this.Acceleration = 2f;
			powerUp = true;
			PlaySound (2);
		}
		if (collision.gameObject.CompareTag ("randomPowerUp")) {
			Destroy(collision.gameObject);
			resetPowerUps();
			this.Acceleration = Random.Range(1, 2.5f);
			rb.drag = Random.Range (0, 2);
			rb.mass = Random.Range (0.2f, 3);
			this.transform.localScale = (Random.Range (0.5f,3) * Vector3.one);
			powerUp = true;
			PlaySound (2);
		}
	}

	void MoveCamera() {
		Vector3 CameraRigTargetPosition = transform.position;
		CameraRigCurrentPosition = Vector3.MoveTowards (CameraRigCurrentPosition, CameraRigTargetPosition, 1000 * Time.deltaTime);
		
		CameraRig.transform.position = Vector3.MoveTowards (CameraRigCurrentPosition, CameraRigTargetPosition, 1000 * Time.deltaTime);
		Vector3 velocity = new Vector3 (rb.velocity.x, 0.0f, rb.velocity.z);
		Quaternion TargetRotation = Quaternion.LookRotation(velocity.normalized, Vector3.up);
		CurrentRotation = Quaternion.Slerp (CurrentRotation, TargetRotation, velocity.magnitude / 100);
		CameraRig.transform.rotation = CurrentRotation;
	}
	void resetPowerUps(){
		this.Acceleration = 1.5f;
		rb.mass = 1.5f;
		this.transform.localScale = new Vector3 (2, 2, 2);
		timer = 0;
		rb.drag = 0;
		PlaySound (2);
	}


	void PlaySound(int clip) {
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = audioClip[clip];
		audio.PlayOneShot (audio.clip, 1f);
	}

	bool IsGrounded ()
	{
		return Physics.Raycast (transform.position, - Vector3.up, distToGround + 0.1f);
	}
}