using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime); //Set pick ups to rotate on updates
	
	}
}
