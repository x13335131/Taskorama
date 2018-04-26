using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    //rotating objects (pick up objects)
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
}
