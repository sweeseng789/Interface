using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoScroller : MonoBehaviour {
	public ScrollRect scrollrekt;
	public Text CurrentButtonText;

	float cur;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (CurrentButtonText.text == "Credits" || CurrentButtonText.text == "") {
			if (scrollrekt.verticalNormalizedPosition > 0) {
				cur = scrollrekt.verticalNormalizedPosition;
				cur -= Time.deltaTime * 0.1f; 
				scrollrekt.verticalNormalizedPosition = cur;
			} 
		} else {
			cur = 1;
			scrollrekt.verticalNormalizedPosition = cur;
		}
	}
}
