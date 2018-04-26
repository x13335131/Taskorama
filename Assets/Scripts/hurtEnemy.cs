using UnityEngine;
using System.Collections;

public class hurtEnemy : MonoBehaviour {
	//*****SWORD ATTACK*****

	//SWORD ATTACK CODE from 'GamesplusJames' tutorial on youtube

	[SerializeField]
	private EdgeCollider2D SwordCollider;


	void OnTriggerEnter2D(Collider2D other){   //on entering collider
		if (other.gameObject.tag.Equals("enemy")) { //if object is tagged "enemy"

			Destroy (other.gameObject);   //destroy the object
		}
	}
}
