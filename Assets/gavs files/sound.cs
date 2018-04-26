using UnityEngine;
using System.Collections;

public class sounds : MonoBehaviour
{
    public AudioClip impact;
    AudioSource aud;

    // Use this for initialization
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            aud.PlayOneShot(impact);
        }
    }
}