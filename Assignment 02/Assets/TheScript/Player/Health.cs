using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
    public GameObject heartSymbol;
    public Text text;
    int healthPoint;

	// Use this for initialization
	void Start ()
    {
        transform.localScale = new Vector2(3, 3);
        healthPoint = 100;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 newPos = heartSymbol.transform.position;
        newPos.x += 20f;
        newPos.y -= 10f;
        transform.position = newPos;

        text.text = healthPoint.ToString() + "%";
	}
}
