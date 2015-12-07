using UnityEngine;
using System.Collections;

public class MoltresScript : MonoBehaviour {

    bool goUp = false;

    float moltresVelocity = 1;
    // Use this for initialization
    void Start ()
    {
        Invoke("fly", 2);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (goUp)
            transform.position += Vector3.up * Time.deltaTime;
        if (transform.position.y >= 15)
            Destroy(gameObject);
	}
    void fly()
    {
        goUp = true;
    }
    void OnCollisionEnter(Collision other)
    {

        foreach (ContactPoint contact in other.contacts)
        {
            Vector3 vect1;
            Vector3 vect2;

            if (contact.otherCollider.attachedRigidbody)
            {
                vect2 = contact.otherCollider.attachedRigidbody.velocity;

                vect2.Normalize();

                vect1 = Vector3.Reflect(vect2, contact.normal);
                vect1.Normalize();
               
                    contact.otherCollider.attachedRigidbody.AddForce(vect1 * moltresVelocity);
                }
            }
        }
    }
