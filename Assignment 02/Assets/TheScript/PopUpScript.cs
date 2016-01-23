using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpScript : MonoBehaviour {
	public Text discription;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}

	public void launch(string discription) {
		this.discription.text = discription;
		gameObject.SetActive (true);
	}

	public void end() {
		gameObject.SetActive (false);
	}
}
