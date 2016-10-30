using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;


	private Rigidbody rb;
	private int count; //what we need to reference for high scores


	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0; //initial score
		SetCountText ();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);


		if (Input.GetButtonDown("Jump")) {
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 3, 0),ForceMode.Impulse); //Make ball jump into the air when the space bar is pressed
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false); //remove pickup from field after being picked up
			count = count + 1; //add 1 when each pickup is picked up
			SetCountText ();
		}

	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString (); //update count tex to show how many pickups have been collected

	}
}