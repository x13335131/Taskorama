using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


//ENEMY CODE from 'GamesplusJames' tutorial on youtube
//code from https://www.youtube.com/watch?v=d3lhb1y_89U&index=11&list=PLiyfvmtjWC_X6e0EYLPczO9tNCkm2dzkm

public class MovingGerm : MonoBehaviour {
    
	private Rigidbody2D myRigidbody;
	public float waitToReload;
	private bool reloading;
	private GameObject thePlayer;
    private PlayerSpawn deathSpawn;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> (); //gets RidgidBody 
        deathSpawn = GameObject.FindGameObjectWithTag("DeathRespawn").GetComponent<PlayerSpawn>(); //here we set deathspawn to any gameobject with the tag "DeathRespawn" and then get the player and place it here.
    }

    // Update is called once per frame
    void Update () {

        //*Benny helped between here*
        if (reloading) {

			waitToReload -= Time.deltaTime;      //waitToReload is less than or equal to real-time

            if (waitToReload < 0) {              //if wait to reload is less than 0 
                SceneManager.LoadScene("level1");           //loads level 1
                thePlayer.SetActive (true);                 //sets player to active
			}
				
		}
	
	}
    
	void OnCollisionEnter2D (Collision2D other){            //on collision

		if (other.gameObject.tag.Equals("Player")) {        //if game object is tagged player
            deathSpawn.isPlayerDead = true;                 //player is dead

		}

	}
}
