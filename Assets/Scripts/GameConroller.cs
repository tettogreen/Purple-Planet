using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameConroller : MonoBehaviour {
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	private int score;


	// Use this for initialization
	void Start ()
	{
//		gameOver = false;
//		restart = true;
//		restartText.text = "";
//		gameOverText.text = "";
//		score = 0;
//		UpdateScore ();
	}

	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);	
		}

	}

	// Update is called once per frame
	public void AddScore (int newScoreValue)
	{
//		score += newScoreValue;
//		UpdateScore ();
	}
	
//	void UpdateScore ()
//	{
//		scoreText.text = "Score: " + score;
//	}
//	
//	public void GameOver ()
//	{
//		gameOverText.text = "Game Over!";
//		gameOver = true;
//	}

	public void GameOver ()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

}
