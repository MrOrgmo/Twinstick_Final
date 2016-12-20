using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public int highScore;
	int[] highScores = new int[5];
	int i;
	string highScoreKey = "";

	public GameObject ScorePanel;

	public Text highScoreText;

	// Use this for initialization
	void Start () {
	
		for (i = 0; i<highScores.Length; i++){
			highScoreKey = "HighScore"+(i+1).ToString();
			highScores[i] = PlayerPrefs.GetInt(highScoreKey,0);
			
		}

	}
	
	// Update is called once per frame
	public void LoadGame () {
	
		Application.LoadLevel ("main");

	}


	public void HighScores(){
	
		ScorePanel.SetActive(true);

		highScoreText.text = ("High Scores: " + System.Environment.NewLine +
		                      "1: " + PlayerPrefs.GetInt("HighScore1", 0) + System.Environment.NewLine +
		                      "2: " + PlayerPrefs.GetInt("HighScore2", 0) + System.Environment.NewLine +
		                      "3: " + PlayerPrefs.GetInt("HighScore3", 0) + System.Environment.NewLine +
		                      "4: " + PlayerPrefs.GetInt("HighScore4", 0) + System.Environment.NewLine +
		                      "5: " + PlayerPrefs.GetInt("HighScore5", 0) + System.Environment.NewLine);
	}



	public void ExitScores(){

		ScorePanel.SetActive (false);
	}

	public void ExitApp(){

		Application.Quit ();
	}


}
