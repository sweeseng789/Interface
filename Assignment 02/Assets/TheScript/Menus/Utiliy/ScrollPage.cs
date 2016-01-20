using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class ScrollPage : MonoBehaviour {
	public ScrollRect scrollrekt;
	public List<GameObject> panels;
	GameObject currentPanel;

	public Button left, right;

	public GameObject dots;

	float centerX;

	bool snaped, dragging;

	// Use this for initialization
	void Start () {
		for (int i = 1; i < panels.Count; ++i) {
			Vector3 temppos;
			temppos = panels[i].transform.localPosition;
			temppos.x += scrollrekt.content.rect.width * 1.3f * i;
			panels[i].transform.localPosition = temppos;
		}

		currentPanel = panels [0];

		centerX = scrollrekt.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		centerX = scrollrekt.transform.position.x;
		if (dragging) {
			int index = 0;
			float shortestdist = 0;
			for(int i = 0; i < panels.Count; ++i) {
				if(i == 0) {
					index = i;
					shortestdist = Mathf.Abs(panels[i].transform.position.x - centerX);
				} else if (Mathf.Abs(panels[i].transform.position.x - centerX) < shortestdist){
						index = i;
						shortestdist = Mathf.Abs(panels[i].transform.position.x - centerX);
				}
			}
			currentPanel = panels[index];
			snaped = false;
			dots.GetComponent<SimpleButtonScrollList>().changeAlphaOnClick(index);
		}

		if (snaped == false) {
			left.GetComponent<Image>().enabled = true;
			right.GetComponent<Image>().enabled = true;
			left.GetComponent<Button>().enabled = true;
			right.GetComponent<Button>().enabled = true;

			if(currentPanel == panels[0]) {
				left.GetComponent<Image>().enabled = false;
				left.GetComponent<Button>().enabled = false;
			}
			else if(currentPanel == panels[panels.Count-1]) {
				right.GetComponent<Image>().enabled = false;
				right.GetComponent<Button>().enabled = false;
			}
			if (dragging == false) {
				movePanels ();
			}
		}
		/**/
	}

	void movePanels() {
		if (currentPanel.transform.position.x > centerX) {
			float dist = Mathf.Abs (currentPanel.transform.position.x - centerX);
			Vector3 temppos;
			for (int i = 0; i < panels.Count; ++i) {
				temppos = panels [i].transform.position;
				temppos.x -= dist * Time.deltaTime * 15;
				panels [i].transform.position = temppos;
			}
			if (currentPanel.transform.position.x < centerX ) {
				snaped = true;
			}

		} else if (currentPanel.transform.position.x < centerX) {
			float dist = Mathf.Abs (currentPanel.transform.position.x - centerX);
			Vector3 temppos;
			for (int i = 0; i < panels.Count; ++i) {
				temppos = panels [i].transform.position;
				temppos.x += dist * Time.deltaTime * 15;
				panels [i].transform.position = temppos;
			}
			if (currentPanel.transform.position.x > centerX ) {
				snaped = true;
			}
		} else {
			snaped = true;
		}
	}

	public void beginDrag ()
	{
		dragging = true;
	}

	public void endDrag ()
	{
		dragging = false;
	}

	public void moveLeft () {
		if (currentPanel != panels [0]) {
			for(int i = 1; i < panels.Count; ++i) {
				if(currentPanel == panels[i]) {
					currentPanel = panels[i-1];
					snaped = false;
					dots.GetComponent<SimpleButtonScrollList>().changeAlphaOnClick(i-1);
					break;
				}
			}
		}
	}

	public void moveRight () {
		if (currentPanel != panels [panels.Count - 1]) {
			for(int i = 0; i < panels.Count - 1; ++i) {
				if(currentPanel == panels[i]) {
					currentPanel = panels[i+1];
					snaped = false;
					dots.GetComponent<SimpleButtonScrollList>().changeAlphaOnClick(i+1);
					break;
				}
			}
		}
	}

	public void moveTo (int pos) {
		currentPanel = panels[pos];
		snaped = false;			
	}
}
