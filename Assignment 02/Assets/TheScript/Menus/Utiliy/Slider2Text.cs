using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slider2Text : MonoBehaviour {
	public Slider slider;
	public Text text;
	public string additionalStuff;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	public void Update () {
		text.text = slider.value.ToString () + additionalStuff;
	}
}
