using UnityEngine;
using System.Collections;

public class FireCollision : MonoBehaviour {

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("knockBack");
    }
}
