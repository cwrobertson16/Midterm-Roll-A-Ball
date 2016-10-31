//Conrad Robertson
//LMSC-281 Fall 2016
//Midterm Project

using UnityEngine;
using System.Collections;
using UnityEngine.UI; //so that we can access the text
using UnityEngine.SceneManagement; //so that we can restart the game

public class PlayerController : MonoBehaviour {

	public float speed;			//Floating point variable to store the player's movement speed
	public Text countText;		//Store a reference to the UI Text component which will display the number of pickups collected


	private Rigidbody rb;

	private int count; 		//Integer to store the number of pickups collected so far

	public int highScore = 0;
	string highScoreKey = "HighScore"; //experimenting with displaying high score table
	int[] highScores = new int[10];		//Array needed to store high scores


	void Start ()
	{
		rb = GetComponent<Rigidbody>();		//access rigidbody component of player
		count = 0;	 //initial score
		SetCountText ();

		//Load the highScores array from player prefs if it is there, 0 otherwise.
		//use this for a leaderboard style where you save several highscores
		for (int i = 0; i<highScores.Length; i++){

			//Get the highScore from 1 - length of highScores array length
			highScoreKey = "HighScore"+(i+1).ToString();
			highScore = PlayerPrefs.GetInt(highScoreKey,0);
			Debug.Log (highScoreKey + " is " + highScore);
		}

	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal"); //allow user to move ball horizontally
		float moveVertical = Input.GetAxis ("Vertical"); //allow user to move pall vertically

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);		//add force to the player for movement

		//Make ball jump into the air when the space bar is pressed
		if (Input.GetButtonDown("Jump")) {
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 6, 0),ForceMode.Impulse);
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))		//find objects with tag "pick up" to be manipulated
		{
			other.gameObject.SetActive (false); //remove pickup from field after being picked up
			count = count + 1; //add 1 when each pickup is picked up
			SetCountText ();
		}

	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString (); //update count text to show how many pickups have been collected

		HighScoreProcess ();
	}

	void HighScoreProcess() {
		Debug.Log ("highscore here");

		//use this for a leaderboard style where you save several highscores
		for (int i = 0; i<highScores.Length; i++){

			//Get the highScore from 1 - length of highScores array length
			highScoreKey = "HighScore"+(i+1).ToString();
			highScore = PlayerPrefs.GetInt(highScoreKey,0);

			//if score is greater, store previous highScore Set a new highScore
			//set score to previous highScore, and try again
			//Once score is greater, it will always be for the
			//remaining list, so the top will always be 
			//updated
			if(count>highScore){
				int temp = highScore;
				PlayerPrefs.SetInt(highScoreKey,count);
				count = temp;
			}
		}
	}
		
}
	


