using UnityEngine;
using System.Collections;

public class AlarmLightScript : MonoBehaviour {
	public float rotateSpeed = 1.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward*rotateSpeed);
	}
}
