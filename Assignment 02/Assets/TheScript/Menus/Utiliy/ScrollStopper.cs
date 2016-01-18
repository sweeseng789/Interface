using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ScrollStopper : MonoBehaviour {
	public ScrollRect scrollrekt;
	public List<GameObject> panels;

	float interval, stoppingPos;

	// Use this for initialization
	void Start () {
		interval = 1.0f/(panels.Count-1);
		stoppingPos = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (scrollrekt.velocity.magnitude == 0) {
			float f = 0;
			for (int i = 0; i < (panels.Count-1); ++i, f+=interval) {
				if(Mathf.Abs((scrollrekt.horizontalNormalizedPosition - f)) < stoppingPos)
				{
					stoppingPos = f;
				}
			}

			f = scrollrekt.horizontalNormalizedPosition;

			if(f < stoppingPos) {
				f += Time.deltaTime * (stoppingPos - f);
				scrollrekt.horizontalNormalizedPosition = f;
				if(scrollrekt.horizontalNormalizedPosition >= stoppingPos) {
					scrollrekt.horizontalNormalizedPosition = stoppingPos;
					stoppingPos = 2;
				}
			} else if(f > stoppingPos){
				f -= Time.deltaTime * (f - stoppingPos);
				scrollrekt.horizontalNormalizedPosition = f;
				if(scrollrekt.horizontalNormalizedPosition <= stoppingPos) {
					scrollrekt.horizontalNormalizedPosition = stoppingPos;
					stoppingPos = 2;
				}
			}
		}
	}
}
