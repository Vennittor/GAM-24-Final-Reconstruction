using UnityEngine;
using System.Collections;

public class OrpheonMovingPlatform : MonoBehaviour {

    private float timer = 0.0f;
    
    // How long it pauses between actions 
    public float MoveDelay;

    //How fast it goes
    public int speed;

    //input  the direction where its going, any value other then 1 or -1 also changes the speed!
    public Vector3 startDirection;
    public Vector3 backDirection;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        timer += Time.deltaTime;

        //this works but is inefficient...

        if (timer <= MoveDelay)
        {
            transform.Translate(startDirection * Time.deltaTime * speed);

            
        }

        if (timer >= MoveDelay && timer <= MoveDelay * 2)
        {
            transform.Translate(startDirection * Time.deltaTime * 0);

            
        }

        if (timer >= MoveDelay * 2 && timer <= MoveDelay * 3)
        {
            transform.Translate(backDirection * Time.deltaTime * speed);


        }

        if (timer >= MoveDelay * 3 && timer <= MoveDelay * 4)
        {
            transform.Translate(backDirection * Time.deltaTime *0);


        }

        if (timer >= MoveDelay * 4 && timer <= MoveDelay * 5)
        {
            transform.Translate(backDirection * Time.deltaTime * speed);


        }

        if (timer >= MoveDelay * 5 && timer <= MoveDelay * 6)
        {

            transform.Translate(backDirection * Time.deltaTime * 0);

        }

        if (timer >= MoveDelay * 6 && timer <= MoveDelay * 7)
        {

            transform.Translate(startDirection * Time.deltaTime * speed);

        }

        if (timer >= MoveDelay * 7 && timer <= MoveDelay * 8)
        {

            transform.Translate(backDirection * Time.deltaTime * 0);

        }

        if (timer >= MoveDelay * 8 && timer <= MoveDelay * 9)
        {

            timer = 0;

        }
	}
}
