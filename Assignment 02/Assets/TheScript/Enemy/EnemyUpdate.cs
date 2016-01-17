using UnityEngine;
using System.Collections;

public class EnemyUpdate : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 10)
        {
            Vector3 newPos = new Vector3();
            newPos.x = Random.Range(-860, 1300);
            newPos.y = Random.Range(1480, -999);
            newPos.z = transform.position.z;

            transform.position = newPos;
        }
        else if (coll.gameObject.layer == 9)
        {
            Vector3 newPos = new Vector3();
            newPos.x = Random.Range(-860, 1300);
            newPos.y = Random.Range(1480, -999);
            newPos.z = transform.position.z;

            transform.position = newPos;
        }
    }
}
