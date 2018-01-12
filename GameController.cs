using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public static int score;
	public static float gameTimer;
	public Text TimeText;
	public Text ScoreText;
	public Text SpeedText;
	public static bool levelOver;
	public static bool gameOver;

	public static GameController Instance;
	
//	void Awake ()   
//	{
//		if (Instance == null)
//		{
//			DontDestroyOnLoad(gameObject);
//			Instance = this;
//		}
//		else if (Instance != this)
//		{
//			Destroy (gameObject);
//		}
//	}


	void Awake() {
		gameTimer = 30;
		score = 0;
		gameOver = false;
		levelOver = false;
		GameText();
	}
	void Update() {
		if (gameTimer > 0) {
			gameTimer -= Time.deltaTime;
			GameText ();
		} else {
			levelOver = true;
		}
		if (levelOver == true) {
			Invoke ("LevelOver", 0.0f);
		}
		if (gameOver == true) {
			GameOver();
		}
	}




	void GameText(){
		SpeedText.text = player.accelerometerSpeed.ToString() + "  kph";
		TimeText.text = (Mathf.Round(gameTimer)).ToString();
		ScoreText.text = score.ToString ();
	}
	void GameOver(){

	}
	void LevelOver () {
		//float fadeTime = GameObject.Find ("Game Controller").GetComponent<SceneFading>().BeginFade (1);
		//yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel ("levelSelect");
	}
		
}