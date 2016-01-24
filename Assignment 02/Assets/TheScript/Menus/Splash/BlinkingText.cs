using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkingText : MonoBehaviour {
	public Text text;
	bool goingup;
	// Use this for initialization
	void Start () {
		goingup = false;
	}
	
	// Update is called once per frame
	void Update () {
		Color c;
		if (goingup) {
			c = text.color;
			c.a += Time.deltaTime/2.5f;
			text.color = c;
			if (c.a >= 0.75f)
				goingup = false;
		} else {
			c = text.color;
			c.a -= Time.deltaTime/2.5f;
			text.color = c;
			if (c.a <= 0)
				goingup = true;
		}
	}
}
