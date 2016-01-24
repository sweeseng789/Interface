using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class ChangeHiPage : MonoBehaviour {
	public ScrollPage sp;
	public List <GameObject> pages;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < sp.panels.Count; ++i)
		{
			if(i == sp.getCurrentPageIndex ())
				pages[i].SetActive(true);
			else 
				pages[i].SetActive(false);
		}
			
	
	}
}
