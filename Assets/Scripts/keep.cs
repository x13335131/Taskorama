using UnityEngine;
using System.Collections;

public class keep : MonoBehaviour {
    //keeping an object when moving onto next level

	// Use this for initialization
	void Start () {
	    
	}

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject); //dont destroy game object - move it instead
    }

    // Update is called once per frame
    void Update () {
	
	}
}
