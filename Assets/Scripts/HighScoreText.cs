using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*public class HighScoreText : MonoBehaviour {

	Text ScoreText;

	public int highScore;
	int[] highScores = new int[5];

	string highScoreKey = "HighScore";

	private int i;
	private int score;

	// Use this for initialization
	void Start () {

		ScoreText = GetComponent<Text>();

		score = ScoreManager.score;
	}
	
	// Update is called once per frame
	public void ShowScores () {



		for (i = 0; i < highScores.Length; i++) {

			highScoreKey = "HighScore" + (i + 1).ToString ();
			highScore = PlayerPrefs.GetInt (highScoreKey, 0);


			if(score > highScore){
				int temp = highScore;
				PlayerPrefs.SetInt(highScoreKey, score);

				score = temp;

			}
		}

		ScoreText.text = ("1: " + PlayerPrefs.GetInt(highScoreKey, 0) + System.Environment.NewLine +
		                  "2: " + PlayerPrefs.GetInt(highScoreKey, 1) +
		                  "\\n 3: " + PlayerPrefs.GetInt(highScoreKey, 2) +
		                  "\\n 4: " + PlayerPrefs.GetInt(highScoreKey, 3) +
		                  "\\n 5: " + PlayerPrefs.GetInt(highScoreKey, 4));

	}
}
*/