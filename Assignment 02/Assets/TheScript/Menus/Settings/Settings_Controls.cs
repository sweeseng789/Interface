using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Settings_Controls : MonoBehaviour {
	public Image Move, Attack;
	public Toggle AutoAim, InvertedControls, FixedPos;

	Vector3 leftSide,rightSide;

	// Use this for initialization
	void Start () {
		if (Move.transform.position.x < Attack.transform.position.x) {
			leftSide = Move.transform.localPosition;
			rightSide = Attack.transform.localPosition;
		} else {
			leftSide = rightSide = Attack.transform.position;
			rightSide = Move.transform.position;
		}
	}

	public void updateBoxes() {
		if (AutoAim.isOn) {
			Attack.GetComponent<Image> ().enabled = false;
		} else {
			Attack.GetComponent<Image> ().enabled = true;
		}

		if (InvertedControls.isOn) {
			Move.transform.localPosition = rightSide;
			Attack.transform.localPosition = leftSide;
		} else {
			Move.transform.localPosition = leftSide;
			Attack.transform.localPosition = rightSide;
		}
	}
}
