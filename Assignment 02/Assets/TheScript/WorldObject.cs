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
        if(spawnDirection != null && spawnCount != 0)
        {
            for(int a = 0; a < spawnCount; ++a)
            {
                GameObject newWorldObj = Instantiate(gameObject) as GameObject;

                Vector2 tempPos = new Vector2();

                if(spawnDirection.x > 0)
                {
                    tempPos.x = transform.position.x + (a * newWorldObj.transform.localScale.x);
                }
            }
        }
	}
}
