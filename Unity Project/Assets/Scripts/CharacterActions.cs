using UnityEngine;
using System.Collections;

public class CharacterActions : MonoBehaviour {
	public float JumpSpeed = 1200.0f;
	public float hopSpeed = 600.0f;

	int characterHealth = 1;

	int characterState;
		const int statNOTHING = 0;
		const int statJUMPING = 1;
		const int statATTACKING = 2;

	bool animationStarted = false;
	public GameObject rendererObject;
	// Use this for initialization
	void Start () {
		characterState = statNOTHING;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			if(characterState != statJUMPING){
				Jump();
				characterState = statJUMPING;
			}
		}

		if(Input.GetKey(KeyCode.LeftArrow)){
			characterState = statATTACKING;
		}

		// check for death
		if(characterHealth == 0){
			Death();
			characterHealth--;	
		}


		switch(characterState){
		case statNOTHING:
			Debug.Log("Running");
			animation.Play("Running");
			break;
		case statJUMPING:
			if(animationStarted == false){
				animation["Jump"].wrapMode = WrapMode.Once;
				animation.Play("Jump");
				animationStarted = true;
			}
			if(animation.IsPlaying("Jump") == false){
				characterState = statNOTHING;
				animationStarted = false;
			}
			break;
		case statATTACKING:
			if(animationStarted == false){
				animation["Punch"].wrapMode = WrapMode.Once;
				animation.Play("Punch");
				animationStarted = true;
			}
			if(animation.IsPlaying("Punch") == false){
				characterState = statNOTHING;
				animationStarted = false;
			}
			break;
		}




	}

	void Jump(){
		//animation.Play("jump_pose");
		rigidbody.AddForce(Vector3.up *JumpSpeed);
	}


	void OnCollisionEnter(Collision theCollision){
		if(theCollision.collider.gameObject.name == "Ground"){
			if(characterState == statJUMPING){
				characterState = statNOTHING;
			}
		}
		if(theCollision.collider.gameObject.name == "Enemy"){
			Debug.Log(rendererObject.renderer.bounds.min.y + " - " + getEnemyWeakpoint(theCollision.collider.gameObject));
			if(rendererObject.renderer.bounds.min.y > getEnemyWeakpoint(theCollision.collider.gameObject)){
				Destroy(theCollision.collider.gameObject);
				rigidbody.AddForce(Vector3.up *hopSpeed);
			}
			else if(characterHealth !=0){
				characterHealth--;
			}
		}

	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name == "Coin"){
			Destroy(other.gameObject);
			GameObject a =  GameObject.Find("Main Camera");
			scoreScript b = (scoreScript) a.GetComponent("scoreScript");
			b.onCoinGet();
		}
	}

	void Death(){
		Destroy(gameObject);
	}


	float getEnemyWeakpoint(GameObject enemy){
		float maxY = enemy.renderer.bounds.max.y;
		float height = enemy.renderer.bounds.size.y;
		height = (float)(height*.25f);

		return maxY - height; 
	}
}
