using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Allow access to edit text
using UnityEngine.SceneManagement; //Allow ability to load game over scene

public class Countdown : MonoBehaviour {


	public float myTimer = 30;  //Amount of time that player has
	public Text timerText;
	public float resetDelay = 0f;



	// Use this for initialization
	void Start () {

		timerText = GetComponent<Text>(); //grab text component to edit
	
	}
	
	// Update is called once per frame
	void Update () {

		myTimer -= Time.deltaTime; //count downwards
		timerText.text = myTimer.ToString ("f2"); //make text component show current time left. "f2" used to make it control amount of decimals shown in time

		if (myTimer <= 0) {
			Invoke ("Reset", resetDelay);	//Go to menu when time runs out
		}
	
	}

	void Reset (){
		Time.timeScale = 0f;
		SceneManager.LoadScene ("GameOver");
	}
}

//help from video: https://www.youtube.com/watch?v=D-6BbUozuCY