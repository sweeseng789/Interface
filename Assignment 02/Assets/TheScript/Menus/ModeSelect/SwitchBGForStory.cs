using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SwitchBGForStory : MonoBehaviour {
	public ScrollPage scrollPage;
	public List<Image> Images;
	public Text StageText;

	int index;
	// Update is called once per frame
	void Update () {
		index = scrollPage.getCurrentPageIndex ();
		for (int i = 0; i < Images.Count; ++i) {
			if(index == i) {
				Images[i].GetComponent<Image>().enabled = true;
				if(index == 0)
					StageText.text = "Weed Plantation";
				else if(index == 1)
					StageText.text = "Lego Land";
				else
					StageText.text = "Hell";
				}
			else
				Images[i].GetComponent<Image>().enabled = false;
		}
	}
}
