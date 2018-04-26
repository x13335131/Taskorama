using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    //code so that camera follows player

    [SerializeField]
    private float xMax;                                     //set max of x axis-ie.furthest camera can go horizontally

    [SerializeField]
    private float yMax;                                     //set max of y axis

    [SerializeField]
    private float xMin;                                     //set min of x axis

    [SerializeField]
    private float yMin;                                     //set min of x axis

    private Transform target;                               

	// Use this for initialization
	void Start () {
        //finding player game object
        target = GameObject.FindGameObjectWithTag("Player").transform;       //target = player
	
	}

    // Update is called once per frame
    void Update() {
        if (target != null) { //if target is not equal to null
            transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z); //change position
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player").transform; //the camera target is the game object tagged "Player"
        }
	
	}
}
