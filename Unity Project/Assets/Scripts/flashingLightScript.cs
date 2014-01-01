using UnityEngine;
using System.Collections;

public class flashingLightScript : MonoBehaviour {
	public Color color1 = Color.red;
	public Color color2 = Color.white;
	public float flashTime = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float t = Mathf.PingPong (Time.time, flashTime) / flashTime;
		light.color = Color.Lerp (color1, color2, t);
	}
}
