using UnityEngine;
using System.Collections;

public class fadeGameObject : MonoBehaviour {

	public GameObject[] gameObj;
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
			for(int i=0;i<gameObj.Length;i++){
				for (float t = 0.0f; t < fadeTime*Time.deltaTime; t += Time.deltaTime){

					colorTemp = gameObj[i].renderer.material.color;
					colorTemp.a = Mathf.Lerp(1, 0, t);
					gameObj[i].renderer.material.color =  colorTemp;
				}
				gameObj[i].renderer.enabled = false;
			}
		}
	}
}
