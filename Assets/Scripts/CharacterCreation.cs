using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
/*
checking if a keyboard key is enabled Code: http://answers.unity3d.com/questions/289840/disable-a-key-after-shooting.html
selecting characters youtube tutorial by N3K EN: https://www.youtube.com/watch?v=T-AbCUuLViA
*/
public class CharacterCreation : MonoBehaviour {
 
    public bool IsKeyEnabled_Enter { get; set; }    //checks if enter key is enabled
    public player play = new player();              //player 1               
    public player play2 = new player();             //player 2
    private List<GameObject> models;                //array list of players
    private int selectionIndex = 0;                 //default index of the model
   
   // Use this for initialization
    private void Start () {
        
        models = new List<GameObject>();
        foreach(Transform t in transform)
        {
            models.Add(t.gameObject);               //add new model 
            t.gameObject.SetActive(false);          //and set to false
        }
        models[selectionIndex].SetActive(true);    //set selectionIndex[0] to true(active ie.visible)
       
    }

    //selecting a character
	public void Select(int index)
    {
        if (index == selectionIndex)
            return;

        if (index < 0 || index >= models.Count)
            return;

        models[selectionIndex].SetActive(false); 
        selectionIndex = index;                 
        models[selectionIndex].SetActive(true); // set index character to true
    }

    // Update is called once per frame
    private void Update()
    {
        if (IsKeyEnabled_Enter)                                          //*answers.unity3d.com* 
        {
                if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) //answers.unity3d.com -if enter key or return key is pressed do the following..

            {
                IsKeyEnabled_Enter = false;                             //*answers.unity3d.com* - set IsKeyEnabled to false
                var Vector3 = GameObject.FindGameObjectsWithTag("SignTag")[0].transform.position; //Vector3 = gameobject tagged "SignTag" and assign vector3 here
                GameObject sign = GameObject.FindGameObjectsWithTag("Sign")[0]; //sign = game object tagged "Sign"
                sign.transform.position = Vector3;                      //sign position= vector3
                SceneManager.LoadScene("level1");                       //load level 1
   
            }
           
        }
    }
   
    void Awake()
    {
        IsKeyEnabled_Enter = true; //just added
        DontDestroyOnLoad(transform.gameObject);
    }
}
