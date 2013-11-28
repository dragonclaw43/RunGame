using UnityEngine;
using System.Collections;

public class CharacterRunning : MonoBehaviour {
	bool colliding = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(!colliding){
			transform.Translate(Vector3.down);
		}
	}

	void OnCollisionEnter(Collision theCollision){
		if(theCollision.collider.gameObject.name == "Wall"){
			colliding = true;
		}
		else{
			colliding = false;
		}
	}
}
