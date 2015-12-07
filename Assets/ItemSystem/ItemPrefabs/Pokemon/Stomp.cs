using UnityEngine;
using System.Collections;

public class Stomp : MonoBehaviour
{

    float stompVelocity = 500;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
              other.GetComponent<Rigidbody>().AddForce(Vector3.up * stompVelocity);
    }
}
