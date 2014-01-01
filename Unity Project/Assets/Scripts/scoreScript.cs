using UnityEngine;
using System.Collections;

public class scoreScript : MonoBehaviour {
	float score = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.TextField(new Rect(0,0,100,50),"Score: " + score);
	}

	public void onCoinGet(){
		score++;
	}
}
