using UnityEngine;
using System.Collections;

public class player2DScript : MonoBehaviour {

	// movement //

	public bool constantlyMoving;							// true if the character is constantly moving in a direction without player control
	
	Vector3 playerVelocity;									// The current Velocity of the player character
		public float JumpSpeed = 1200.0f;
		public float hopSpeed = 600.0f;

	static 	public float playersDefaultSpeed = .75f;		// the default speed of the player character. This variable shouldn't be changed
			public float playersCurrentSpeed = .75f;		// the current speed of the player character. 


	// character variables //

	int characterHealth = 1;
	public GameObject go_playerCharacter;
	public GameObject go_mainCamera;


	// action states //

	enum actionState{nothing, jumping, attacking, walled,slideSuccessful,slideFailed};
	actionState currentActionState;

	// animation //
	bool animationStarted;
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Start () {
		// initialize
		constantlyMoving = true;
		playersDefaultSpeed = playersCurrentSpeed;
		resetCurrentActionState();


		playerVelocity = new Vector3(0,0,playersCurrentSpeed);
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Action State //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void Update(){
		switch(currentActionState){

		// default state
		case actionState.nothing:
			animateCharacter("Running",0.5F,true);
			break;
			
		// Jumping
		case actionState.jumping:
			animateCharacter("Jump",0.5F,false);
			break;
			
		// punching	
		case actionState.attacking:
			animateCharacter("Punch",1F,false);
			if(!animation.IsPlaying("Punch")){
				resetCurrentActionState();
			}
			break;

		// hit a wall
		case actionState.walled:
			playersCurrentSpeed = 0;
			animateCharacter("Dead End",1F,true);
			break;

		// hopped over table
		case actionState.slideSuccessful:
			animateCharacter("Table Jump Success",1F,false);
			if(!animation.IsPlaying("Table Jump Success")){
				resetCurrentActionState();
			}
			break;

		// hit table
		case actionState.slideFailed:
			animateCharacter("Table Jump Failure",.75F,false);
			if(!animation.IsPlaying("Table Jump Failure")){
				resetCurrentActionState();
			}
			if(animationStarted){
				playersCurrentSpeed = Mathf.Lerp(playersCurrentSpeed,0,Time.deltaTime*1.5f);
			}
			break;
			
			
		}
	}

	void resetCurrentActionState(){
		playersCurrentSpeed = playersDefaultSpeed;
		currentActionState = actionState.nothing;
		animationStarted = false;
	}

	void animateCharacter(string animationName, float animationSpeed,bool animationRepeating){
		if(!animationRepeating){	
			animation[animationName].wrapMode = WrapMode.Once;
			if(animationStarted){
				return;
			}
		}
		animation.Play(animationName);
		foreach (AnimationState animState in animation) {animState.speed = animationSpeed;}
		animationStarted = true;
	}

	public void slideSuccess (bool successful){
		if(successful){currentActionState = actionState.slideSuccessful;}
		else{currentActionState = actionState.slideFailed;}
		animationStarted = false;
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Movement and Input ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	// movement and inputs
	void LateUpdate () {
		// movement
		if(constantlyMoving){
			playerVelocity = new Vector3(0,0,playersCurrentSpeed);
			transform.Translate(playerVelocity);
		}
		else{
			float horizontalAxis = Input.GetAxis("Horizontal");
			//float verticalAxis = Input.GetAxis("Vertical");

			playerVelocity = new Vector3(0,0,playersCurrentSpeed*horizontalAxis);

		}

		// actions
		if(Input.GetButton("Jump")){
			Jump();
		}
		if(Input.GetButton("Fire1")){
			Attack();
		}


	}


	// Character Actions
	void Jump(){
		if(currentActionState != actionState.jumping){
			rigidbody.AddForce(Vector3.up *JumpSpeed);
			currentActionState = actionState.jumping;
		}
	}

	void Attack(){
		currentActionState = actionState.attacking;
	}

	void Death(){
		Destroy(gameObject);
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Collisions ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


	// Collision - Ground, Enemy
	void OnCollisionEnter(Collision theCollision){
		if(theCollision.collider.gameObject.name == "Ground"){
			if(currentActionState == actionState.jumping){
				resetCurrentActionState();
			}
		}
		if(theCollision.collider.gameObject.name == "Enemy"){onEnemyCollision(theCollision);}
	}
	
	
	// Enemy
	void onEnemyCollision(Collision theCollision){
		Debug.Log(go_playerCharacter.renderer.bounds.min.y + " - " + getEnemyWeakpoint(theCollision.collider.gameObject));
		if(go_playerCharacter.renderer.bounds.min.y > getEnemyWeakpoint(theCollision.collider.gameObject)){
			Destroy(theCollision.collider.gameObject);
			rigidbody.AddForce(Vector3.up *hopSpeed);
		}
		else if(characterHealth !=0){
			characterHealth--;
		}
		
	}

	float getEnemyWeakpoint(GameObject enemy){
		float maxY = enemy.renderer.bounds.max.y;
		float height = enemy.renderer.bounds.size.y;
		height = (float)(height*.25f);
		
		return maxY - height; 
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Triggers //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	// Trigger - Wall,Coin
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name == "Wall"){		// if the player is going to hit a wall, position the camera accordingly
			Debug.Log("Trigger Enter");
			cameraPresets sc_camPresetsTemp = go_mainCamera.GetComponent<cameraPresets>();
			if(sc_camPresetsTemp.CameraPreset == cameraPresets.camPos.left){
				sc_camPresetsTemp.changeCameraPreset(cameraPresets.camPos.slowDownRight);
			}
			else if(sc_camPresetsTemp.CameraPreset == cameraPresets.camPos.right){
				sc_camPresetsTemp.changeCameraPreset(cameraPresets.camPos.slowDownLeft);
			}
		}
		if(other.gameObject.name == "Coin"){		// Delete coin and add to your score
			Destroy(other.gameObject);
			scoreScript sc_scoreTemp = (scoreScript) go_mainCamera.GetComponent("scoreScript");
			sc_scoreTemp.onCoinGet();
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.gameObject.name == "Wall"){	// when the player actually reaches the wall, change action
			currentActionState = actionState.walled;
		}
	}


}
