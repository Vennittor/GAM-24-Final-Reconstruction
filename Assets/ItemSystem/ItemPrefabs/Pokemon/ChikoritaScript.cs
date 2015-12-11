using UnityEngine;
using System.Collections;

public class ChikoritaScript : MonoBehaviour {

    public GameObject razorLeaf;
    public bool active = false;
    public bool facingRight = true;
    void Start()
    {
        Vector3 facing;
        int a = Random.Range(0, 2);
        if (a == 1)
        {
            facing = new Vector3(0, 100, 0);
            facingRight = true;
        }
        else
        {
            facing = new Vector3(0, 260, 0);
            facingRight = false;
        }

        transform.rotation = Quaternion.Euler(facing);
        Destroy(gameObject, 5f);
        InvokeRepeating("Fire", 1, .5f);
    }
	void Fire ()
    {
        if (facingRight)
        {
            GameObject leaf =Instantiate(razorLeaf,
                transform.position,
               Quaternion.identity) as GameObject;
            leaf.GetComponent<Leaf>().direction = Vector3.right;
            leaf.transform.position += new Vector3(0, .8f, 0);
            leaf.transform.rotation = Quaternion.Euler(new Vector3(10f, 100f, 140f));
            
        }
        else
        {
            GameObject leaf = Instantiate(razorLeaf,
                 transform.position,
                Quaternion.identity) as GameObject;
            leaf.GetComponent<Leaf>().direction = Vector3.left;
            leaf.transform.position += new Vector3(0, .5f, 0);
            leaf.transform.rotation = Quaternion.Euler(new Vector3(350f, 268f, 326f));
            
        }
    }
}
