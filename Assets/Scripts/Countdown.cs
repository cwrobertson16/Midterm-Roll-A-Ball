using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Allow access to edit text
using UnityEngine.SceneManagement; //Allow ability to load game over scene

public class Countdown : MonoBehaviour {


	public GameObject Player;
	public float myTimer = 30;  //Amount of time that player has
	public Text timerText;
	bool TimeUp;



	// Use this for initialization
	void Start () {

		timerText = GetComponent<Text>(); //grab text component to edit

		TimeUp = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		myTimer -= Time.deltaTime; //count downwards
		timerText.text = myTimer.ToString ("f2"); //make text component show current time left. "f2" used to make it control amount of decimals shown in time

		if (myTimer <= 0) {
			TimeUp = true;
			myTimer = 0;
			timerText.text = myTimer.ToString ("f0"); //stop timer from continuing into the negatives
			Player.SetActive (false); //Turns off the player's ball so they will stop collecting the pickups
		}
	
	}

}

//help from video: https://www.youtube.com/watch?v=D-6BbUozuCY