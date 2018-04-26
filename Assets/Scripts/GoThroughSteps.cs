using UnityEngine;
using System.Collections;

public class GoThroughSteps : MonoBehaviour {

	private BoxCollider2D playerCollider;

	[SerializeField]
	private BoxCollider2D platformCollider;

	[SerializeField]
	private BoxCollider2D platformTrigger;


	// Use this for initialization
	void Start () {

		playerCollider = GameObject.Find ("player").GetComponent<BoxCollider2D>();
		Physics2D.IgnoreCollision (platformCollider, platformTrigger, true);

	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.name == "player") {

			Physics2D.IgnoreCollision (platformCollider, playerCollider, true);
		}

	}

	void OnTriggerExit2D(Collider2D other){

		if (other.gameObject.name == "player") {

			Physics2D.IgnoreCollision (platformCollider, playerCollider, false);
		}

	}
}
