using UnityEngine;
using System.Collections;

public class Trigger_Rotate : MonoBehaviour {

	public float rotateAmount = -45;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if(other.collider.gameObject.name == "Robber"){
			other.collider.gameObject.transform.Rotate(new Vector3(0,rotateAmount,0),Space.World);
			//GameObject camera;
			//camera = GameObject.Find("Main Camera");

			//camera.transform.Rotate(new Vector3(0,rotateAmount,0),Space.World);
			Destroy(this);
		}
	}
}
