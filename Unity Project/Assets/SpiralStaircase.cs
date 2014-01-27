using UnityEngine;
using System.Collections;

public class SpiralStaircase : MonoBehaviour {

	public bool goingUp = true;

	bool inRange = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			if(inRange){
				moveCharacter();
				Debug.Log("going Up");
			}
		}
	}

	void OnGUI(){
		if(inRange){
			GUI.Box(new Rect(Screen.width/2, (Screen.height/2)+20, 150, 100), "Press Up Arrow To Go Up");
		}
	}

	void OnTriggerEnter(Collider collisionInfo) {
		inRange = true;
	}

	void OnTriggerExit(Collider other) {
		inRange = false;
	}

	void moveCharacter(){
		GameObject robber;
		robber = GameObject.Find("Robber");
		if(goingUp){
			robber.transform.Translate(new Vector3(0,17,9),Space.World);
		}
		else{
			robber.transform.Translate(new Vector3(0,-17,9),Space.World);
		}
		inRange = false;
	}
}
