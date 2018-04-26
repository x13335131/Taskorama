using UnityEngine;
using System.Collections;

public class PlantAnimationCtrl : MonoBehaviour {
    //controlling end of level animations
    //*with help from Benny*

    public bool isAllItemCollected = false;

    public player playerScript;
	// Use this for initialization

	void Start () {
        if(playerScript == null)
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<player>(); //setting playerScript to equal player
        }

        isAllItemCollected = false; //set to false
        
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Animator>().SetBool("allItemIsCollected", isAllItemCollected); //checking to see if all items are collected
	}
    void FixedUpdate()
    {
        if (playerScript.count >= 5)        //if players count is greater or equal to 5
            isAllItemCollected = true;      //all items are collected
        else
        {
            isAllItemCollected = false;     //not all items are collected
        }   
    }
}
