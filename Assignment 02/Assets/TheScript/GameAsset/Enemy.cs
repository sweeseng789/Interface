using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        switch(col.gameObject.layer)
        {
            case (9): //Bullet
                {
                    Debug.Log("Bullet Collision");
                    Destroy(gameObject);
                }
                break;

            default:
                break;
        }
    }
}
