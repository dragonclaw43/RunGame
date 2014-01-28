using UnityEngine;
using System.Collections;

public class enemyActions : MonoBehaviour {

	public int moveLimit = 60;
	public int waitLimit = 15;
	public float enemySpeed = .3f;
	public float chaseSpeed = 7;
	public float chaseDistance = 15;
	public bool isMoving = false;
	public bool isChase = false;
	public bool isMobster= false;
	int enemyHealth = 1;
	int moveCount = 0;
	Vector3 enemyVelocity;

	void Start () {
	  if(isMoving){
	    enemyVelocity = new Vector3(0,0,enemySpeed);
      }
	}
	// Update is called once per frame

	// Arbitrary number of frames to patrol for
	// Needs to be smoothed out or toggled for standing enemies
	// a non-moving enemy will not turn at all
	void Update () {
		if(isMoving){
			moveCount++;
			if(moveCount > moveLimit){
				transform.Translate(new Vector3(0,0,0));
				if(moveCount >  moveLimit + waitLimit) {
					transform.Rotate(new Vector3(0,180,0));
					moveCount=0;
			    }
			}
			else {
				transform.Translate(enemyVelocity);
			}
		}
		else if (isChase) {
			// Chase code stolen from : http://forum.unity3d.com/threads/34046-Follow-Chase-Player
			float range = Vector3.Distance(transform.position,GameObject.Find("Robber").transform.position);
			if(range < chaseDistance){
				transform.LookAt(GameObject.Find("Robber").transform);
			    transform.Translate(chaseSpeed*Vector3.forward*Time.deltaTime);
				if (range > 2 & range < 6){
					attack();
				}
			}
		} 
	}

	void attack() {

		if(isMobster){
			//animation.play("attack")
			Debug.Log("Mob Attack!");
		}
		else {
			//animation.play("Tackle")
			Debug.Log("Tackle!");
		}
	}
	// Enemy health goes down on collision for now
	// Not quite sure how punch will be implemented.
	// eventually will need a contact point to see if enemy is hit on weak side??
	void OnCollisionEnter(Collision theCollision){
		if(theCollision.collider.gameObject.name == "Robber"){ 
			enemyHealth--;
		}		if (enemyHealth == 0){
			Destroy(gameObject);
		}
	}
}