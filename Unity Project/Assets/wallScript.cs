using UnityEngine;
using System.Collections;

public class wallScript : MonoBehaviour {
	
	public enum actionType{none,wallClimb,ladderUp,ladderDown,fallDown,runBack,moveDown,moveCloser,moveFarther}; 	

	// ability to move in a direction. Accessed from The Editor
	public actionType actionUp;		// +Y
	public actionType actionDown;	// -Y
	public actionType actionLeft;	// -X
	public actionType actionRight;	// +X
	public actionType actionIn;		// +Z
	public actionType actionOut;	// -Z

	// Arrows for direction options
	public GameObject ArrowUp;		// +Y
	public GameObject ArrowDown;		// -Y
	public GameObject ArrowLeft;		// -X
	public GameObject ArrowRight;	// +X
	public GameObject ArrowIn;		// +Z
	public GameObject ArrowOut;		// -Z


	bool fadeUp = false;
	bool fadeDown = false;
	bool fadeLeft = false;
	bool fadeRight = false;
	bool fadeIn = false;
	bool fadeOut = false;
	
	int fadeType;

	float fadeTime = .5f;
	Color colorTemp;

	void Start () {
		fadeType = 0;

		colorTemp = ArrowUp.renderer.material.color;
		colorTemp.a = 0;
		ArrowUp.renderer.material.color = colorTemp;
		
		colorTemp = ArrowDown.renderer.material.color;
		colorTemp.a = 0;
		ArrowDown.renderer.material.color = colorTemp;
		
		colorTemp = ArrowLeft.renderer.material.color;
		colorTemp.a = 0;
		ArrowLeft.renderer.material.color = colorTemp;
		
		colorTemp = ArrowRight.renderer.material.color;
		colorTemp.a = 0;
		ArrowRight.renderer.material.color = colorTemp;
		
		colorTemp = ArrowIn.renderer.material.color;
		colorTemp.a = 0;
		ArrowIn.renderer.material.color = colorTemp;
		
		colorTemp = ArrowOut.renderer.material.color;
		colorTemp.a = 0;
		ArrowOut.renderer.material.color = colorTemp;
	}

	// take in input
	void Update () {
		if(Input.GetButton("Move Up")){
			if(actionUp != actionType.none){
				fadeTime = 2;
				GameObject playerCharTemp = GameObject.Find("Robber");
				player2DScript playTemp = (player2DScript) playerCharTemp.GetComponent("player2DScript");
				playTemp.setCurrentActionState(player2DScript.actionState.wallRun);
			}
		}
		if(Input.GetButton("Move Down")){
			if(actionDown != actionType.none){
				fadeTime = 2;
				GameObject playerCharTemp = GameObject.Find("Robber");
				player2DScript playTemp = (player2DScript) playerCharTemp.GetComponent("player2DScript");
				playTemp.setCurrentActionState(player2DScript.actionState.moveDown);

			}
		}
		if(Input.GetButton("Move Left")){
			if(actionLeft != actionType.none){
				fadeTime = 2;
				GameObject playerCharTemp = GameObject.Find("Robber");
				player2DScript playTemp = (player2DScript) playerCharTemp.GetComponent("player2DScript");
				playTemp.setCurrentActionState(player2DScript.actionState.turnaround);

			}
		}
		if(Input.GetButton("Move Right")){
			if(actionRight != actionType.none){
				fadeTime = 2;
				GameObject playerCharTemp = GameObject.Find("Robber");
				player2DScript playTemp = (player2DScript) playerCharTemp.GetComponent("player2DScript");
				playTemp.setCurrentActionState(player2DScript.actionState.turnaround);

			}
		}
		if(Input.GetButton("Move In")){
			if(actionIn != actionType.none){
				fadeTime = 2;
				GameObject playerCharTemp = GameObject.Find("Robber");
				player2DScript playTemp = (player2DScript) playerCharTemp.GetComponent("player2DScript");
				playTemp.setCurrentActionState(player2DScript.actionState.moveIn);

			}
		}
		if(Input.GetButton("Move Out")){
			if(actionOut != actionType.none){
				fadeTime = 2;
				GameObject playerCharTemp = GameObject.Find("Robber");
				player2DScript playTemp = (player2DScript) playerCharTemp.GetComponent("player2DScript");
				playTemp.setCurrentActionState(player2DScript.actionState.moveOut);

			}
		}
		// if fading in
		if(fadeType == 1){
			Debug.Log("Fade Type 1");
			if(fadeUp){
				colorTemp = ArrowUp.renderer.material.color;
				if(colorTemp.a<1)
					colorTemp.a += Time.deltaTime/fadeTime;
				ArrowUp.renderer.material.color = colorTemp;
			}
			if(fadeDown){
				colorTemp = ArrowDown.renderer.material.color;
				if(colorTemp.a<1)
					colorTemp.a += Time.deltaTime/fadeTime;
				ArrowDown.renderer.material.color = colorTemp;
			}
			if(fadeLeft){
				colorTemp = ArrowLeft.renderer.material.color;
				if(colorTemp.a<1)
					colorTemp.a += Time.deltaTime/fadeTime;
				ArrowLeft.renderer.material.color = colorTemp;
			}
			if(fadeRight){
				colorTemp = ArrowRight.renderer.material.color;
				if(colorTemp.a<1)
					colorTemp.a += Time.deltaTime/fadeTime;
				Debug.Log(colorTemp.a);
				ArrowRight.renderer.material.color = colorTemp;
			}
			if(fadeIn){
				colorTemp = ArrowIn.renderer.material.color;
				if(colorTemp.a<1)
					colorTemp.a += Time.deltaTime/fadeTime;
				ArrowIn.renderer.material.color = colorTemp;
			}
			if(fadeOut){
				colorTemp = ArrowOut.renderer.material.color;
				if(colorTemp.a<1)
					colorTemp.a += Time.deltaTime/fadeTime;
				ArrowOut.renderer.material.color = colorTemp;
			}
		}
		// if fading out
		if(fadeType == 2){
			Debug.Log("Fade Type 2");
			if(fadeUp){
				colorTemp = ArrowUp.renderer.material.color;
				if(colorTemp.a>0)
					colorTemp.a = Time.deltaTime/fadeTime;
				ArrowUp.renderer.material.color = colorTemp;
			}
			if(fadeDown){
				colorTemp = ArrowDown.renderer.material.color;
				if(colorTemp.a>0)
					colorTemp.a = Time.deltaTime/fadeTime;
				ArrowDown.renderer.material.color = colorTemp;
			}
			if(fadeLeft){
				colorTemp = ArrowLeft.renderer.material.color;
				if(colorTemp.a>0)
					colorTemp.a = Time.deltaTime/fadeTime;
				ArrowLeft.renderer.material.color = colorTemp;
			}
			if(fadeRight){
				colorTemp = ArrowRight.renderer.material.color;
				if(colorTemp.a>0)
					colorTemp.a = Time.deltaTime/fadeTime;
				ArrowRight.renderer.material.color = colorTemp;
			}
			if(fadeIn){
				colorTemp = ArrowIn.renderer.material.color;
				if(colorTemp.a>0)
					colorTemp.a = Time.deltaTime/fadeTime;
				ArrowIn.renderer.material.color = colorTemp;
			}
			if(fadeOut){
				colorTemp = ArrowOut.renderer.material.color;
				if(colorTemp.a>0)
					colorTemp.a = Time.deltaTime/fadeTime;
				ArrowOut.renderer.material.color = colorTemp;
			}
		}
	}


	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name == "Robber"){

			fadeType = 1;
			if(actionUp != actionType.none){
				fadeUp = true;
			}
			if(actionDown != actionType.none){
				fadeDown = true;
			}
			if(actionLeft != actionType.none){
				fadeLeft = true;
			}
			if(actionRight != actionType.none){
				fadeRight = true;
			}
			if(actionIn != actionType.none){
				fadeIn = true;
			}
			if(actionOut != actionType.none){
				fadeOut = true;
			}
		}
	}
}
