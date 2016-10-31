using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player; //Need to refer to the player, as the camera will be affected by the player's status

	private Vector3 offset;		//initialize an offset

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position; //set offset amount
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset; //combine offset amount with player position to set camera's position
	}
}
