using UnityEngine;
using System.Collections;

public class HideShowGameObject : MonoBehaviour {
	public Vector3 gbMovement;
	public GameObject gameObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter (Collider other) {
		if(other.collider.gameObject.name == "Robber"){
			gameObj.transform.Translate(gbMovement,Space.World);
			Destroy(this);
		}
	}
}
