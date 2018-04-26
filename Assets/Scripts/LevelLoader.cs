using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {

    //loading new level/scene at sign object

    private bool playerInZone;                      //player is zone true /false
    public player play = new player();              //player 1
    public string levelToLoad;                      //what level to load next
    public player play2 = new player();             //player 2
    private bool lv1Complete = false;               //level 1 complete = false
    



    // Use this for initialization

    void Start() {

        playerInZone = false;                        //player is set to false

    }


    
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) ||( playerInZone && (play.count==5 || play2.count == 5))) 
            //if you press v or player is in zone and count is equal to 5
        {

            play.count = 0;                                             //sets player count to 0
            play2.count = 0;
            play.SetCountText();
            play2.SetCountText();
            GameObject spawnPoint;
            spawnPoint = GameObject.FindGameObjectsWithTag("Respawn")[0]; //spawnpoint is assigned to game object tagged respawn
            var Vector3 = spawnPoint.transform.position;                //vector 3 is assigned to spawnpoint position
            play.transform.position = Vector3;                          //both players are assigned to this position
            play2.transform.position = Vector3;
            if (lv1Complete == false)                                   //if level 1 isnt commplete (ie false)- do the following..
            {
                SceneManager.LoadScene("level2");                           //loads level 2
                lv1Complete = true;
                Vector3 = GameObject.FindGameObjectsWithTag("SignTag")[0].transform.position; //vector 3 is equal to position of game object "SignTag"
                this.gameObject.transform.position = Vector3;  //transform to vector3 position
            }
            else
            {
                SceneManager.LoadScene("level3");                           //loads level 3
            }


        }
      
        
        //used for respawn testing purposes
        if (Input.GetKeyDown(KeyCode.K))                                //press k to spawn player to position below
        {
            play.transform.position.Set(3, 14, 0);                      //to this position. note:only works for male character
        }
    }
    
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);                     //dont destroy player on load
    }
    
    //tests if player is at the sign game object

    void OnTriggerEnter2D(Collider2D other)                         //entering sign area
    {
        if(other.name == "player" )                                 //if its the player
            {
            playerInZone = true;                                    //set player in zone to true
        }
      
    }
    
    void OnTriggerExit2D(Collider2D other)                          //leaving trigger/sign area
    {
        
        if (other.name == "player" )                                //if its player
        {
            playerInZone = false;                                   //set player in zone to false
        }
    }

    //used for testing purposes, waits for x amount of seconds
    IEnumerator Wait(int x)
    {
        yield return new WaitForSeconds(500000000);
    }

}
