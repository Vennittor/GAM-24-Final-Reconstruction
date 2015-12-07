using UnityEngine;
using System.Collections;

public class Leaf : MonoBehaviour {
    public Vector3 direction;
	void Update ()
    {
        transform.position += direction * 5 * Time.deltaTime;
	}
    void OnTriggerEnter(Collider other)
    {
        //if player
        //apply dmg  knockback
    }

}
