using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    float time = 20;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;
        if (time < 0)
            Destroy(gameObject);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer != 9)
        {
            if(col.gameObject.layer == 11)
            {
                Player.score += 10;
                SceneManager.enemyCount--;
            }
            Destroy(gameObject);
        }
    }
}
