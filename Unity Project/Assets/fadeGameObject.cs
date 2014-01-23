using UnityEngine;
using System.Collections;

public class fadeGameObject : MonoBehaviour {

	public GameObject gameObj;
	public float fadeTime = 1.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if(other.collider.gameObject.name == "Robber"){
			Color colorTemp;
			for (float t = 0.0f; t < fadeTime*Time.deltaTime; t += Time.deltaTime){
				colorTemp = gameObj.renderer.material.color;
				colorTemp.a = Mathf.Lerp(1, 0, t);
				gameObj.renderer.material.color =  colorTemp;
				//gameObj.renderer.material.color.a = Mathf.Lerp(1, 0, t);
			}
			gameObj.renderer.enabled = false;
		}
	}
}
