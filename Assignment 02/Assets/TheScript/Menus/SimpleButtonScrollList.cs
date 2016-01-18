using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item {
	public Sprite icon;
	public string name;
	public Button.ButtonClickedEvent onClick;
}

public class SimpleButtonScrollList : MonoBehaviour {
	
	public GameObject sampleButton;
	public List<Item> itemList;
	
	public Transform contentPanel;

	List<SimpleButton> GOS = new List<SimpleButton>();

	void Start () {
		PopulateList ();
	}
	
	void PopulateList () {
		foreach (var item in itemList) {
			GameObject newButton = Instantiate (sampleButton) as GameObject;
			SimpleButton button = newButton.GetComponent <SimpleButton> ();
			button.name.text = item.name;
			button.icon.sprite = item.icon;
			button.button.onClick = item.onClick;
			newButton.transform.SetParent (contentPanel);
			newButton.GetComponent<RectTransform>().localScale = new Vector3(1f,1f,1f);
			newButton.transform.localPosition = new Vector3(newButton.transform.localPosition.x, newButton.transform.localPosition.y, 0);
			GOS.Add(newButton.GetComponent <SimpleButton> ());
		}
		Color tempcol;
		tempcol = GOS [0].button.image.color;
		tempcol.a = 1;
		GOS [0].button.image.color = tempcol;
	}

	public void changeAlphaOnClick (int index) {
		Color tempcol;
		for (int i = 0; i < GOS.Count; ++i) {
			if(i == index){
				tempcol = GOS[i].button.image.color;
				tempcol.a = 1;
				﻿GOS[i].button.image.color = tempcol;
			} else {
				tempcol = GOS[i].button.image.color;
				tempcol.a = 0.4f;
				﻿GOS[i].button.image.color = tempcol;
			}
		}
	}
}