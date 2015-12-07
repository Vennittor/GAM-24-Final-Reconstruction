using UnityEngine;
using System.Collections;

public class Windmill : MonoBehaviour 
{
    //Purpose: Spin the Windmill
      //Characters on the lowest arm fall. If we are lucky this will be due to gravity and if we are not we will have to code in to determine which is the lowest arm and disable the mesh collider on it.
      // ^^ We may have to do this anyway for other practical reasons.

    //The higher windmilRotationLength is the slowerit goes
    public float windmilRotationLength = 0.2f;
    public float windmillRotationSpeed = 0.0f;
	
    // Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        windmillRotationSpeed = Time.deltaTime / windmilRotationLength;

        transform.Rotate(0, 0, windmillRotationSpeed);
	}
}
