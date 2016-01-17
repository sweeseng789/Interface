using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour
{
    public GameObject worldObj;
    public int spawnCount = 0;

	// Use this for initialization
	void Start ()
    {
        for(int a = 0; a < spawnCount; ++a)
        {
            Vector3 newPos = new Vector3();
            newPos.x = Random.Range(-860, 1300);
            newPos.y = Random.Range(1480, -999);
            newPos.z = -1f;

            Instantiate(worldObj, newPos, Quaternion.identity);
        }
	}
}
