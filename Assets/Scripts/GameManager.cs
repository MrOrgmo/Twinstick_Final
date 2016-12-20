using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public float spawnTime = 3f;
	public Transform[] spawnPoints;
	public GameObject[] enemies;
	public PlayerHealth playerHealth;
	public static int score;
	public int highScore;
	private GameObject enemy;
	
	public Text highScoreText;

	bool GameEnd = false;

	public Animator GOAnim;

	int[] highScores = new int[5];
	int i;
	Text scoreText;
	string highScoreKey = "HighScore";

	// Use this for initialization
	void Start () {

		InvokeRepeating ("Spawn", spawnTime, spawnTime);

		for (i = 0; i<highScores.Length; i++){
			highScoreKey = "HighScore"+(i+1).ToString();
			highScores[i] = PlayerPrefs.GetInt(highScoreKey,0);
		
		}
		
	}
	
	void Update(){
		
		if(GameEnd == true)
			return;

		if (playerHealth.isDead == true)
			GameOver();

		score = ScoreManager.score;
	}

	// Update is called once per frame
	void Spawn () {

		if (playerHealth.currentHealth <= 0f) {
			return;
		}

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		int randomEnemy = Random.Range (0, enemies.Length);

		enemy = enemies [randomEnemy];

		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	
	}


	public void GameOver(){

		GameEnd = true;

		GOAnim.SetTrigger ("GameOver");


		for (i = 0; i < highScores.Length; i++) {
			
			highScoreKey = "HighScore" + (i + 1).ToString ();
			highScore = PlayerPrefs.GetInt (highScoreKey, 0);

			Debug.Log(highScore.ToString());
			
			
			if(score > highScore){
				int temp = highScore;
				PlayerPrefs.SetInt(highScoreKey, score);
				
				score = temp;
				
			}
		}

		PlayerPrefs.Save();

		highScoreText.text = ("High Scores: " + System.Environment.NewLine +
							  "1: " + PlayerPrefs.GetInt("HighScore1", 0) + System.Environment.NewLine +
	                      	  "2: " + PlayerPrefs.GetInt("HighScore2", 0) + System.Environment.NewLine +
							  "3: " + PlayerPrefs.GetInt("HighScore3", 0) + System.Environment.NewLine +
							  "4: " + PlayerPrefs.GetInt("HighScore4", 0) + System.Environment.NewLine +
							  "5: " + PlayerPrefs.GetInt("HighScore5", 0) + System.Environment.NewLine);
		 
		 
		 }
		 }
		 