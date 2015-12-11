using UnityEngine;
using System.Collections;

public class Metagross : MonoBehaviour
{
    public GameObject left, right;

   
    bool switcher = true;
	void Start ()
    {
        InvokeRepeating("Stomp", 1, 1);
        Destroy(gameObject, 10f);
    }
	void Stomp()
    {
        right.SetActive(switcher);
        left.SetActive(!switcher);
        switcher = !switcher;
    }
    void OnCollisionEnter(Collision other)
    {
        //GetComponent<Rigidbody>().isKinematic = true;
    }
    
}
