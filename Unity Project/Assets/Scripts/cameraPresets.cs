using UnityEngine;
using System.Collections;

public class cameraPresets : MonoBehaviour {

	public GameObject m_goCharacter;

	private Vector3 currentPosition;
	private Vector3 nextPosition;

	private Quaternion currentRotation;
	private Quaternion nextRotation;

	public static float speed = 1f;

	bool movementIsFrozen = false;
	public enum camPos{left,right,back,front,backLeft,backRight,slowDownLeft,slowDownRight};
	public camPos CameraPreset = camPos.left;

	// Use this for initialization
	void Start () {

		// start looking left TEMP!!!!!
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

	// Update is called once per frame
	void Update () {
		//if(cameraDidChange()){
			currentPosition = transform.position;
			currentRotation = transform.rotation;
			if(CameraPreset == camPos.left){
				//nextPosition = m_goCharacter.transform.position;
				nextPosition = (new Vector3(m_goCharacter.transform.position.x+15,
				                            m_goCharacter.transform.position.y+15,
				                            m_goCharacter.transform.position.z-55));
				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(m_goCharacter.transform.rotation.x,
				                              m_goCharacter.transform.rotation.y,
				                              m_goCharacter.transform.rotation.z);
			}
			else if(CameraPreset == camPos.right){
				nextPosition = (new Vector3(m_goCharacter.transform.position.x+15,
				                            m_goCharacter.transform.position.y+15,
				                            m_goCharacter.transform.position.z+55));

				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(m_goCharacter.transform.rotation.x,
				                              m_goCharacter.transform.rotation.y+180,
				                              m_goCharacter.transform.rotation.z);
			}
			else if(CameraPreset == camPos.back){
				nextPosition = (new Vector3(m_goCharacter.transform.position.x-15,
				                            m_goCharacter.transform.position.y+7,
				                            m_goCharacter.transform.position.z));

				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(m_goCharacter.transform.rotation.x,
				                              m_goCharacter.transform.rotation.y+90,
				                              m_goCharacter.transform.rotation.z);
			}
			else if(CameraPreset == camPos.front){
				nextPosition = (new Vector3(m_goCharacter.transform.position.x+15,
				                            m_goCharacter.transform.position.y+7,
				                            m_goCharacter.transform.position.z+0));

				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(m_goCharacter.transform.rotation.x,
				                              m_goCharacter.transform.rotation.y-90,
				                              m_goCharacter.transform.rotation.z);
			}
			else if(CameraPreset == camPos.backLeft){
				nextPosition = (new Vector3(m_goCharacter.transform.position.x+15,
				                            m_goCharacter.transform.position.y+6,
				                            m_goCharacter.transform.position.z-15));

				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(m_goCharacter.transform.rotation.x,
				                              m_goCharacter.transform.rotation.y-55,
				                              m_goCharacter.transform.rotation.z);
			}
			else if(CameraPreset == camPos.backRight){
				nextPosition = (new Vector3(m_goCharacter.transform.position.x-15,
				                            m_goCharacter.transform.position.y+6,
				                            m_goCharacter.transform.position.z-15));
				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(m_goCharacter.transform.rotation.x,
				                              m_goCharacter.transform.rotation.y+55,
				                              m_goCharacter.transform.rotation.z);
			}
			else if(CameraPreset == camPos.slowDownLeft){
			/*if(!movementIsFrozen){
				nextPosition = (new Vector3(m_goCharacter.transform.position.x+40,
				                            m_goCharacter.transform.position.y+7,
				                            m_goCharacter.transform.position.z-55));
				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(m_goCharacter.transform.rotation.x,
				                              m_goCharacter.transform.rotation.y,
				                              m_goCharacter.transform.rotation.z);
			}
			movementIsFrozen = true;*/
			}
			else if(CameraPreset == camPos.slowDownRight){
				nextPosition = (new Vector3(m_goCharacter.transform.position.x-40,
				                            m_goCharacter.transform.position.y+15,
				                            m_goCharacter.transform.position.z-55));
				nextRotation = new Quaternion();
				nextRotation.eulerAngles = new Vector3(m_goCharacter.transform.rotation.x,
				                              m_goCharacter.transform.rotation.y,
				                              m_goCharacter.transform.rotation.z);
			}

		transform.rotation = Quaternion.Lerp(transform.rotation,nextRotation,Time.deltaTime*speed);
		transform.position = Vector3.Lerp(transform.position,nextPosition,Time.deltaTime*speed);
	}	


	public void changeCameraPreset(camPos newCameraPreset){
		CameraPreset = newCameraPreset;
	}
}
