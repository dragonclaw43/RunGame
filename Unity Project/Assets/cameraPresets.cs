using UnityEngine;
using System.Collections;

public class cameraPresets : MonoBehaviour {

	public GameObject m_goCharacter;
	
	public int CameraPreset;
	int cameraLast;

	int cameraLeft =  0;
	int cameraRight = 1;
	int cameraBack =  2;
	int cameraFront = 3;
	int cameraBackLeft = 4;
	int cameraBackRight = 5;
	// Use this for initialization
	void Start () {
	}

	bool cameraDidChange(){
		if(CameraPreset == cameraLast){
			return true;
		}
		return false;
	}

	// Update is called once per frame
	void Update () {
		if(cameraDidChange()){
			if(CameraPreset == cameraLeft){
				transform.position = m_goCharacter.transform.position;
				transform.Translate(new Vector3(15,7,-50));
				transform.rotation = m_goCharacter.transform.rotation;
				transform.Rotate(new Vector3(0,-90,0),Space.World);
			}

		}
		else if(CameraPreset == cameraRight){
			transform.position = m_goCharacter.transform.position;
			transform.Translate(new Vector3(15,7,50));
			transform.rotation = m_goCharacter.transform.rotation;
			transform.Rotate(new Vector3(0,90,0),Space.World);
		}
		else if(CameraPreset == cameraBack){
			transform.position = m_goCharacter.transform.position;
			transform.Translate(new Vector3(-15,7,0));
			transform.rotation = m_goCharacter.transform.rotation;
		}
		else if(CameraPreset == cameraFront){
			transform.position = m_goCharacter.transform.position;
			transform.Translate(new Vector3(15,7,0));
			transform.rotation = m_goCharacter.transform.rotation;
			transform.Rotate(new Vector3(0,180,0),Space.World);
		}
		else if(CameraPreset == cameraBackLeft){
			transform.position = m_goCharacter.transform.position;
			transform.Translate(new Vector3(-20,7,-15));
			transform.rotation = m_goCharacter.transform.rotation;
			transform.Rotate(new Vector3(0,-25,0),Space.World);
		}
		else if(CameraPreset == cameraBackRight){
			transform.position = m_goCharacter.transform.position;
			transform.Translate(new Vector3(-20,7,15));
			transform.rotation = m_goCharacter.transform.rotation;
			transform.Rotate(new Vector3(0,25,0),Space.World);
		}
		cameraLast = CameraPreset;
	}	


	public void changeCameraPreset(int newCameraPreset){
		CameraPreset = newCameraPreset;
	}
}
