using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChangeModeSelectPanel : MonoBehaviour {
	//SettingRotate settingrotatescript;
	public CanvasGroup canvas;
	public Text CurrentButtonText;
	Text LastButtonText;

	public GameObject AudioPanel, ControlPanel, LanguagePanel, CreditsPanel;
	GameObject currentPanel;
	List<GameObject> panels = new List<GameObject>();

	// Use this for initialization
	void Start () {
		//settingrotatescript = gameObject.GetComponent<SettingRotate>();
		LastButtonText = gameObject.AddComponent<Text>();

		currentPanel = null;

		panels.Add (AudioPanel);
		panels.Add (ControlPanel);
		panels.Add (LanguagePanel);
		panels.Add (CreditsPanel);

		RectTransform rekt = canvas.GetComponent<RectTransform> ();

		for (int i = 1; i < panels.Count; i++) {
			Vector3 tempvec = panels[i].transform.position;
			tempvec.x += rekt.rect.width/4 * i;
			panels[i].transform.position = tempvec;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(LastButtonText.text != CurrentButtonText.text) {
			if(CurrentButtonText.text == "Audio"){
				currentPanel = AudioPanel;
				LastButtonText.text = CurrentButtonText.text;
			}
			else if(CurrentButtonText.text == "Controls") {
				currentPanel = ControlPanel;
				LastButtonText.text = CurrentButtonText.text;
			}
			else if(CurrentButtonText.text == "Language") {
				currentPanel = LanguagePanel;
				LastButtonText.text = CurrentButtonText.text;
			}
			else if(CurrentButtonText.text == "Credits") {
				currentPanel = CreditsPanel;
				LastButtonText.text = CurrentButtonText.text;
			}
		}
		if (currentPanel != null) {
			movePanel();
		}
	}

	void movePanel() {
		if (currentPanel.transform.position.x > canvas.transform.position.x) {
			float dist = (currentPanel.transform.position.x - canvas.transform.position.x);
			foreach (GameObject panel in panels) {
				Vector3 tempvec = panel.transform.position;
				tempvec.x -= dist * Time.deltaTime * 6;
				panel.transform.position = tempvec;
			}
			if (currentPanel.transform.position.x < canvas.transform.position.x) {
				currentPanel = null;
			}
		} else {
			float dist = (currentPanel.transform.position.x - canvas.transform.position.x);
			foreach (GameObject panel in panels) {
				Vector3 tempvec = panel.transform.position;
				tempvec.x -= dist * Time.deltaTime * 6;
				panel.transform.position = tempvec;
			}
			if (currentPanel.transform.position.x > canvas.transform.position.x) {
				currentPanel = null;
			}
		}
	}
}
