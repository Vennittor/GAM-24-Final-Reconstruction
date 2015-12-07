using UnityEngine;
using System.Collections;

public class ChikoritaScript : MonoBehaviour {

    public GameObject razorLeaf;
    public bool active = false;
    public bool facingRight;
    void Start()
    {
        //facingRight pokeball
        InvokeRepeating("Fire", 1, .5f);
    }
	void Fire ()
    {
        if (facingRight)
        {
            Instantiate(razorLeaf,
                transform.position + new Vector3(0, .5f, 0),
                Quaternion.Euler(new Vector3(42, 2, 90)));
            razorLeaf.GetComponent<Leaf>().direction = Vector3.right;
        }
        else
        {
            Instantiate(razorLeaf,
            transform.position + new Vector3(0, .5f, 0),
            Quaternion.Euler(new Vector3(324, 6, 270)));
            razorLeaf.GetComponent<Leaf>().direction = Vector3.left;
        }
    }
}
