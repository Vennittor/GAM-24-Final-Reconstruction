using UnityEngine;
using System.Collections;

public class PowerFailure : MonoBehaviour {

    // makes the lights flicker and go out and flips the stage
    bool atTarget = false;

    public Light Light;

    private float timer = 0.0f;

    public float OutageDelay;

    public bool isFlipped = false;

	public GameObject Alarms;
    
	public bool wait = false;

	public float delay;
    

   public bool upsideDown = false;
    public bool flip = false;
    private Vector3 targetAngles;

    // Use this for initialization
    void Start()
    {
		Alarms.SetActive(false);
        InvokeRepeating("FlipStage", Random.Range(15,25), Random.Range(20, 27));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

		if (wait == true) 
		{
			Alarms.SetActive(true);
			delay +=Time.deltaTime;

		if (delay >=2)
			{
			flip = true;
				delay = 0;
				wait = false;
			}
		}



        if (timer >= OutageDelay && timer <= OutageDelay * 1.005)
        {
            Light.intensity = 0.4f;


        }

        if (timer >= OutageDelay * 1.007 && timer <= OutageDelay * 1.6)
        {

            Light.enabled = false;

        }
        if (timer >= OutageDelay * 1.61)
        {

            

            Light.enabled = true;
            Light.intensity = 0.4f;

        }
        if (timer >= OutageDelay * 1.62)
        {


            Light.intensity = 1.0f;
            timer = 0;
        }





       
        // flip


        if (flip) {

				if (!upsideDown) {
					if (transform.rotation.eulerAngles.z <= 180) {
						transform.Rotate (new Vector3 (0, 0, 1) * 250f * Time.deltaTime);
					} else {
						upsideDown = !upsideDown;
					Alarms.SetActive(false);
						flip = false;
					}
				} else {
					if (transform.rotation.eulerAngles.z > 0) {//|| transform.rotation.eulerAngles.z >= 300)
						Debug.Log (transform.rotation.eulerAngles.z);
						transform.Rotate (new Vector3 (0, 0, 1) * 250f * Time.deltaTime);
						if (transform.rotation.eulerAngles.z < 5 || transform.rotation.eulerAngles.z > 350)
							transform.eulerAngles = Vector3.zero;
					} else if (transform.rotation.eulerAngles.z == 0) {
						Debug.Log ("stop");
						upsideDown = !upsideDown;
					Alarms.SetActive(false);
						flip = false;
					}
				}

		}
    }


    

	void FlipStage()
	{
		wait = true;
        

    }

	

    
   

}
