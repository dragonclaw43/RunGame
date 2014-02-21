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

	public enum actionState{standing,walking,running,jumping,attacking, 	// standard states
							walled,wallRun,wallSlide,wallJump,liftUp,		// wall based states
							vaultSuccessful,vaultFailed,					// vault based states
							slideDown,sliding,slideUp,						// slide based states
							moveDown,moveIn,moveOut,turnaround};			// Wall based states
	actionState currentActionState;

	// animation //
	bool animationStarted;
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Start () {
		// initialize
		constantlyMoving = true;
		playersDefaultSpeed = playersCurrentSpeed;
		setCurrentActionState(actionState.running);


		playerVelocity = new Vector3(0,0,playersCurrentSpeed);
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Action State //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void Update(){
		switch(currentActionState){

		// default state

		case actionState.standing:
			//animateCharacter("Running",0.5F,true);
			break;

		case actionState.walking:
			animateCharacter("Walk",0.5F,true);
			break;


		case actionState.running:							// DONE
			animateCharacter("Running",0.5F,true);
			break;
			
		// Jumping
		case actionState.jumping:							// DONE
			animateCharacter("Jump",0.5F,false);
			break;
			
		// punching			
		case actionState.attacking:
			animateCharacter("Punch",1F,false);
			if(!animation.IsPlaying("Punch")){
				setCurrentActionState(actionState.running);
			}
			break;

		// Wall /////////////////////////////////////////////////////

		// Reached Dead end
		case actionState.walled:							// DONE
			playersCurrentSpeed = 0;
			animateCharacter("Dead End",1F,true);
			break;

		// climb Wall
		case actionState.wallRun:
			playersCurrentSpeed = 0;
			animateCharacter("Climb Wall",1F,false);
			if(animation.IsPlaying("Climb Wall")){
				rigidbody.AddForce(Vector3.up *JumpSpeed/2);
			}
			break;

			// climb Wall
		case actionState.wallSlide:
			playersCurrentSpeed = 0;
			animateCharacter("Wall Fall",1F,true);
			rigidbody.AddForce(Vector3.up *JumpSpeed/5);
			break;

			// climb Wall
		case actionState.wallJump:
			playersCurrentSpeed = 0;
			animateCharacter("Wall Jump Part 1",1F,false);
			break;

			// climb Wall
		case actionState.liftUp:
			playersCurrentSpeed = 0;
			animateCharacter("Wall Jump Part 2",1F,false);
			break;

		// Vault /////////////////////////////////////////////////////

		// hopped over table
		case actionState.vaultSuccessful:					// DONE
			animateCharacter("Table Jump Success",1F,false);
			if(!animation.IsPlaying("Table Jump Success")){
				setCurrentActionState(actionState.running);
			}
			break;

		// hit table
		case actionState.vaultFailed:						// DONE
			animateCharacter("Table Jump Failure",.75F,false);
			if(!animation.IsPlaying("Table Jump Failure")){
				setCurrentActionState(actionState.running);
			}
			if(animationStarted){
				playersCurrentSpeed = Mathf.Lerp(playersCurrentSpeed,0,Time.deltaTime*1.5f);
			}
			break;

		// Slide /////////////////////////////////////////////////////
			// hit table
		case actionState.slideDown:
			animateCharacter("Slide Part 1",.75F,false);
			break;

			// hit table
		case actionState.sliding:
			animateCharacter("Slide Hold",.75F,true);
			break;

			// hit table
		case actionState.slideUp:
			animateCharacter("Slide Part 2",.75F,false);
			break;

		// Wall /////////////////////////////////////////////////////

		case actionState.moveDown:
			animateCharacter("Running",0.5F,true);
			break;
			
			// hit table
		case actionState.moveIn:
			animateCharacter("Running",0.5F,true);
			break;
			
			// hit table
		case actionState.moveOut:
			animateCharacter("Running",0.5F,true);
			break;
		case actionState.turnaround:
			// rotate character
			go_playerCharacter.transform.Rotate(new Vector3(0,180,0));
			
			// set the character to running
			currentActionState = actionState.running;
			
			// rotate the camera to match
			cameraPresets sc_cameraPreset = (cameraPresets) go_mainCamera.GetComponent("cameraPresets");
			sc_cameraPreset.changeCameraPosition(cameraPresets.character.right);
			animationStarted = false;
			break;
		}
	}

	public void setCurrentActionState(actionState stateNew){
		playersCurrentSpeed = playersDefaultSpeed;
		currentActionState = actionState.running;
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

	public void vaultSuccess (bool successful){
		if(successful){currentActionState = actionState.vaultSuccessful;}
		else{currentActionState = actionState.vaultFailed;}
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

		if(currentActionState == actionState.running){
			// actions
			if(Input.GetButton("Jump")){
				Jump();
			}
			if(Input.GetButton("Fire1")){
				Attack();
			}
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
				setCurrentActionState(actionState.running);
			}
		}
		if(theCollision.collider.gameObject.name == "Enemy"){onEnemyCollision(theCollision);}
	}
	
	
	// Enemy
	void onEnemyCollision(Collision theCollision){
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
			cameraPresets sc_cameraPreset = (cameraPresets) go_mainCamera.GetComponent("cameraPresets");
			if(sc_cameraPreset.cameraPosition == cameraPresets.character.right){
				sc_cameraPreset.changeCameraPosition(cameraPresets.character.slowDownRight);
			}
			else if(sc_cameraPreset.cameraPosition == cameraPresets.character.left){
				sc_cameraPreset.changeCameraPosition(cameraPresets.character.slowDownLeft);
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
