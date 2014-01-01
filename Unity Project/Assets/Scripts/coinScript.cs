using UnityEngine;
using System.Collections;

public class coinScript : MonoBehaviour {
	public float coinSpeed = 1.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,coinSpeed,0);
	}
}
