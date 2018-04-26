using UnityEngine;
using System.Collections;

public class die : MonoBehaviour
    //making player die when it hits certain dangerous objects
{

    private PlayerSpawn deathSpawn;

    // Use this for initialization
    void Start()
    {

        //assigning deathspawn to game object labelled "Death Respawn"
        deathSpawn = GameObject.FindGameObjectWithTag("DeathRespawn").GetComponent<PlayerSpawn>();
    
}
    

    void OnCollisionEnter2D(Collision2D other)  //on collision
    {

        if (other.gameObject.tag.Equals("Player")) // if game object is player..
        {
            deathSpawn.isPlayerDead = true;  //kill player(spawn player)
              }
    }
}