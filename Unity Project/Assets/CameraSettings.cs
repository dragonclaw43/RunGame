using UnityEngine;
using System.Collections;

public class CameraSettings : MonoBehaviour {
	float deadZoneX = 12;
	float deadZoneY = 3;


	public GameObject m_goCharacter;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// negative is camera left, positive is camera right

		// X
		if(m_goCharacter.transform.position.x < (transform.position.x - deadZoneX)){ // if character is to left of deadzone
			if(m_goCharacter.transform.eulerAngles.y > 180){ // if the character is moving left
				transform.Translate(new Vector3(m_goCharacter.transform.position.x - (transform.position.x - deadZoneX),0,0));
			}
		}
		else if(m_goCharacter.transform.position.x > (transform.position.x + deadZoneX)){ // if character is to right of deadzone
			if(m_goCharacter.transform.eulerAngles.y < 180){ // if the character is moving right
				transform.Translate(new Vector3(m_goCharacter.transform.position.x - (transform.position.x + deadZoneX),0,0));
			}
		}

		// Y
		if(m_goCharacter.transform.position.y < (transform.position.y - deadZoneY)){ // if character is under deadzone
			//if(m_goCharacter.transform.eulerAngles.y > 180){ // if the character is moving left
				transform.Translate(new Vector3(0,m_goCharacter.transform.position.y - (transform.position.y - deadZoneY),0));
			//}
		}
		else if(m_goCharacter.transform.position.y > (transform.position.y + deadZoneY)){ // if character is above the deadzone
			//if(m_goCharacter.transform.eulerAngles.y < 180){ // if the character is moving right
				transform.Translate(new Vector3(0,m_goCharacter.transform.position.y - (transform.position.y + deadZoneY),0));
			//}
		}
		Debug.Log(m_goCharacter.transform.position.y + " " + deadZoneY + " " + transform.position.y);
	}
}
