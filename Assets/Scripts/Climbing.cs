using UnityEngine;
using System.Collections;

//CLIMBING CODE: Code from 'GamesplusJames' tutorial on youtube

public class Climbing : MonoBehaviour
{

    private player controlPlayer;  // instance of the player script
    //private GameObject controlPlayer = new GameObject();  // instance of the player script




    // Use this for initialization
    void Start()
    {
        controlPlayer = FindObjectOfType<player>();
        //controlPlayer = GameObject.FindGameObjectsWithTag("Player")[0];

        //myPlayer = GameObject.Find(myPlayer).GetComponent<BoxCollider2D>();
        //myPlayer = GameObject.Find("player").GetComponent<BoxCollider2D>();
        //myPlayer = GameObject.Find("Player");
        //gameObject.
    }


    void onTriggerEnter2D(Collider2D other)
    {
        Debug.Log("in zone");
        if (other.gameObject.tag.Equals("Player"))// for when the player enters the climbing zone
        {
            //other.gameObject.GetComponent<player>().onLadder = true;
        }
    }

    void onTriggerStay2D(Collider2D other)
    {
        Debug.Log("in zone");
        if (other.gameObject.tag.Equals("Player"))// for when the player enters the climbing zone
        {
            //other.gameObject.GetComponent<player>().onLadder = true;
        }
    }

    void onTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))// for when the player leaves the climbing zone
        {
            //other.gameObject.GetComponent<player>().onLadder = false;
        }
    }

}


