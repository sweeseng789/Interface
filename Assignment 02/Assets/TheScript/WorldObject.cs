using UnityEngine;
using System.Collections.Generic;

public class WorldObject : MonoBehaviour
{
    public GameObject worldObj;
    public Vector2 spawnDirection;
    public int spawnCount = 0;

	// Use this for initialization
	void Start ()
    {
        for (int a = 0; a < spawnCount; a++)
        {
            Vector2 newPos = transform.position;
            if (spawnDirection.x > 0)
            {
                newPos.x += a * worldObj.transform.localScale.x * 0.45f;
            }
            else if (spawnDirection.x < 0)
            {
                newPos.x += -a * worldObj.transform.localScale.x * 0.45f;
            }

            if (spawnDirection.y > 0)
            {
                newPos.y += a * worldObj.transform.localScale.y * 0.45f;
            }
            else if (spawnDirection.y < 0)
            {
                newPos.y += -a * worldObj.transform.localScale.y * 0.45f;
            }

            Instantiate(worldObj, newPos, Quaternion.identity);
        }
    }
}
