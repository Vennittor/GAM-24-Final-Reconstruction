using UnityEngine;
using System.Collections;

public class Snorlax : MonoBehaviour
{
    bool goUp = false;
    bool goDown = false;

    float SnorlaxVelocity = 50;
    // Use this for initialization
    void Start()
    {
        Invoke("fly", 2);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (goUp)
            transform.position += Vector3.up * 5 * Time.deltaTime;
        if (transform.position.y >= 9)
        {
            gameObject.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(.4f, .4f, .4f), 1);
            goUp = false;
            goDown = true;
        }
        if(goDown)
            transform.position -= Vector3.up * 4 * Time.deltaTime;
        if (transform.position.y <= -10)
            Destroy(gameObject);

    }
    void fly()
    {
        goUp = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.transform.position.x - other.gameObject.transform.position.x <= 0)
        {
            if (other.gameObject.GetComponent<BaseCharacter>())
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 1, 0) * SnorlaxVelocity);
                other.gameObject.GetComponent<BaseCharacter>().TakeDamage(50, 2,
           PlayerStates.disabledAndProtectiveStates.ASLEEP, 0, transform);
            }
        }
        else
        {
            if (other.gameObject.GetComponent<BaseCharacter>())
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 1, 0) * SnorlaxVelocity);
                other.gameObject.GetComponent<BaseCharacter>().TakeDamage(50, 2,
          PlayerStates.disabledAndProtectiveStates.ASLEEP, 0, transform);
            }
        }

    }
}
