using UnityEngine;
using System.Collections;

public class CollisionsTrigger : MonoBehaviour
{
    /*colliding with platforms- allowing player walk through but also stand on certain platforms
    Code from 'inscope studios' youtube tutorial*/

    private BoxCollider2D playerCollider;

    [SerializeField]
    private BoxCollider2D platformCollider;
    [SerializeField]
    private BoxCollider2D platformTrigger;

    // Use this for initialization
    void Start() {
            playerCollider = GameObject.Find("player").GetComponent<BoxCollider2D>();  //playerCollider is equal to the objects player box collider
            Physics2D.IgnoreCollision(platformCollider, platformTrigger, true);
        }

    void OnTriggerEnter2D(Collider2D other)                 //on entering trigger collider
    {
        if (other.gameObject.name == "player")              //if player
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true); //true
        }
    }
    void OnTriggerExit2D(Collider2D other)                  //exiting trigger collider
    {
        if(other.gameObject.name == "player")               //if player
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, false);     //false
        }
    }

}
