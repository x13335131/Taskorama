using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {
    //Spawning the player

    private GameObject playerPrefab;
    public bool isPlayerDead = false;  //by default player is not dead - isPlayerDead is set to false

	// Use this for initialization
	void Start () {

        isPlayerDead = false;    //set to false
        if (playerPrefab == null)
            playerPrefab = GameObject.FindGameObjectWithTag("Player"); 
        //find player tag(ie. the player). this equals playerPrefab
    }
	
	// Update is called once per frame
	void Update () {
        if (isPlayerDead)
        {
            playerPrefab.SetActive(false);
            playerPrefab.transform.position =transform.position;  //move player
            playerPrefab.transform.rotation = transform.rotation;
            isPlayerDead = false;
            playerPrefab.SetActive(true); //set to true
        }
	}
}
