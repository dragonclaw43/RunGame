using UnityEngine;
using System.Collections;

public class CharacterActions : MonoBehaviour {
	 int statNOTHING = 0;
	 int statJUMPING = 1;

	public float JumpSpeed = 200.0f;
	int characterStatus;
	// Use this for initialization
	void Start () {
		characterStatus = statNOTHING;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			if(characterStatus != statJUMPING){
				Jump();
				characterStatus = statJUMPING;
			}
		}
	}

	void Jump(){
		//animation.Play("jump_pose");
		rigidbody.AddForce(Vector3.up *JumpSpeed);
	}


	void OnCollisionEnter(Collision theCollision){
		if(theCollision.collider.gameObject.name == "Ground"){
			if(characterStatus == statJUMPING){
				characterStatus = statNOTHING;
			}
		}
	}

}
