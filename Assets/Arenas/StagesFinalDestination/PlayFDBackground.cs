using UnityEngine;
using System.Collections;

public class PlayFDBackground : MonoBehaviour {

    
    private bool loop;
	// Use this for initialization
	void Start () 
    {
        

        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();

      
      
	}
	
	// Update is called once per frame
	void Update () 
    {
        Renderer r = GetComponent<Renderer>();
        MovieTexture movie = (MovieTexture)r.material.mainTexture;
        movie.loop = true;
	}
}
