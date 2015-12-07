using UnityEngine;
using System.Collections;

public class Bobomb : ItemBaseScript
{
    public GameObject rayThrower;
   public float timer = 4;

    public bool goRight = true;
    // Use this for initialization
    public virtual void Start ()
    {
        base.Start();
	}
	
	// Update is called once per frame
	public virtual void Update ()
    {
        if(held == false)
            timer -= Time.deltaTime;
        if(timer<=0)
        {

            Vector3 moveDir = Vector3.right;
            if (goRight)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                gameObject.transform.position += Vector3.right * Time.deltaTime;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                gameObject.transform.position += Vector3.left * Time.deltaTime;
            }

            if (Physics.Raycast(rayThrower.transform.position, Vector3.down, 1))
            {
                Debug.Log("hitting");
            }
           else
            {
                goRight = !goRight;
            }
        }
              
        base.Update();
	}
    public override void FunctionAlpha()
    {

        base.FunctionAlpha();
    }
    public override void FunctionBeta()
    {

        base.FunctionBeta();
    }
    Vector3 PickDirection()
    {
        int randRoll = Random.Range(0, 2);
        if (randRoll == 0)
            return Vector3.right;
        else
            return Vector3.left;

    }
}
