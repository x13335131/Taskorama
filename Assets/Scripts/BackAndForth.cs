using UnityEngine;
using System.Collections;

//script for moving fishes and platforms
//with help from 'gamesplusjames' youtube tutorial https://www.youtube.com/watch?v=HMZnSZswTmU

public class BackAndForth : MonoBehaviour {
    public float delta = 2.0f;  // Amount to move left and right from the start point
    public float speed = 2.0f;  //speed of animation
    private Vector2 startPos; 

    void Start()
    {
        startPos = transform.position;  //set start position
    }

    float Update()
    {
        
        Vector3 v = startPos;                           //vector3 is = to start position
        v.x += delta * Mathf.Sin(Time.time * speed);    //time * speed
        transform.position = v;                         //change position
        return v.x;
    }
}
