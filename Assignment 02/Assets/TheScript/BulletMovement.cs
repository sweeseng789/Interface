using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{
    float timing = 10.0f;

    void Update()
    {
        timing -= Time.deltaTime;

        if(timing < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }
}
