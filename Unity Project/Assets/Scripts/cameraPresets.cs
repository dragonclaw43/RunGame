using UnityEngine;
using System.Collections;

public class cameraPresets : MonoBehaviour {

	public 	GameObject m_goCharacter;			// GameObject that the camera follows
	float wallX = 0;

	private Vector3 currentPosition;			// current position of the camera
	private Vector3 nextPosition;				// the next position of the camera, after the lerp

	private Quaternion currentRotation;			// current rotation of the camera
	private Quaternion nextRotation;			// the next rotation of the camera, after the lerp

	public static float lerpSpeed = 1f;
	
	public enum character{right,left,back,front,backRight,frontRight,slowDownLeft,slowDownRight};		// the positions of the camera in regards to the character 
	public character cameraPosition = character.right;		// current pos of the camera		// ex: character.right is right of character

	
	void Start () {
		// default the position as character.right
		currentPosition = (new Vector3(m_goCharacter.transform.position.x+15,
			                            m_goCharacter.transform.position.y+15,
			                            m_goCharacter.transform.position.z-55));
		currentRotation = new Quaternion();
		currentRotation.eulerAngles = new Vector3(m_goCharacter.transform.rotation.x,
			                                       m_goCharacter.transform.rotation.y,
			                                       m_goCharacter.transform.rotation.z);
		nextPosition = currentPosition;
		nextRotation = currentRotation;


		transform.position = currentPosition;
		transform.rotation = currentRotation;
	}
	
	void Update () {

		// setting the current position and rotation
		currentPosition = transform.position;
		currentRotation = transform.rotation;

		// setting the next position and rotation
		switch(cameraPosition){
			case character.right:
				nextPosition = (new Vector3(m_goCharacter.transform.position.x+40,
				                            m_goCharacter.transform.position.y+15,
				                            m_goCharacter.transform.position.z-55));
				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(	m_goCharacter.transform.rotation.x,
														m_goCharacter.transform.rotation.y,
														m_goCharacter.transform.rotation.z);
				break;

			case character.left:
				nextPosition = (new Vector3(m_goCharacter.transform.position.x+45,
				                            m_goCharacter.transform.position.y+15,
				                            m_goCharacter.transform.position.z+55));

				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(	m_goCharacter.transform.rotation.x,
				                              			m_goCharacter.transform.rotation.y+180,
				                              			m_goCharacter.transform.rotation.z);
				break;

			case character.back:
				nextPosition = (new Vector3(m_goCharacter.transform.position.x-5,
				                            m_goCharacter.transform.position.y+7,
				                            m_goCharacter.transform.position.z));

				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(	m_goCharacter.transform.rotation.x,
				                              			m_goCharacter.transform.rotation.y+90,
				                              			m_goCharacter.transform.rotation.z);
				break;

			case character.front:
				nextPosition = (new Vector3(m_goCharacter.transform.position.x+45,
				                            m_goCharacter.transform.position.y+7,
				                            m_goCharacter.transform.position.z+0));

				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(	m_goCharacter.transform.rotation.x,
				                              			m_goCharacter.transform.rotation.y-90,
				                              			m_goCharacter.transform.rotation.z);
				break;
		case character.frontRight:
				nextPosition = (new Vector3(m_goCharacter.transform.position.x+35,
				                            m_goCharacter.transform.position.y+6,
				                            m_goCharacter.transform.position.z-15));

				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(	m_goCharacter.transform.rotation.x,
				                              			m_goCharacter.transform.rotation.y-55,
				                              			m_goCharacter.transform.rotation.z);
				break;

			case character.backRight:
				nextPosition = (new Vector3(m_goCharacter.transform.position.x+5,
				                            m_goCharacter.transform.position.y+6,
				                            m_goCharacter.transform.position.z-15));
				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(	m_goCharacter.transform.rotation.x,
				                              			m_goCharacter.transform.rotation.y+55,
				                              			m_goCharacter.transform.rotation.z);
				break;

			case character.slowDownLeft:
				nextPosition = (new Vector3(wallX-15,
				                            m_goCharacter.transform.position.y+7,
				                            m_goCharacter.transform.position.z-55));
				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(	m_goCharacter.transform.rotation.x,
				                              			m_goCharacter.transform.rotation.y,
				                              			m_goCharacter.transform.rotation.z);
				break;

			case character.slowDownRight:
				nextPosition = (new Vector3(wallX+15,
				                            m_goCharacter.transform.position.y+15,
				                            m_goCharacter.transform.position.z-55));
				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(m_goCharacter.transform.rotation.x,
				                              			m_goCharacter.transform.rotation.y,
				                              			m_goCharacter.transform.rotation.z);
				break;
		}

		// Lerp between current and next camera position/rotation
		transform.rotation = Quaternion.Lerp(transform.rotation,nextRotation,Time.deltaTime*lerpSpeed);
		transform.position = Vector3.Lerp(transform.position,nextPosition,Time.deltaTime*lerpSpeed);
	}	

	public void changeCameraPosition(character newCamPosition){
		cameraPosition = newCamPosition;
		if(newCamPosition == character.slowDownLeft || newCamPosition == character.slowDownRight){
			wallX = m_goCharacter.transform.position.x;
		}
	}
}
