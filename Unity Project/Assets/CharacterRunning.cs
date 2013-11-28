using UnityEngine;
using System.Collections;

public class CharacterRunning : MonoBehaviour {
	bool colliding = false;
	Vector3 playerVelocity;
	public float playerSpeed = .5f;

	// Use this for initialization
	void Start () {
		playerVelocity = new Vector3(0,-playerSpeed,0);
	}
	
	// Update is called once per frame
	void Update () {
		if(!colliding){
			transform.Translate(playerVelocity);
		}
	}

	void OnCollisionEnter(Collision theCollision){
		if(theCollision.collider.gameObject.name == "Wall"){
			colliding = true;
		}
		else{
			colliding = false;
			if(theCollision.collider.gameObject.name == "Turnaround"){
				transform.Rotate(new Vector3(0,0,180));
			}
		}
	}
}
