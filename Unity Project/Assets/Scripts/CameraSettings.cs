using UnityEngine;
using System.Collections;

public class CameraSettings : MonoBehaviour {
	//float deadZoneX = 12;
	//float deadZoneY = 20;

	public GameObject m_goCharacter;
	public float XpositionOffset = 20f;
	public float YpositionOffset = 20f;
	public float ZpositionOffset = 0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(m_goCharacter != null){
			if(m_goCharacter.transform.eulerAngles.y > 180){ // left
				transform.position = new Vector3( m_goCharacter.transform.position.x-XpositionOffset,
				                                 m_goCharacter.transform.position.y+YpositionOffset,
				                                 transform.position.z+ZpositionOffset);
			}

			else{
				transform.position = new Vector3( m_goCharacter.transform.position.x+XpositionOffset,
				                                 m_goCharacter.transform.position.y+YpositionOffset,
				                                 transform.position.z+ZpositionOffset);
			}
		}

		/*
		// negative is camera left, positive is camera right
		// X
		if(m_goCharacter.transform.position.x < (transform.position.x - deadZoneX)){ // if character is to left of deadzone
			if(m_goCharacter.transform.eulerAngles.y < 180){ // if the character is moving left
				transform.Translate(new Vector3(m_goCharacter.transform.position.x - (transform.position.x - deadZoneX),0,0));
			}
		}
		else if(m_goCharacter.transform.position.x > (transform.position.x + deadZoneX)){ // if character is to right of deadzone
			if(m_goCharacter.transform.eulerAngles.y > 180){ // if the character is moving right
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
		}*/
		//Debug.Log(m_goCharacter.transform.position.x + "     " + deadZoneY + "     " + transform.position.x);
	}
}
