using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slider2Text : MonoBehaviour {
	public Slider slider;
	public Text text;
	public string additionalStuff;
	public bool isFloat;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	public void Update () {
		if(isFloat)
			text.text = slider.value.ToString ("0.00") + additionalStuff;
		else
			text.text = slider.value.ToString ("0") + additionalStuff;
	}
}
