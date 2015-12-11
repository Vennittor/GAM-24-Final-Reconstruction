using UnityEngine;
using System.Collections;

public class Stomp : MonoBehaviour
{
    public GameObject master;
    float stompVelocity = 500;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnTriggerEnter(Collider other)
    {
        Physics.IgnoreCollision(master.GetComponent<BoxCollider>(), GetComponent<CapsuleCollider>());
        Debug.Log("hit");
        if (other.GetComponent<BaseCharacter>())
        {
            //other.GetComponent<Rigidbody>().AddForce(Vector3.up * stompVelocity);
            other.gameObject.GetComponent<BaseCharacter>().TakeDamage(20, 2,
          PlayerStates.disabledAndProtectiveStates.ASLEEP, 0, transform);
        }
    }
}
