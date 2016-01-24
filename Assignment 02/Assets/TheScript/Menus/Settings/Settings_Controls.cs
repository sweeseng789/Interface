using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Settings_Controls : MonoBehaviour {
	public GameObject Move, Attack;
	public Toggle AutoAim, InvertedControls;
	public Slider opacity;

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

		if (StaticVarsNFuns.autoAim) {
			AutoAim.isOn = true;
		} else {
			AutoAim.isOn = false;
		}

		if (StaticVarsNFuns.invertControls) {
			InvertedControls.isOn = true;
		} else {
			InvertedControls.isOn = false;
		}

		opacity.value = StaticVarsNFuns.opacity;

		updateBoxes ();
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

		Color tem = Move.GetComponent<Image>().color;
		tem.a = opacity.value;
		Move.GetComponent<Image>().color = tem;
		Move.GetComponentsInChildren<Image> ()[1].color = tem;
		Attack.GetComponent<Image>().color = tem;
		Attack.GetComponentsInChildren<Image> ()[1].color = tem;
	}

	public void updateValues() {
		StaticVarsNFuns.autoAim = AutoAim.isOn;
		
		StaticVarsNFuns.invertControls = InvertedControls.isOn;
		
		StaticVarsNFuns.opacity = opacity.value;
	}
}
