using UnityEngine;
using System.Collections;

public class slideObject : MonoBehaviour {
	bool playerColliding;
	bool vaultSuccessful;
	public Texture slideTexture;

	// Use this for initialization
	void Start () {
		playerColliding = false;
		vaultSuccessful = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			if(playerColliding){
				vaultSuccessful = true;

			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name == "Robber"){
			playerColliding = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.name == "Robber"){
			playerColliding = false;

			GameObject player = GameObject.Find("Robber");
			player2DScript a = player.GetComponent<player2DScript>();
			a.vaultSuccess(vaultSuccessful);

		}
	}

	void OnGUI(){
		if(playerColliding){
			GUI.Box(new Rect(Screen.width/2-(Screen.width/4), Screen.height/5, Screen.width/2, Screen.height/2),slideTexture, "");
		}
		
	}
}
