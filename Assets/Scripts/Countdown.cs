//Conrad Robertson
//LMSC-281 Fall 2016
//Midterm Project

//THIS SCRIPT IS APPLIED TO THE TIMER (in heirarchy, Canvas -> Timer)

using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Allow access to edit text
using UnityEngine.SceneManagement; //so that we can restart the game

public class Countdown : MonoBehaviour {


	public GameObject Plane1;
	public GameObject Plane2;
	public GameObject Plane3;	//need to be able to access the planes (grounds) so we can affect them later
	public GameObject Plane4;

	public float myTimer = 30;  //Amount of time that player has
	public Text timerText;

	bool restart = false;

	string timeUp = "Time is up! Try Again?";	//string that will appear on restart button


	// Use this for initialization
	void Start () {

		timerText = GetComponent<Text>(); //grab text component to edit

	
	}
	
	// Update is called once per frame
	void Update () {

		myTimer -= Time.deltaTime; //count downwards
		timerText.text = myTimer.ToString ("f2"); //make text component show current time left. "f2" used to make it control amount of decimals shown in time (in this case, only 2 decimal points)

		if (myTimer <= 0) {
			myTimer = 0;
			timerText.text = myTimer.ToString ("f0"); //when time is up, ensure the time says "0" instead of displaying a few decimals below 0

			Plane1.SetActive (false);
			Plane2.SetActive (false);   //Remove floor so players cannot collect more pick ups
			Plane3.SetActive (false);  // Was originally the player ball, but setting it to false caused the necessary scripts attached to the player to turn off as well
			Plane4.SetActive (false);

			GameOver(); //create a game over function we can to make restart bool "true"
		}
	
	}

	void GameOver (){
		Debug.Log ("Time is up!");
		restart = true;
	}

	void OnGUI () {
		if (restart) {
			if (GUI.Button(new Rect(1130, 700, 300, 30), timeUp)) {		//if restart is true, create a button the player can click to restart the game
				restart = false;
				SceneManager.LoadScene ("Roll-A-Ball");
			}
		}
	}

}

//countdown timer help from video: https://www.youtube.com/watch?v=D-6BbUozuCY