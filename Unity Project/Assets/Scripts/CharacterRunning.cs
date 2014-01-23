using UnityEngine;
using System.Collections;

public class CharacterRunning : MonoBehaviour {
	//bool colliding = false;
	Vector3 playerVelocity;
	public float playerSpeed = 1f;

	//float gravity = 9.81f;




	// Use this for initialization
	void Start () {
		playerVelocity = new Vector3(0,0,playerSpeed);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//if(!colliding){
	 		transform.Translate(playerVelocity);
		//}
		//animation.AddClip(animClip);
		//animation.Play("Walk"
	}

	void OnCollisionEnter(Collision theCollision){
		if(theCollision.collider.gameObject.name == "Wall"){
			//colliding = true;
		}
		else{
			//colliding = false;

			if(theCollision.collider.gameObject.name == "Turnaround"){
				transform.Rotate(new Vector3(0,180,0));
				GameObject camera;
				camera = GameObject.Find("Main Camera");
				cameraPresets a = camera.GetComponent<cameraPresets>();
				if(a.CameraPreset == 0){
					a.changeCameraPreset(1);
				}
				else if(a.CameraPreset == 1){
					a.changeCameraPreset(0);
				}
			}
		}
	}
	void OnCollisionExit(Collision theCollision){
		//colliding = false;
	}
}
