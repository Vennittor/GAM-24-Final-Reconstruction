using UnityEngine;
using System.Collections;

public class Leaf : MonoBehaviour
{
    public Vector3 direction;
	void Update ()
    {
        transform.position += direction * 5 * Time.deltaTime;
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BaseCharacter>())
        {
            other.gameObject.GetComponent<BaseCharacter>().TakeDamage(6, .6f,
               PlayerStates.disabledAndProtectiveStates.ASLEEP, 0, transform);
        }
    }

}
