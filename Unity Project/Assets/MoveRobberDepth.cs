using UnityEngine;
using System.Collections;

public class MoveRobberDepth : MonoBehaviour {
	public float moveSpeed = 1;
	public Vector3 finalDepth;
	bool collisionDetected = false;
	GameObject robber;
	// Use this for initialization
	void Start () {
		robber = GameObject.Find("Robber");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(robber.transform.position.x + " ");
		if(collisionDetected){

			if(finalDepth.z != 0){
				if(robber.transform.position.z < finalDepth.z){
					robber.transform.Translate(Vector3.left*moveSpeed);
				}
				if(robber.transform.position.z > finalDepth.z){
					robber.transform.Translate(Vector3.right*moveSpeed);
				}
				if(robber.transform.position.z > finalDepth.z - .25){
					if(robber.transform.position.z < finalDepth.z + .25){
						Destroy (this);
					}
				}
			}
			if(finalDepth.x != 0){
				if(robber.transform.position.x < finalDepth.x){
					robber.transform.Translate(Vector3.right*moveSpeed);
				}
				if(robber.transform.position.x > finalDepth.x){
					robber.transform.Translate(Vector3.left*moveSpeed);
				}
				if(robber.transform.position.x > finalDepth.x - .25){
					if(robber.transform.position.x < finalDepth.x + .25){
						Destroy (this);
					}
				}
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if(other.collider.gameObject.name == "Robber"){
			collisionDetected = true;
		}
	}
}
