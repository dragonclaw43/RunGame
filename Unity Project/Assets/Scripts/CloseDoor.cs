using UnityEngine;
using System.Collections;

public class CloseDoor : MonoBehaviour {

	public GameObject doorL = null;
	public GameObject doorR = null;
	public float closeDelay = 1.0f;
	public float closeSpeed = 2.0f;
	public bool startOpen = false;
	public float doorOpenAngle = 150f;

	bool rotationStarted = false;
	bool leftDone = false;
	bool rightDone = false;
	// Use this for initialization
	void Start () {
		if(startOpen == true){
			if(doorL != null){
				doorL.transform.Rotate(new Vector3(0,doorOpenAngle,0));
			}
			if(doorR != null){
				doorR.transform.Rotate(new Vector3(0,-doorOpenAngle,0));
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(rotationStarted == true){
			// if open, close doors after colliding
			if(startOpen == true){
				if(doorL != null){
					if(doorL.transform.rotation.y >= 0){
						doorL.transform.Rotate (Vector3.down*closeSpeed);
					}
					else{
						leftDone = true;
					}
				}
				if(doorR != null){
					if(doorR.transform.rotation.y <= 0){
						doorR.transform.Rotate (Vector3.up*closeSpeed);
					}
					else{
						rightDone = true;
					}
				}
			}
			// if closed, open doors after colliding
			else{
				Debug.Log(doorL.transform.rotation.y + " " + doorR.transform.rotation.y);
				if(doorL != null){
					if(doorL.transform.rotation.y >= (-(doorOpenAngle+180)/360)){
						doorL.transform.Rotate (Vector3.down*closeSpeed);
					}
					else{
						leftDone = true;
					}
				}
				if(doorR != null){
					if(doorR.transform.rotation.y <= ((doorOpenAngle+180)/360)){
						doorR.transform.Rotate (Vector3.up*closeSpeed);
					}
					else{
						rightDone = true;
					}
				}
			}
		}
		if(leftDone == true && rightDone == true){
			//Destroy(this);
		}
	}

	void OnTriggerEnter (Collider other) {
		if(other.collider.gameObject.name == "Robber"){
			StartCoroutine(Wait());
			rotationStarted = true;
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (closeDelay);
	}
}
