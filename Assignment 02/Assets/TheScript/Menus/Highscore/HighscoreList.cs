using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class HighscoreItem {
	public string positon;
	public Sprite icon;
	public string name;
	public string score;
	public bool isPlayer;
}

public class HighscoreList : MonoBehaviour {
	
	public GameObject sampleButton;
	public GameObject PlayerScore;
	public List<HighscoreItem> itemList;


	public Transform contentPanel;

	void Start () {
		PopulateList ();
	}
	
	void PopulateList () {
		foreach (var item in itemList) {
			GameObject newButton = Instantiate (sampleButton) as GameObject;
			HighscoreTab Tab = newButton.GetComponent <HighscoreTab> ();
			Tab.positon.text = item.positon;
			Tab.icon.sprite = item.icon;
			Tab.name.text = item.name;
			Tab.score.text = item.score;
			if(item.isPlayer) {
				/*newButton.GetComponentsInChildren<Image> ()[0].color = new Color(0, 0.9568f, 1, 1);
				newButton.GetComponentsInChildren<Image> ()[2].color = new Color(0, 0.9568f, 1, 1);
				newButton.GetComponentsInChildren<Image> ()[4].color = new Color(0, 0.9568f, 1, 1);*/
				newButton.GetComponentsInChildren<Image> ()[2].enabled = true;

				PlayerScore.GetComponentsInChildren<Text>()[0].text = item.positon;
				PlayerScore.GetComponentsInChildren<Text>()[1].text = item.score;
				PlayerScore.GetComponentsInChildren<Text>()[2].text = item.name;
			}
			newButton.transform.SetParent (contentPanel);
			newButton.GetComponent<RectTransform>().localScale = new Vector3(1f,1f,1f);
			newButton.transform.localPosition = new Vector3(newButton.transform.localPosition.x, newButton.transform.localPosition.y, 0);
		}
	}
}