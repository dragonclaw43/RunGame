using UnityEngine;
using System.Collections;

public class enemyActions : MonoBehaviour {

	public int moveLimit = 60;
	public float enemySpeed = .3f;
	public bool isMoving = true;
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
			transform.Translate(enemyVelocity);
			moveCount++;
			if(moveCount > moveLimit){
				transform.Rotate(new Vector3(0,180,0));
				moveCount=0;
			}
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